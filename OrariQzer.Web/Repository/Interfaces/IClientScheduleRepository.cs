using OrariQzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrariQzer.ApplicationCore.Interfaces.Repository
{
    public interface IClientScheduleRepository
    {
        public Task<IEnumerable<Schedule>> getOrari();
    }
}
