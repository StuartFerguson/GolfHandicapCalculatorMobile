using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using HandicapMobile.ManagementAPI;
using HandicapMobile.Pages;
using HandicapMobile.Presenters;
using HandicapMobile.ViewModels;
using HandicapMobile.Views;
using Newtonsoft.Json;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace HandicapMobile.Common
{
    public class Bootstrapper
    {
        /// <summary>
        /// Runs this instance.
        /// </summary>
        public static void Run()
        {
            var unityContainer = new UnityContainer();

            // Presentation registrations
            unityContainer.RegisterType<IMainPagePresenter, MainPagePresenter>(new TransientLifetimeManager());
            unityContainer.RegisterType<IRegisterClubPresenter, RegisterClubPresenter>(new TransientLifetimeManager());

            // View registrations
            unityContainer.RegisterType<IMainPage, MainPage>(new SingletonLifetimeManager());
            unityContainer.RegisterType<IRegisterClubPage1, RegisterClubPage1>(new TransientLifetimeManager());
            unityContainer.RegisterType<IRegisterClubPage2, RegisterClubPage2>(new TransientLifetimeManager());
            unityContainer.RegisterType<IRegisterClubPage3, RegisterClubPage3>(new TransientLifetimeManager());
            unityContainer.RegisterType<IRegisterClubPage4, RegisterClubPage4>(new TransientLifetimeManager());

            // View model registrations
            unityContainer.RegisterType<RegisterClubPage1ViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<RegisterClubPage2ViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<RegisterClubPage3ViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<RegisterClubPage4ViewModel>(new TransientLifetimeManager());

            // Other registrations
            unityContainer.RegisterType<INavigationService, NavigationService>(
                new InjectionConstructor(unityContainer.Resolve<IMainPage>()));
            unityContainer.RegisterType<IAddressLookupService, GetAddressAddressLookupService>(new SingletonLifetimeManager());
            unityContainer.RegisterType<IManagementAPIService, ManagementAPIService>(new SingletonLifetimeManager());

            // Get and deserialize config.json file from Configuration folder.
            var embeddedResourceStream = Assembly.GetAssembly(typeof(IConfiguration)).GetManifestResourceStream("HandicapMobile.Configuration.config.json");
            if (embeddedResourceStream == null)
                return;

            using (var streamReader = new StreamReader(embeddedResourceStream))
            {
                var jsonString = streamReader.ReadToEnd();
                var configuration = JsonConvert.DeserializeObject<Configuration>(jsonString);

                if (configuration == null)
                    return;

                unityContainer.RegisterInstance<IConfiguration>(configuration, new SingletonLifetimeManager());
            }

            App.Container = unityContainer;
        }
    }
}
