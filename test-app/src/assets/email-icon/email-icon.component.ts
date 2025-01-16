import { Component } from "@angular/core";

@Component({
  selector: "email-icon",
  imports: [],
  templateUrl: "./email-icon.svg",
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
export class EmailIconSVGComponent {}
