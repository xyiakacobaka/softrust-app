import { Component, Input } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { NgxMaskDirective } from "ngx-mask";

@Component({
  selector: "reusable-input-field",
  templateUrl: "./reusable-input-field.component.html",
  styleUrls: ["./reusable-input-field.component.css"],
  imports: [FormsModule, NgxMaskDirective],
})
export class ReusableInputFieldComponent {
  @Input() label: string = "";
  @Input() name: string = "";
  @Input() value: string = "";
  @Input() placeholder: string = "";
  @Input() required: boolean = false;
  @Input() pattern: string = "";
  @Input() svgicon: string = "";
  @Input() mask: string = "";
}
