﻿using GalaSoft.MvvmLight.Ioc;
using Library.Types;
using ToDo.Data.Interfaces.Navigation;
using ToDo.UI.Common.Implementations.Navigation;
using ToDo.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDo.WP.Services.Implementations.Navigation
{
	public class NavigationServiceCommon<T> : INavigationServiceCommon<T>
		where T : INavigationContext<ContentPage>
	{
		#region Fields

		private T modNavigationContext;
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
			if (modNavigationContext == null)
				return;

			if (modContainer.ContainsKey(typeof(TVm)))
			{
				Type navigationSourceView = modContainer[typeof(TVm)];
				TVm vm = SimpleIoc.Default.GetInstance<TVm>();
				vm.NavigationParameter = parameter;
				ContentPage view = Activator.CreateInstance(navigationSourceView) as ContentPage;
				view.BindingContext = vm;
				await modNavigationContext.PushAsync(view);
			}
		}


		public void SetNavigationContext(T navigationContext)
		{
			modNavigationContext = navigationContext;
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









		public Task NavigateAsync<TVmSender, TVmDestination>(TVmSender sender)
			where TVmDestination : IViewModel, INavigableAdvancedViewModelBase
			where TVmSender : class, IViewModel, INavigableAdvancedViewModelBase
		{
			return this.Navigate<TVmDestination>();
		}


		public Task Navigate<TVm, TVmDestination, TArgs>(TVm sender, TArgs parameter)
			where TVmDestination : IViewModel, INavigableAdvancedViewModelBase
			where TVm : class, IViewModel, INavigableAdvancedViewModelBase
			where TArgs : class
		{
			return this.Navigate<TVmDestination>(parameter);
		}
	}
}
