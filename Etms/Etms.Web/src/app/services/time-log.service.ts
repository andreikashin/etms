import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class TimeLogService extends DataService {

  timeLogUrl = 'timelog'

  apiPort = environment.apiPort;
  baseUrl = `http://${window.location.hostname}${this.apiPort}/api/`;

  constructor(http: HttpClient) {
    super('/', http);

  }

  logTime(logForm: any) {
    this.url = this.baseUrl + this.timeLogUrl;
    return this.create(logForm);
  }

  modify(logForm: any) {
    this.url = this.baseUrl + this.timeLogUrl;
    return this.update(logForm);
  }
}
