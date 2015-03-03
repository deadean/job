using GalaSoft.MvvmLight.Ioc;
using ToDo.Services.DataBases.Interfaces;
using ToDo.UI.Common.Interfaces.DependencyBlock;
using ToDo.UI.Common.Interfaces.Navigation;
using ToDo.UI.Common.VVms.Implementations.DependencyBlock;
using ToDo.UI.Common.VVms.Implementations.ViewModels.MainPage;
using ToDo.UI.DataBases.Implementations.InternalStorage;
using ToDo.UI.Data.Implementations.Navigation;
using ToDo.WP.Services.Implementations.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ToDo.UI.DataBases.Implementations.ModelService;
using ToDo.UI.DataBases.Interfaces.DataBases;
using ToDo.Common.Interfaces.Factories;
using ToDo.Common.Implementations.Factories;

namespace ToDo
{	
	public class App : Application
	{
		public App()
		{
			try
			{
				ConfigureNavigationService();
				ConfigureDependencyResolves();

				var view = new ToDo.UI.Common.VVms.Implementations.Views.MainPage.MainPage();
				view.BindingContext = SimpleIoc.Default.GetInstance<MainPageVm>();

				MainPage = new NavigationPage(view);

				SimpleIoc.Default.GetInstance<INavigationServiceCommon<XamarinNavigationContext<ContentPage>>>()
					.SetNavigationContext(new XamarinNavigationContext<ContentPage>(MainPage as NavigationPage));

			}
			catch (Exception ex)
			{

			}
		}

		private void ConfigureNavigationService()
		{
			//INavigationServiceCommon<XamarinNavigationContext<ContentPage>> navService =
			//	new NavigationServiceCommon<XamarinNavigationContext<ContentPage>>();

			INavigationServiceCommon<XamarinNavigationContext<ContentPage>> navService =
				new NavigationServiceMessagingCenter<XamarinNavigationContext<ContentPage>>();

			navService.Register<MainPageVm, ToDo.UI.Common.VVms.Implementations.Views.MainPage.MainPage>();

			SimpleIoc.Default.Register<INavigationServiceCommon>(() => navService);
			SimpleIoc.Default.Register<INavigationServiceCommon<XamarinNavigationContext<ContentPage>>>(() => navService);
		}

		private void ConfigureDependencyResolves()
		{
			SimpleIoc.Default.Register<MainPageVm>();

			SimpleIoc.Default.Register<IObjectsByTypeFactory, ObjectsByTypeFactory>();
			
			SimpleIoc.Default.Register<ISQLiteConnection>(() => DependencyService.Get<ISQLiteConnection>());
			SimpleIoc.Default.Register<ISQLiteDataAccessService, SQLiteDataAccessService>();
			SimpleIoc.Default.Register<IInternalStorage, InternalSQLiteStorage>();

			SimpleIoc.Default.Register<IInternalModelService
				, InternalModelService
				>();

			SimpleIoc.Default.Register<IMainPageDependencyBlock, MainPageDependencyBlock>();
		}

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
	}
}
