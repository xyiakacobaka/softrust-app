import { Component } from "@angular/core";

@Component({
  selector: "man-icon-svg",
  imports: [],
  templateUrl: "./man-icon.svg",
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
})
export class ManIconSVGComponent {}
