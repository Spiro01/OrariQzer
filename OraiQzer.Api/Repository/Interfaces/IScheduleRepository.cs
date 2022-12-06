using OrariQzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrariQzer.ApplicationCore.Interfaces.Repository
{
    public interface IScheduleRepository
    {
        public Task<IEnumerable<Schedule>> getSchedule(bool fromToday = false);
    }
}
