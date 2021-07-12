import { AbstractControl, ValidationErrors, FormGroup } from '@angular/forms';

export class PasswordValidators {
    static mustBeValid(control: AbstractControl): ValidationErrors | null {
        return new Promise((resolve) => {
            setTimeout(() => {
                if (control.value !== "1234") {
                    resolve({ mustBeValid: true });
                } else {
                    resolve(null);
                }
            }, 2000);
        });
    }

    static mustMatch(control: AbstractControl): ValidationErrors | null {
        let inputPassword = control.get('password');
        let repeatPassword = control.get('confirmPassword');

        if (inputPassword?.value !== repeatPassword?.value) {
            return { mustMatch: true };
        }

        return null;
    }
}