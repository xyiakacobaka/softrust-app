import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { FormsModule, NgForm } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { DomSanitizer, SafeHtml } from "@angular/platform-browser";
import { EMPTY, Subject, switchMap, takeUntil } from "rxjs";
import { Router } from "@angular/router";

import { PhoneIconSVGComponent } from "@assets/phone-icon/phone-icon.component";
import { EmailIconSVGComponent } from "@assets/email-icon/email-icon.component";
import { ManIconSVGComponent } from "@assets/man-icon/man-icon.component";
import { NonZeroValidatorDirective } from "@directives/non-zero.directive";
import { InputFieldComponent } from "@reusable-components/field-input/field-input.component";
import { Theme } from "@types";
import { ThemesService } from "@services/themes.service";
import { CaptchaService } from "@services/captcha.service";

import { ContactsService } from "@services/contacts.service";
import { Contact } from "@app/shared/classes/contact";
import { Message } from "@app/shared/classes/message";
import { MessagesService } from "@services/mesages.service";

@Component({
  selector: "message-form",
  imports: [
    FormsModule,
    CommonModule,
    PhoneIconSVGComponent,
    EmailIconSVGComponent,
    ManIconSVGComponent,
    NonZeroValidatorDirective,
    InputFieldComponent,
  ],
  templateUrl: "./mesage-form.html",
  styleUrls: ["./mesage-form.css"],
  standalone: true,
})
export class MessageFormComponent implements OnInit {
  captchaSvg: SafeHtml = "";
  captchaId: string = "";
  themes: Theme[] = [];
  captchaIsValid: boolean | undefined = undefined;
  private destroy$ = new Subject<void>();

  loginForm: any = {
    userName: "",
    email: "",
    phoneNubmer: "",
    selectedTheme: 0,
    message: "",
    captcha: "",
  };

  constructor(
    private contactsService: ContactsService,
    private themesService: ThemesService,
    private messagesService: MessagesService,
    private captchaService: CaptchaService,
    private sanitizer: DomSanitizer,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadThemes();
    this.loadCaptcha();
  }

  loadThemes(): void {
    this.themesService
      .loadAndSaveThemes()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (data: any) => (this.themes = data),
        error: (err) => {
          console.error("Ошибка при загрузке тем:", err);
        },
      });
  }

  loadCaptcha(): void {
    this.captchaService
      .getCaptcha()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (response) => {
          this.captchaSvg = this.sanitizer.bypassSecurityTrustHtml(
            response.data
          );
          this.captchaId = response.id;
        },
        error: (err) => {
          console.error("Ошибка при получении CAPTCHA:", err);
        },
      });
  }

  navigateToAddedMessage(id: number): void {
    this.router.navigate(["/message"], { state: { id } });
  }

  onSubmit(): void {
    this.captchaService
      .validateCaptcha(this.captchaId, this.loginForm.captcha)
      .pipe(
        takeUntil(this.destroy$),
        switchMap((captcha) => {
          if (captcha.valid) {
            this.captchaIsValid = true;

            const contact: Contact = {
              userName: this.loginForm.userName,
              email: this.loginForm.email,
              phoneNumber: this.loginForm.phoneNubmer,
            };

            return this.contactsService.addContact(contact).pipe(
              switchMap((contactId) => {
                const message: Message = {
                  content: this.loginForm.message,
                  themeId: Number(this.loginForm.selectedTheme),
                  contactId: contactId.id,
                };
                return this.messagesService.addMessage(message);
              })
            );
          } else {
            this.captchaIsValid = false;
            this.loadCaptcha();
            console.error("Капча невалидна. Пожалуйста, попробуйте снова.");
            return EMPTY;
          }
        })
      )
      .subscribe({
        next: (data) => {
          this.navigateToAddedMessage(data.id);
        },
        error: (error) => {
          console.error("Ошибка при добавлении контакта или сообщения:", error);
          this.captchaIsValid = false;
          this.loadCaptcha();
        },
      });
  }
}
