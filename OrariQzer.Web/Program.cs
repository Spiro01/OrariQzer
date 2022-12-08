using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Repository;
using OrariQzer.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IClientScheduleRepository, DriveScheduleRepository>();
builder.Services.AddScoped<IClientReportRepository, ClientReportRepository>();
await builder.Build().RunAsync();
