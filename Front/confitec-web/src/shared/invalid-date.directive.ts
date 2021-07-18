import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function invalidDateValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {

        const data = new Date( control.value);

        console.log(data)

        console.log(data > new Date())

        return data > new Date()?{invalidDate:{isDateValid: false}}: null
    };
  }