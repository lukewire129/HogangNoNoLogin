﻿using MauiReactor;
using HogangNoNo_Toy_mauiReactor.Pages;
using HogangNoNo_Toy_mauiReactor.Controls;

namespace HogangNoNo_Toy_mauiReactor
{
        public static class MauiProgram
        {
                public static MauiApp CreateMauiApp()
                {
                        var builder = MauiApp.CreateBuilder();
                        builder
                            .UseMauiReactorApp<MainPage>(app =>
                            {
                                    app.AddResource("Resources/Styles/Colors.xaml");
                                    app.AddResource("Resources/Styles/Styles.xaml");

                                    app.SetWindowsSpecificAssectDirectory("Assets");
                            })
#if DEBUG
            .EnableMauiReactorHotReload()
#endif
                            .ConfigureFonts(fonts =>
                            {
                                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                                    fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                            });
                        HogangNoNo_Toy_mauiReactor.Controls.Native.BorderlessEntry.Configure();

                        return builder.Build();
                }
        }
}