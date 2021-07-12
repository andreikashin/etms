import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { BadRequestError } from 'src/app/common/errors/bad-request.error';
import { AppError } from 'src/app/common/errors/app.error';
import { TimeLogService } from '../services/time-log.service';

@Component({
  selector: 'time-log',
  templateUrl: './time-log.component.html',
  styleUrls: ['./time-log.component.css']
})
export class TimeLogComponent implements OnInit {

  invalidTimeLog: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private timeLogService: TimeLogService) { }

  logTime(timeLog: any) {
    console.log("time log");
    this.timeLogService.logTime(timeLog)
      .subscribe(result => {
        if (result)
          console.log("timelog ok");
          //this.router.navigate(['/']);
        else
          this.invalidTimeLog = true;
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
