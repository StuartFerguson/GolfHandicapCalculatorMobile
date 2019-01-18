using System;
using System.Diagnostics;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace HandicapMobile.IntegrationTests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform, Boolean resetDevice)
        {
            if (platform == Platform.Android)
            {
                //if (resetDevice) {
                //    ResetEmulator ();
                //}
                
                //return ConfigureApp.Android.ApkFile("../../../HandicapMobile/HandicapMobile.Android/bin/Debug/com.golfhandicapping.mobile.apk")
                //    .StartApp();               
                return ConfigureApp.Android.InstalledApp("com.golfhandicapping.mobile").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }

        static void ResetEmulator()
        {
            //TODO : Generalize this
            //TODO : Make this work on Windows?

            if (TestEnvironment.Platform.Equals(TestPlatform.Local))
            {
                var eraseProcess = Process.Start ("c:\\Program Files (x86)\\Android\\android-sdk\\platform-tools\\adb", "shell pm uninstall com.golfhandicapping.mobile.apk");
                eraseProcess.WaitForExit ();
            }
        }
    }
}