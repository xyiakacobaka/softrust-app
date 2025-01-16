import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { FormsModule, NgForm } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { DomSanitizer, SafeHtml } from "@angular/platform-browser";
import { Subject, takeUntil } from "rxjs";

import { PhoneIconSVGComponent } from "@assets/phone-icon/phone-icon.component";
import { EmailIconSVGComponent } from "@assets/email-icon/email-icon.component";
import { ManIconSVGComponent } from "@assets/man-icon/man-icon.component";
import { NonZeroValidatorDirective } from "@app/shared/directives/non-zero.directive";
import { InputFieldComponent } from "@reusable-components/field-input/field-input.component";
import { Theme } from "@types";
import { GetThemeService } from "@app/services/theme.services/get-themes.service";
import { GetCaptchaService } from "@app/services/captcha.services/get-captcha.service";
import { ValidateService } from "@app/services/captcha.services/validate-captcha.service";
import { Router } from "@angular/router";
import { LoadAndSaveThemesService } from "@app/services/theme.services/load-and-save-themes.service";
import { AddContactService } from "@app/services/contact.services/add-contact.service";
import { Contact } from "@app/shared/classes/contact";

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
    private addContactService: AddContactService,
    private loadAndSaveThemeService: LoadAndSaveThemesService,
    private captchaService: GetCaptchaService,
    private validateCaptchaService: ValidateService,
    private sanitizer: DomSanitizer,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadThemes();
    this.loadCaptcha();
  }

  loadThemes(): void {
    this.loadAndSaveThemeService
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
    this.router.navigate(["/message", id]);
  }

  addContact(contact: Contact): void {
    this.addContactService.addContact(contact).subscribe({
      next: (response) => {
        console.log("Контакт успешно добавлен:", response);
        this.navigateToAddedMessage(response.id);
      },
      error: (error) => {
        console.error("Ошибка при добавлении контакта:", error);
      },
    });
  }

  onSubmit(form: NgForm): void {
    if (form.valid) {
      this.validateCaptchaService
        .validateCaptcha(this.captchaId, this.loginForm.captcha)
        .pipe(takeUntil(this.destroy$))
        .subscribe({
          next: (captcha) => {
            if (captcha.valid) {
              this.captchaIsValid = true;
              const contact: Contact = {
                userName: this.loginForm.userName,
                email: this.loginForm.email,
                phoneNumber: this.loginForm.phoneNubmer,
              };
              this.addContact(contact);
            } else {
              this.captchaIsValid = false;
              this.loadCaptcha();
              console.error("Капча невалидна. Пожалуйста, попробуйте снова.");
            }
          },
          error: (error) => {
            console.error("Ошибка при валидации капчи:", error);
            this.captchaIsValid = false;
            this.loadCaptcha();
          },
        });
    } else {
      console.warn("Форма невалидна. Пожалуйста, заполните все поля.");
    }
  }
}
