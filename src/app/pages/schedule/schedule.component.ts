import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import * as moment from 'moment';
import { Moment } from 'moment';
import { Subject, takeUntil } from 'rxjs';
import { ISchedule } from 'src/app/models/schedule';
import { ScheduleService } from 'src/app/services/schedule.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit, OnDestroy {

  private unsubscriber = new Subject();

  schedules: ISchedule[];

  constructor(
    @Inject(ScheduleService)
    private readonly scheduleService: ScheduleService
  ) {
    this.schedules = [];
  }
  ngOnDestroy(): void {
    this.unsubscriber.next(null);
  }

  ngOnInit(): void {
    this.scheduleService.getSchedule()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe({
        next: schedule => {
          this.schedules = schedule;
        },
        error: err => console.error(err)
      });

  }
  getUniqueScheduleDays(onlyFuture: boolean = true) {
    const days = this.schedules.filter(x=>x.weekDay.isSameOrAfter(moment(),"day") || !onlyFuture).map(s => s.weekDay.format('LL'));
    const uniqueDays = [...new Set(days)];
    return uniqueDays;
  }

  getScheduleByDay(day: string) {
    return this.schedules.filter(x=>x.weekDay.format('LL') === day);
  }

}
