import { Component } from "@angular/core";

@Component({
  selector: "phone-icon",
  imports: [],
  templateUrl: "./phone-icon.svg",
  styles: [
    `
      :host {
        position: absolute;
        width: 20px;
        height: 20px;
        padding-left: 7px;
      }
    `,
  ],
  standalone: true,
})
export class PhoneIconSVGComponent {}
