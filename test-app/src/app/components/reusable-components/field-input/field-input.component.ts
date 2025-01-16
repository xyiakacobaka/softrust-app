import { Component, forwardRef, Input } from "@angular/core";
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  NG_VALIDATORS,
  FormControl,
  Validator,
  FormsModule,
} from "@angular/forms";
import { NgxMaskDirective } from "ngx-mask";

@Component({
  selector: "input-field",
  templateUrl: "./field-input.component.html",
  styleUrls: ["./field-input.component.css"],
  imports: [FormsModule, NgxMaskDirective],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputFieldComponent),
      multi: true,
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => InputFieldComponent),
      multi: true,
    },
  ],
})
export class InputFieldComponent implements ControlValueAccessor, Validator {
  @Input() label: string = "";
  @Input() name: string = "";
  @Input() placeholder: string = "";
  @Input() required: boolean = false;
  @Input() pattern: string = "";
  @Input() svgicon: string = "";
  @Input() mask: string = "";

  private _value: string = "";

  get value(): string {
    return this._value;
  }

  set value(val: string) {
    this._value = val;
    this.onChange(val);
    this.onTouched();
  }

  onChange: any = () => {};
  onTouched: any = () => {};

  writeValue(value: any): void {
    this._value = value || "";
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  validate(control: FormControl): { [key: string]: any } | null {
    if (this.required && !control.value) {
      return { required: true };
    }
    if (this.pattern && !new RegExp(this.pattern).test(control.value)) {
      return { pattern: true };
    }
    return null;
  }
}
