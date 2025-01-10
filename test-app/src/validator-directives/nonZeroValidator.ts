import { Directive } from "@angular/core";
import {
  NG_VALIDATORS,
  Validator,
  AbstractControl,
  ValidationErrors,
} from "@angular/forms";

@Directive({
  selector: "[NonZero]",
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: NonZeroValidatorDirective,
      multi: true,
    },
  ],
})
export class NonZeroValidatorDirective implements Validator {
  validate(control: AbstractControl): ValidationErrors | null {
    const value = control.value;
    if (value === 0 || value === "0") {
      return { nonZero: { value: control.value } };
    }
    return null;
  }
}
