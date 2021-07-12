import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable, EMPTY, throwError } from 'rxjs';

import { AppError } from '../common/errors/app.error';
import { NotFoundError } from '../common/errors/not-found.error';
import { BadRequestError } from '../common/errors/bad-request.error';

export class DataService {

  httpOptions = {
    headers: new HttpHeaders({
      'Accept': 'application/x-www-form-urlencoded',
      'Content-Type': 'application/json'
    })
  };

  constructor(
    public url: string,
    private http: HttpClient,
    options?: any) {
    if (options) {
      this.httpOptions = options;
    }
  }

  getAll() {
    
    return this.http.get(this.url)
      .pipe(
        map((response: any) => response.json()),
        catchError(this.handleError)
      );
  }

  get(id: string) {

    return this.http.get(this.url + '/' + id)
      .pipe(
        map((response: any) => response.json()),
        catchError(this.handleError)
      );
  }

  create(resource: any) {

    return this.http.post(this.url, JSON.stringify(resource), this.httpOptions)
      .pipe(
        // map((response: any) => response.json()),
        catchError(this.handleError)
      );
  }

  update(resource: { id: string; }) {

    return this.http.patch(this.url + "/" + resource.id, JSON.stringify({ isRead: true }))
      .pipe(
        map((response: any) => response.json()),
        catchError(this.handleError)
      );
  }

  delete(id: string) {

    return this.http.delete(this.url + "/" + id)
      .pipe(
        map((response: any) => response.json()),
        catchError(this.handleError)
      )
      .toPromise();
  }

  private handleError(error: HttpErrorResponse) {

    if (error.status === 400) {
      return throwError(new BadRequestError(error));
    }

    if (error.status === 404) {
      return throwError(new NotFoundError());
    }

    return throwError(new AppError(error));
  }
}
