using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views;

namespace MauiAndroidBlueBarReproductionApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            Window?.AddFlags(WindowManagerFlags.Fullscreen);

            Activity activity = this;
            if (activity == null)
                return;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            {
#pragma warning disable CA1416 // Supported on: 'android' 30.0 and later
                activity.Window.SetDecorFitsSystemWindows(false);
                activity.Window.InsetsController?.Hide(WindowInsets.Type.SystemBars());
                if (activity.Window.InsetsController != null)
                    activity.Window.InsetsController.SystemBarsBehavior = (int)WindowInsetsControllerBehavior.ShowTransientBarsBySwipe;
#pragma warning restore CA1416 // Supported on: 'android' 30.0 and later
            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                SystemUiFlags systemUiVisibility = (SystemUiFlags)activity.Window.DecorView.SystemUiVisibility;
                systemUiVisibility |= SystemUiFlags.HideNavigation;
                systemUiVisibility |= SystemUiFlags.Immersive;
                activity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }
    }
}
