using GalaSoft.MvvmLight.Ioc;
using ToDo.Data.Interfaces.Navigation;
using ToDo.UI.UniversalApps.UI.Common.Implementations.Navigation;
using ToDo.UI.UniversalApps.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ToDo.Common.Implementations.Extensions;
using ToDo.UI.Common.Interfaces.Navigation;

namespace ToDo.UI.UniversalApps.UI.Common.Bases.Pages
{
	public abstract class PageBase : Page
	{
		#region Fields

		private readonly INavigationHelper modNavigationHelper;

		private const string StateKey = "State";

		#endregion

		#region Ctor

		protected PageBase()
		{
			modNavigationHelper = SimpleIoc.Default.GetInstance<INavigationHelper>();
			modNavigationHelper.SetNavigableContext(this);
			modNavigationHelper.LoadState += NavigationHelperLoadState;
			modNavigationHelper.SaveState += NavigationHelperSaveState;
		}

		#endregion

		#region Private Methods
		#endregion

		#region Public Methods

		#endregion

		#region Protected Methods

		protected virtual void LoadState(object state)
		{
		}

		protected virtual object SaveState()
		{
			return null;
		}

		protected void NavigationHelperLoadState(object sender, LoadStateEventArgs e)
		{
			if (e.PageState != null
					&& e.PageState.ContainsKey(StateKey))
			{
				LoadState(e.PageState[StateKey]);
			}
		}

		protected void NavigationHelperSaveState(object sender, SaveStateEventArgs e)
		{
			if (e.PageState == null)
			{
				throw new InvalidOperationException("PageState is null");
			}

			if (e.PageState.ContainsKey(StateKey))
			{
				e.PageState.Remove(StateKey);
			}

			var state = SaveState();

			if (state != null)
			{
				e.PageState.Add(StateKey, state);
			}
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			modNavigationHelper.OnNavigatedFrom(e);
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			e.Parameter.WithType<INavigationArgs>(x =>
			{
				x.ViewModel.SetNavigationHelper(this.modNavigationHelper);
				this.DataContext = x.ViewModel;
			});

			modNavigationHelper.OnNavigatedTo(e);
		}

		#endregion

		#region Dependency Properties
		#endregion

		#region Properties

		public INavigationHelper NavigationHelper
		{
			get
			{
				return modNavigationHelper;
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
