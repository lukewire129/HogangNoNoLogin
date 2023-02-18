using Android.App;
using Android.Content.PM;
using Android.OS;

namespace HogangNoNo_Toy_mauiReactor
{
        [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
        public class MainActivity : MauiAppCompatActivity
        {
        }
}