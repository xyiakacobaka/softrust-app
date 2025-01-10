import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { NgxMaskDirective } from "ngx-mask";

import { PhoneIconSVGComponent } from "../assets/phone-icon/PhoneIconComponent";
import { EmailIconSVGComponent } from "../assets/email-icon/EmailIconComponent";
import { ManIconSVGComponent } from "../assets/man-icon/ManIcon";
import { NonZeroValidatorDirective } from "../validator-directives/nonZeroValidator";
import { ReusableInputFieldComponent } from "./reusable-components/reusable-input-field/reusable-input-field.component";

@Component({
  selector: "app-root",
  imports: [
    FormsModule,
    CommonModule,

    PhoneIconSVGComponent,
    EmailIconSVGComponent,
    ManIconSVGComponent,
    NonZeroValidatorDirective,
    ReusableInputFieldComponent,
  ],
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
  standalone: true,
})
export class AppComponent {
  options = [
    { id: 1, label: "фа" },
    { id: 2, label: "Опция 2" },
    { id: 3, label: "Опция 3" },
  ];
  loginForm: any = {
    name: "",
    email: "",
    phoneNubmer: "",
    selectedTheme: 0,
    themes: this.options,
    message: "",
  };
  printForm() {
    console.log(this.loginForm.selectedTheme);
  }
  nonZeroValue() {
    if (this.loginForm.selectedTheme === 0) {
      return;
    }
  }
}
