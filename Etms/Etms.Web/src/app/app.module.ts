import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TimeLogComponent } from './time-log/time-log.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HomeComponent } from './home/home.component';
import { AuthService } from './services/auth.service';
import { HttpClientModule } from '@angular/common/http';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { TimeLogService } from './services/time-log.service';
import { AuthInterceptor } from './common/helpers/auth.interceptor';
import { TimeLogModifyComponent } from './time-log-modify/time-log-modify.component';
import { TimeLogNewComponent } from './time-log-new/time-log-new.component';

@NgModule({
  declarations: [
    AppComponent,
    TimeLogComponent,
    NotFoundComponent,
    LoginComponent,
    SignupComponent,
    HomeComponent,
    NavMenuComponent,
    TimeLogModifyComponent,
    TimeLogNewComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    AuthService,
    AuthInterceptor,
    TimeLogService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
