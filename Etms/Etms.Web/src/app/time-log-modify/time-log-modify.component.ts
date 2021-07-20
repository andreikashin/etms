import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppError } from '../common/errors/app.error';
import { BadRequestError } from '../common/errors/bad-request.error';
import { TimeLogService } from '../services/time-log.service';

@Component({
  selector: 'time-log-modify',
  templateUrl: './time-log-modify.component.html',
  styleUrls: ['./time-log-modify.component.css']
})
export class TimeLogModifyComponent implements OnInit {

  invalidTimeLog: boolean = false;
  timeLog: any = {};
  id: string = "";

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private timeLogService: TimeLogService) {

  }

  getById() {
    console.log("get time log: " + this.id);
    this.timeLogService.getLog(this.id)
      .subscribe(result => {
        console.log("res: " + result);
        if (result) {
          console.log("timelog ok");
          this.timeLog = result;

          //this.router.navigate(['/']);
        }
        else {
          this.invalidTimeLog = true;
        }
      }, (error: AppError) => {
        if (error instanceof BadRequestError) {
          alert(error.originalError?.error.message);
        }
      });
  }

  modify(timeLog: any) {
    console.log("modify time log");
    timeLog.id = +this.id;
    timeLog.email = this.timeLog.email;
    this.timeLogService.modify(timeLog)
      .subscribe(result => {
        if (result) {
          console.log("timelog modified");
          this.router.navigate(['timelog']);
        }
        else {
          this.invalidTimeLog = true;
        }
      }, (error: AppError) => {
        if (error instanceof BadRequestError) {
          alert(error.originalError?.error.message);
        }
      });
  }

  ngOnInit(): void {
    this.route.paramMap
      .subscribe(params => {
        console.log(params);
      });

    this.id = this.route.snapshot.paramMap.get('id')!;

    this.getById();
  }
}
