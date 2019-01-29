using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using HandicapMobile.Pages;
using HandicapMobile.Pages.SignIn;
using HandicapMobile.Pages.Signup;
using HandicapMobile.Presenters;
using HandicapMobile.Presenters.SignIn;
using HandicapMobile.Presenters.Signup;
using HandicapMobile.Services;
using HandicapMobile.ViewModels.Signup;
using HandicapMobile.Views;
using HandicapMobile.Views.SignIn;
using HandicapMobile.Views.Signup;
using ManagementAPI.Service.Client;
using Newtonsoft.Json;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using SignupPresenter = HandicapMobile.Presenters.Signup.SignupPresenter;

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

            // Switch the url based on the compilation values
            String managementAPIUri = String.Empty;
            String securityServiceAPIUri = String.Empty;
            #if INTEGRATION
                managementAPIUri = "http://192.168.1.132:9000";
                securityServiceAPIUri = "http://192.168.1.132:9000";
            #else
            #if DEVELOPMENT
                managementAPIUri = "http://192.168.1.132:5000";
                securityServiceAPIUri = "http://192.168.1.132:5001";
            #else
                managementAPIUri = "http://192.168.1.132:5000";
                securityServiceAPIUri = "http://192.168.1.132:5001";
            #endif
            #endif

            var configuration = new Configuration
            {
                ManagementAPI = managementAPIUri,
                SecurityServiceAPI = securityServiceAPIUri
            };
        
            unityContainer.RegisterInstance<IConfiguration>(configuration, new SingletonLifetimeManager());

            // Presentation registrations
            unityContainer.RegisterType<IMainPagePresenter, MainPagePresenter>(new TransientLifetimeManager());
            unityContainer.RegisterType<ISignupPresenter, SignupPresenter>(new TransientLifetimeManager());
            unityContainer.RegisterType<ISignInPresenter, SignInPresenter>(new TransientLifetimeManager());

            // View registrations
            unityContainer.RegisterType<IMainPage, MainPage>(new SingletonLifetimeManager());
            unityContainer.RegisterType<ISignupPage1, SignupPage1>(new TransientLifetimeManager());
            unityContainer.RegisterType<ISignupPageGolfClubAdministrator1, SignupPageGolfClubAdministrator1>(new TransientLifetimeManager());
            unityContainer.RegisterType<ISignInPage, SignInPage>(new TransientLifetimeManager());
            unityContainer.RegisterType<ISignedInGolfClubAdministratorPage, SignedInGolfClubAdministratorPage>(new TransientLifetimeManager());

            // View model registrations
            unityContainer.RegisterType<SignupPageGolfClubAdministrator1ViewModel>(new TransientLifetimeManager());
            unityContainer.RegisterType<SignInPageViewModel>(new TransientLifetimeManager());

            // Other registrations
            unityContainer.RegisterType<INavigationService, NavigationService>(new InjectionConstructor(unityContainer.Resolve<IMainPage>()));
            unityContainer.RegisterType<IGolfClubClient, GolfClubClient>(new SingletonLifetimeManager());
            unityContainer.RegisterType<ISecurityServiceClient, SecurityServiceClient>(new SingletonLifetimeManager());

            HttpClient httpClient = new HttpClient();
            unityContainer.RegisterInstance<HttpClient>(httpClient, new SingletonLifetimeManager());
            
            unityContainer.RegisterType<Func<String, String>>(new InjectionFactory(c => 
                new Func<String, String>((configSetting) =>
                {
                    var config = unityContainer.Resolve<IConfiguration>();

                    if (configSetting == "ManagementAPI")
                    {
                        return config.ManagementAPI;
                    }
                    else if (configSetting == "SecurityServiceAPI")
                    {
                        return config.SecurityServiceAPI;
                    }
                    else
                    {
                        return String.Empty;
                    }
                })));
            
            App.Container = unityContainer;
        }
    }
}
