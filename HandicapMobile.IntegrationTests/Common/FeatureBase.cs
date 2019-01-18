using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace HandicapMobile.IntegrationTests.Common
{
    public class FeatureBase
    {
        protected static IApp app;
        protected Platform platform;
        protected String iOSSimulator;
        protected Boolean resetDevice;

        public FeatureBase (Platform platform, Boolean resetDevice = true)
        {
            this.iOSSimulator = iOSSimulator;
            this.platform = platform;
            this.resetDevice = resetDevice;
        }

        [BeforeScenario()]
        public void BeforeEachTest ()
        {
            app = AppInitializer.StartApp(platform, resetDevice);
            FeatureContext.Current.Add("App", app);
        }

    }


}
