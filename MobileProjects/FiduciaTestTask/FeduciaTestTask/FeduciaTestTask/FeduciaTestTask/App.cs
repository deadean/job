using FeduciaTestTask.Services.Interfaces.Navigation;
using FeduciaTestTask.Services.Interfaces.WebService;
using FeduciaTestTask.UI.Common.Implementations;
using FeduciaTestTask.UI.Common.Interfaces.DependencyBlocks;
using FeduciaTestTask.UI.Common.Views.Implementations.Views.Pages;
using FeduciaTestTask.UI.Common.VVms.Implementations.DependenciesBlocks;
using FeduciaTestTask.UI.Common.VVms.Implementations.ViewModels.Pages;
using FeduciaTestTask.UI.Services.Implementations.WebService;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace FeduciaTestTask
{
	public class App : Application
	{
		#region Ctor

		public App()
		{
			try
			{
				ConfigureDependencyResolves();
				Initialize();
			}
			catch (Exception ex) { }
		}

		#endregion

		#region Private Methods

		private void Initialize()
		{
			var mainView = new MainPage();

			Resolver.Resolve<IDependencyContainer>()
				.Register<INavigationService>(t => new NavigationService(mainView.Navigation));

			SimpleIoc.Default.Register<ICustomNavigationService, CustomNavigationService>();
			SimpleIoc.Default.Register<INavigationService>(() => { return Resolver.Resolve<INavigationService>();} );

			ConfigureNavigationService();

			mainView.BindingContext = SimpleIoc.Default.GetInstance<MainPageVm>();
			MainPage = new NavigationPage(mainView);
		}

		private void ConfigureDependencyResolves()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			ConfigureDependenciesByPlatform();

			ConfigureDependenciesByViewModels();

			ConfigureDependenciesByDependencyService();

			ConfigureDependencies();

			ConfigureDependencyBlocks();

			ConfigureLocatorStrategies();
		}

		private void ConfigureLocatorStrategies()
		{
			//SimpleIoc.Default.Register<IMainPageLocatorStrategy<MainPageVm>, MainPageLocatorStrategy<MainPageVm>>();
		}

		private static void ConfigureDependencyBlocks()
		{
			SimpleIoc.Default.Register<IMainPageDependencyBlock, MainPageDependencyBlock>();
			SimpleIoc.Default.Register<IModificationsPageDependnecyBlock, ModificationsPageDependencyBlock>();
		}

		private static void ConfigureDependencies()
		{
			//SimpleIoc.Default.Register<IObjectsByTypeFactory, ObjectsByTypeFactory>();
			SimpleIoc.Default.Register<IWebService, WebService>();
		}

		private static void ConfigureDependenciesByDependencyService()
		{
			//SimpleIoc.Default.Register<IWebService>(() => DependencyService.Get<IWebService>());
			//SimpleIoc.Default.Register<IDialogService>(() => DependencyService.Get<IDialogService>());
		}

		private static void ConfigureDependenciesByPlatform()
		{
		}

		private static void ConfigureDependenciesByViewModels()
		{
			SimpleIoc.Default.Register<MainPageVm>();
		}

		#region Navigation Mapping

		private void ConfigureNavigationService()
		{
			ViewFactory.Register<MainPage, MainPageVm>();
			ViewFactory.Register<ModificationsPage, ModificationsPageVm>();
			ViewFactory.Register<ModificationPage, ModificationPageVm>();

			//var navService = ServiceLocator.Current.GetInstance<INavigationServiceCommon<XamarinNavigationContext<ContentPage>>>();

			//RegisterNavigationMaps(navService);
		}

		#endregion

		#endregion

		#region Protected Methods

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		#endregion

	}
}
