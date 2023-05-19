import { Moment } from "moment";

export interface ISchedule {
    subject: string;
    teacher: string;
    classRoom: string;
    weekDay: Moment;
    startTime: Moment;
    endTime: Moment;
}
