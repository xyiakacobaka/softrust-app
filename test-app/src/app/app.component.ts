import { Component, OnInit } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";

import { PhoneIconSVGComponent } from "@assets/phone-icon/PhoneIconComponent";
import { EmailIconSVGComponent } from "@assets/email-icon/EmailIconComponent";
import { ManIconSVGComponent } from "@assets/man-icon/ManIcon";
import { NonZeroValidatorDirective } from "@validators/nonZeroValidator";
import { InputFieldComponent } from "@components/field-input/field-input.component";
import { Theme } from "src/types";
import { ThemeService } from "./services/theme.service";
import { CaptchaService } from "./services/captcha.service";
import { DomSanitizer, SafeHtml } from "@angular/platform-browser";

@Component({
  selector: "app-root",
  imports: [
    FormsModule,
    CommonModule,
    PhoneIconSVGComponent,
    EmailIconSVGComponent,
    ManIconSVGComponent,
    NonZeroValidatorDirective,
    InputFieldComponent,
  ],
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
  standalone: true,
})
export class AppComponent implements OnInit {
  captchaSvg: SafeHtml | null = null;
  captchaId: string | null = null;
  themes: Theme[] = [];

  constructor(
    private http: ThemeService,
    private captchaService: CaptchaService,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit() {
    this.http
      .getThemes()
      .subscribe({ next: (data: any) => (this.themes = data["themes"]) });
    this.loadCaptcha();
  }

  loginForm: any = {
    name: "",
    email: "",
    phoneNubmer: "",
    selectedTheme: 0,
    themes: this.themes,
    message: "",
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
  onSubmit(form: any): void {
    if (form.valid) {
      console.log("Форма валидна:", this.loginForm);
    } else {
      console.log("Форма невалидна", form.value);
    }
  }
}
