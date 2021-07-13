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
  id: string = "";
  
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private timeLogService: TimeLogService) { }

  modify(timeLog: any) {
    console.log("modify time log");
    timeLog.id = this.id;
    this.timeLogService.modify(timeLog)
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

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id')!;
  }
}
