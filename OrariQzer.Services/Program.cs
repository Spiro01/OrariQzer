using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using OrariQzer.Services.Configuration;
using OrariQzer.Services.Google;
using OrariQzer.Services.Interfaces;
using OrariQzer.Services.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGoogleService, GoogleService>();
var LocalConfigurations = builder.Configuration.Get<AppSettings>();
builder.Services.AddSingleton(LocalConfigurations.GoogleApiConfiguration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGroup("/google")
    .MapAuthenticateEndPoint()
    .WithOpenApi();


app.Run();


