import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { UsernameValidators } from 'src/app/common/validators/username.validators';
import { PasswordValidators } from 'src/app/common/validators/password.validators';
import { BadRequestError } from 'src/app/common/errors/bad-request.error';
import { HttpErrorResponse } from '@angular/common/http';
import { AppError } from 'src/app/common/errors/app.error';


@Component({
  selector: 'signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  invalidSignup: Boolean = false;

  // form1 = new FormGroup({
  //   username: new FormControl('', [
  //     Validators.required,
  //     Validators.email,
  //     Validators.minLength(7),
  //     UsernameValidators.cannotContainSpace
  //   ]),
  //   password: new FormControl('', [Validators.required])
  // });

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService) {
    this.form = fb.group({
      username: ['', [
        Validators.required,
        Validators.email,
        Validators.minLength(7),
        UsernameValidators.cannotContainSpace
      ]],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    }, {
      validator: PasswordValidators.mustMatch
    });
  }

  signup(formData: any) {
    this.authService.signup(formData)
      .subscribe((result: any) => {
        if (result && result.username) {
          this.router.navigate(['/login'], { queryParams: { username: result.username } });
        }
        else {
          this.invalidSignup = true;
        }
      }, (error: AppError) => {
        if (error instanceof BadRequestError) {
          this.form.setErrors(error.originalError?.error);
          console.log(error.originalError?.error);
        }
      });
  }

  get username() {
    return this.form.get('username');
  }
  get password() {
    return this.form.get('password');
  }
  get confirmPassword() {
    return this.form.get('confirmPassword');
  }

  log(){
    console.log(this.form);
  }

  ngOnInit() {
  }

}
