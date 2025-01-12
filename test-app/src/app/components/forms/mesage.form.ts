import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { FormsModule, NgForm } from "@angular/forms";
import { CommonModule } from "@angular/common";

import { PhoneIconSVGComponent } from "@assets/phone-icon/PhoneIconComponent";
import { EmailIconSVGComponent } from "@assets/email-icon/EmailIconComponent";
import { ManIconSVGComponent } from "@assets/man-icon/ManIcon";
import { NonZeroValidatorDirective } from "@validators/nonZeroValidator";
import { InputFieldComponent } from "@components/field-input/field-input.component";
import { Theme } from "src/types";
import { ThemeService } from "@services/theme.service";
import { CaptchaService } from "@services/captcha.service";
import { DomSanitizer, SafeHtml } from "@angular/platform-browser";
import { ValidateService } from "@services/validate.service";

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
  templateUrl: "./mesage.form.html",
  styleUrls: ["./mesage.form.css"],
  standalone: true,
})
export class MessageFormComponent implements OnInit {
  captchaSvg: SafeHtml = "";
  captchaId: string = "";
  themes: Theme[] = [];
  captchaValid: boolean = false;
  @Output() formSubmitted = new EventEmitter<boolean>();

  constructor(
    private http: ThemeService,
    private captchaService: CaptchaService,
    private validateCaptcha: ValidateService,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit() {
    this.http
      .getThemes()
      .subscribe({ next: (data: any) => (this.themes = data["themes"]) });
    this.loadCaptcha();
  }

  loginForm: any = {
    userName: "",
    email: "",
    phoneNubmer: "",
    selectedTheme: 0,
    message: "",
    captcha: "",
  };

  loadCaptcha(): void {
    this.captchaService.getCaptcha().subscribe({
      next: (response) => {
        this.captchaSvg = this.sanitizer.bypassSecurityTrustHtml(response.data);
        this.captchaId = response.id;
      },
      error: (err) => {
        console.error("Ошибка при получении CAPTCHA:", err);
      },
    });
  }

  onSubmit(form: NgForm): void {
    if (form.valid) {
      this.validateCaptcha
        .validateCaptcha(this.captchaId, this.loginForm.captcha)
        .subscribe((valid) => {
          if (valid.valid) {
            this.formSubmitted.emit(valid.valid);
          } else {
            this.loadCaptcha();
          }
        });
    }
  }
}
