import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SignupComponent } from './signup/signup.component';
import { TimeLogModifyComponent } from './time-log-modify/time-log-modify.component';
import { TimeLogNewComponent } from './time-log-new/time-log-new.component';
import { TimeLogComponent } from './time-log/time-log.component';

const routes: Routes = [

  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'timelog', component: TimeLogComponent },
  { path: 'timelog/new', component: TimeLogNewComponent },
  { path: 'timelog/:id', component: TimeLogModifyComponent },
  { path: "**", component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
