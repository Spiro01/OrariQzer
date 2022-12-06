using Microsoft.AspNetCore.Mvc;
using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Entities;

namespace OraiQzer.Api.Controllers;

public static class Reports
{
    public static RouteGroupBuilder MapReportsGroup(this RouteGroupBuilder group)
    {
        group.MapPost("/error", async ([FromBody]ErrorReport error,[FromServices]ILogger<ErrorReport> logger) =>
        {
            logger.LogError("An exception occurred on a client in date {date}: {ex} \n {innerMessage}", error.Date,
                    error.Message, error.InnerException);
            return Results.NoContent();
        });
            
        
        
        return group;
    }
}