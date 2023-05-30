import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, map, takeUntil } from 'rxjs';
import { ISchedule } from '../models/schedule';
import { environment } from 'src/environments/environment';
import { Moment } from 'moment';
import * as moment from 'moment';

@Injectable(
  { providedIn: "root" }
)
export class ScheduleService {
  constructor(
    private readonly http: HttpClient
  ) { }

  getSchedule(): Observable<ISchedule[]> {
    const request = this.http.get<string[][]>(environment.orariQzerUrl);
    moment.locale('it');
    return request
      .pipe(
        map(rows =>
          rows
            .filter(x => x != null)
            .map(x => this.toSchedule(x))
            
        )
      )

  }


  private toSchedule(row: string[]): ISchedule {
    
    const schedule: ISchedule = {
      subject: row[6] ?? "",
      teacher: row[5] ?? "",
      classRoom: row[7] ?? "",
      weekDay:  moment(row[3],"DD-MMM-YY","it") ?? null,
      startTime: moment(row[1],"LT") ?? null,
      endTime: moment(row[2],"LT") ?? null,
    };
    return schedule;

  }
}


