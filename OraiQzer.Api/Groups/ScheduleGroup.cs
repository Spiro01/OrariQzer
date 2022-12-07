using OrariQzer.ApplicationCore.Interfaces.Repository;

namespace OraiQzer.Api.Controllers;

public static class ScheduleGroup
{
    public static RouteGroupBuilder MapScheduleGroup(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IScheduleRepository scheduleRepository) => await scheduleRepository.getSchedule())
            .CacheOutput(options => { options.Expire(TimeSpan.FromMinutes(5));});


        return group;
    }
}