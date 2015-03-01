using GalaSoft.MvvmLight.Ioc;
using Library.Types;
using ToDo.Data.Interfaces.Navigation;
using ToDo.UI.Common.Implementations.Navigation;
using ToDo.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ToDo.UI.UniversalApps.Services.Implementations.Navigation
{
	public class NavigationServiceCommon<T> : INavigationServiceCommon<T>
		where T : Frame
	{
		#region Fields

		private T modCurrentFrame;
		private readonly Dictionary<Type, Type> modContainer = new Dictionary<Type, Type>();

		#endregion

		#region Ctor

		public NavigationServiceCommon()
		{
		}

		#endregion

		#region Private Methods
		#endregion

		#region Public Methods

		public void Register<TVm, TView>()
			where TVm : IViewModel, INavigableAdvancedViewModelBase
			where TView : class
		{
			if (modContainer.ContainsKey(typeof(TVm)))
				return;

			modContainer.Add(typeof(TVm), typeof(TView));
		}

		async public Task Navigate<TVm>() where TVm : IViewModel, INavigableAdvancedViewModelBase
		{
			await Navigate<TVm>(null);
		}

		async public Task Navigate<TVm>(object parameter) where TVm : IViewModel, INavigableAdvancedViewModelBase
		{
			if (modCurrentFrame == null)
				return;

			try
			{
				if (modContainer.ContainsKey(typeof(TVm)))
				{
					Type navigationSourceView = modContainer[typeof(TVm)];
					var vm = SimpleIoc.Default.GetInstance<TVm>();
					vm.NavigationParameter = parameter;
					modCurrentFrame.Navigate(navigationSourceView, new NavigationArgs(vm, parameter));
				}
			}
			catch (Exception ex) { }
		}

		public void SetNavigationContext(T frame)
		{
			modCurrentFrame = frame;
		}

		public async Task NavigateAsync<TVmSender, TVmDestination>(TVmSender sender)
			where TVmSender : class, IViewModel, INavigableAdvancedViewModelBase
			where TVmDestination : IViewModel, INavigableAdvancedViewModelBase
		{
			await Navigate<TVmDestination>();
		}


		public async Task Navigate<TVm, TVmDestination, TArgs>(TVm sender, TArgs parameter)
			where TVmDestination : IViewModel, INavigableAdvancedViewModelBase
			where TVm : class, IViewModel, INavigableAdvancedViewModelBase
			where TArgs : class
		{
			await Navigate<TVmDestination>(parameter);
		}


		#endregion

		#region Protected Methods
		#endregion

		#region Dependency Properties
		#endregion

		#region Properties
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
