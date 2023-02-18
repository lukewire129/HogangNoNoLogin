using System;

namespace HogangNoNo_Toy_mauiReactor
{
        internal class Program : MauiApplication
        {
                protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

                static void Main(string[] args)
                {
                        var app = new Program();
                        app.Run(args);
                }
        }
}