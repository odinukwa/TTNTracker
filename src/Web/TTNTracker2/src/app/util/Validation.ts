import { AbstractControl, ValidatorFn, ValidationErrors } from '@angular/forms';

export default class Validation {
    static match(controlName: string, checkControlName: string): ValidatorFn {
        return (controls: AbstractControl) => {
            const control = controls.get(controlName);
            const checkControl = controls.get(checkControlName);

            if (checkControl.errors && !checkControl.errors.matching) {
                return null;
            }

            if (control.value !== checkControl.value) {
                controls.get(checkControlName).setErrors({ matching: true });
                return { matching: true };
            } else {
                return null;
            }
        };
    }
}

export function forbiddenNameValidator(nameRe: RegExp): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        const forbidden = nameRe.test(control.value);
        return forbidden ? { forbiddenName: { value: control.value } } : null;
    };
}