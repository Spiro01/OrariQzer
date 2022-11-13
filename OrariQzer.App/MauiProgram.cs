using Microsoft.AspNetCore.Components.WebView.Maui;
using OrariQzer.Domain;

namespace OrariQzer.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .RegisterBlazorMauiWebView()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddData();
            builder.Services.AddApplicationCore();
            builder.Services.AddBlazorWebView();



            return builder.Build();
        }
    }
}