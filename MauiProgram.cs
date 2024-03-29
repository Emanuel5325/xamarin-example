﻿using MauiExample.Database;
using MauiExample.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MauiExample
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddDbContext<MauiExampleContext>();

            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddTransient<ItemDetailPage>();
            builder.Services.AddTransient<NewItemPage>();
            builder.Services.AddTransient<AboutPage>();
            builder.Services.AddTransient<ItemsPage>();
            builder.Services.AddTransient<GetWorkPage>();
            builder.Services.AddTransient<MapPage>();
            builder.Services.AddSingleton<MauiExampleDatabase>();

            var dbContext = new MauiExampleContext();
            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception)
            {
            }
            dbContext.Dispose();

            return builder.Build();
        }
    }
}
