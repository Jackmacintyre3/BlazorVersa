using BlazorVersa.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Hosting;
using System;
using System.Net.Http;
using MudBlazor.Services;

namespace BlazorVersa
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            // Register HttpClient
            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://maui-d3f73-default-rtdb.europe-west1.firebasedatabase.app/")
                // Add any necessary headers here
            });

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<FirebaseService>();
            builder.Services.AddMudServices();
            builder.Services.AddSingleton<IEmailService, EmailService>();


            return builder.Build();
        }
    }
}
