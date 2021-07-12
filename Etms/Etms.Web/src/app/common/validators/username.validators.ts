import { AbstractControl, ValidationErrors } from '@angular/forms';

export class UsernameValidators {
    static cannotContainSpace(control: AbstractControl): ValidationErrors | null {
        if (control.value &&
            (control.value as string).indexOf(' ') >= 0) {
            return { cannotContainSpace: true };
        }

        return null;
    }

    // static mustBeUnique(control: AbstractControl): Promise<ValidationErrors | null> {
    //     return new Promise((resolve, reject) => {
    //         setTimeout(() => {
    //             console.log("ok");

    //             if (control.value === "Admin") {
    //                 resolve({ mustBeUnique: true });
    //             } else {
    //                 resolve(null);
    //             }
    //         }, 2000);
    //     });
    // }
}