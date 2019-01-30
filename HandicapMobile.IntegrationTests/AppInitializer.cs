using System;
using System.Diagnostics;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace HandicapMobile.IntegrationTests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {               
                return ConfigureApp.Android.InstalledApp("com.golfhandicapping.mobile").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}