import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
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

  schedule: ISchedule[];

  constructor(
    @Inject(ScheduleService)
    private readonly scheduleService: ScheduleService
  ) {
    this.schedule = [];
  }
  ngOnDestroy(): void {
    this.unsubscriber.next(null);
  }

  ngOnInit(): void {
    this.scheduleService.getSchedule()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe({
        next: schedule => {
          this.schedule = schedule;
        },
        error: err => console.error(err)
      });

  }
  getUniqueScheduleDays() {
    const days = this.schedule.map(s => s.weekDay.format('LL'));
    const uniqueDays = [...new Set(days)];
    return uniqueDays;
  }



}
