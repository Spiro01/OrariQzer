using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrariQzer.Domain.Entities
{
    public class Schedule
    {
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string ClassRoom { get; set; }

        public DateOnly WeekDay { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }


        public Schedule(string subject,string teacher,string classRoom,string weekday, string startTime, string endTime)
        {
            Subject = subject;
            Teacher = teacher;
            ClassRoom = classRoom;
            
            if(DateOnly.TryParse(weekday,CultureInfo.InvariantCulture, out DateOnly parsedWeekDay ))WeekDay = parsedWeekDay;
            if(TimeOnly.TryParseExact(startTime,"H.mm", out TimeOnly parsedStartTime ))StartTime = parsedStartTime;
            if(TimeOnly.TryParseExact(endTime, "H.mm", out TimeOnly parsedEndTime ))EndTime = parsedEndTime;
            

        }


        public Schedule()
        {
            
        }

        

    }
}
