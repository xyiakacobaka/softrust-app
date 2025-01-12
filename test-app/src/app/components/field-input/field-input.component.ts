import { Component, Input } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { NgxMaskDirective } from "ngx-mask";

@Component({
  selector: "input-field",
  templateUrl: "./field-input.component.html",
  styleUrls: ["./field-input.component.css"],
  imports: [FormsModule, NgxMaskDirective],
})
export class InputFieldComponent {
  @Input() label: string = "";
  @Input() name: string = "";
  @Input() value: string = "";
  @Input() placeholder: string = "";
  @Input() required: boolean = false;
  @Input() pattern: string = "";
  @Input() svgicon: string = "";
  @Input() mask: string = "";
}
