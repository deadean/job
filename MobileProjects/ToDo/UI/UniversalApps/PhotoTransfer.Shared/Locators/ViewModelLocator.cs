using GalaSoft.MvvmLight.Ioc;
using ToDo.Implementations.Navigation;
using System;
using System.Diagnostics.CodeAnalysis;
using ToDo.UI.Common.VVms.Implementations.ViewModels.MainPage;
using ToDo.UI.Common.Interfaces.Navigation;
using Microsoft.Practices.ServiceLocation;
using ToDo.UI.UniversalApps.UI.Common.Interfaces.Navigation;
using Windows.UI.Xaml.Controls;
using ToDo.UI.UniversalApps.Services.Implementations.Navigation;
using ToDo.UI.Common.Interfaces.DependencyBlock;
using ToDo.UI.Common.VVms.Implementations.DependencyBlock;
using ToDo.UniversalApps;
using ToDo.Services.DataBases.Interfaces;
using ToDo.UI.DataBases.Implementations.InternalStorage;
using ToDo.UI.DataBases.Interfaces.DataBases;
using ToDo.UI.DataBases.Implementations.ModelService;
using ToDo.UI.UniversalApps.Databases.Implementations.InternalStorage;
using ToDo.Common.Interfaces.Factories;
using ToDo.Common.Implementations.Factories;

namespace ToDo.Locators
{
	public class ViewModelLocator
	{

		#region Fields
		#endregion

		#region Ctor

		static ViewModelLocator()
		{
			try
			{
				ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

				ConfigureNavigationService();

				ConfigureDependencyContainer();
			}
			catch (Exception e)
			{
				throw new Exception(Constants.Constants.ErrorMessages.VIEW_MODEL_LOCATOR_CREATION_ERROR, e);
			}
		}

		#endregion

		#region Private Methods

		private static void ConfigureNavigationService()
		{
			INavigationServiceCommon<Frame> navService = new NavigationServiceCommon<Frame>();

			navService.Register<MainPageVm, MainPage>();

			SimpleIoc.Default.Register<INavigationServiceCommon>(() => navService);
			SimpleIoc.Default.Register<INavigationServiceCommon<Frame>>(() => navService);
			SimpleIoc.Default.Register<INavigationHelper>(() => new NavigationHelper());
		}

		private static void ConfigureDependencyContainer()
		{
			SimpleIoc.Default.Register<MainPageVm>();

			SimpleIoc.Default.Register<IObjectsByTypeFactory, ObjectsByTypeFactory>();
			SimpleIoc.Default.Register<ISQLiteConnection, UniversalSQLiteConnection>();
			SimpleIoc.Default.Register<ISQLiteDataAccessService, SQLiteDataAccessService>();
			SimpleIoc.Default.Register<IInternalStorage, InternalSQLiteStorage>();

			SimpleIoc.Default.Register<IInternalModelService
				, InternalModelService
				>();

			SimpleIoc.Default.Register<IMainPageDependencyBlock, MainPageDependencyBlock>();

		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Cleans up all the resources.
		/// </summary>
		public static void Cleanup()
		{
		}

		#endregion

		#region Protected Methods
		#endregion

		#region Dependency Properties
		#endregion

		#region Properties

		[SuppressMessage("Microsoft.Performance",
				"CA1822:MarkMembersAsStatic",
				Justification = "This non-static member is needed for data binding purposes.")]
		public MainPageVm MainVm
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MainPageVm>();
			}
		}

		#endregion

		#region Commands
		#endregion

		#region Commands Execute Handlers
		#endregion

		#region Commands Can Execute Handlers
		#endregion

		#region Message Handlers
		#endregion

		#region Events Handlers
		#endregion

	}
}
