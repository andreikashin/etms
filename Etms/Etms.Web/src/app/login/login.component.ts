import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { BadRequestError } from 'src/app/common/errors/bad-request.error';
import { AppError } from 'src/app/common/errors/app.error';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService) { }

  login(credentials: any) {

    this.authService.login(credentials)
      .subscribe(result => {
        if (result)
          this.router.navigate(['/']);
        else
          this.invalidLogin = true;
      }, (error: AppError) => {
        if (error instanceof BadRequestError) {
          alert(error.originalError?.error.message);
        }
      });
  }

  ngOnInit() {
    this.route.paramMap
      .subscribe(params => {
        console.log(params);
      })
  }
}
