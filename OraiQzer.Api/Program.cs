using OraiQzer.Api.Controllers;
using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOutputCache();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IScheduleRepository, ScheduleRepository>();

var app = builder.Build();

var corsConfiguration = builder.Configuration.GetSection("Cors");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors(options =>
{
    options.WithOrigins(corsConfiguration.GetSection("AllowedOrigins").Value?.Split(";") ?? Array.Empty<string>());
});


app.UseHttpsRedirection();
app.MapControllers();
app.UseOutputCache();

app.MapGroup("/orari")
    .MapScheduleGroup()
    .WithOpenApi();

app.MapGroup("/reports")
    .MapReportsGroup()
    .WithOpenApi();


app.Run();
