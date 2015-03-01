using Library.Types;
using ToDo.Data.Interfaces.Navigation;
using System.Threading.Tasks;

namespace ToDo.UI.Common.Interfaces.Navigation
{
	public interface INavigationServiceCommon
	{
		void Register<TVm, TView>()
			where TVm : IViewModel, INavigableAdvancedViewModelBase
			where TView : class;

		Task Navigate<TVm>()
			where TVm : IViewModel, INavigableAdvancedViewModelBase;

		Task Navigate<TVm>(object parameter)
			where TVm : IViewModel, INavigableAdvancedViewModelBase;

		Task Navigate<TVm, TVmDestination, TArgs>(TVm sender, TArgs parameter)
			where TVmDestination : IViewModel, INavigableAdvancedViewModelBase
			where TVm : class, IViewModel, INavigableAdvancedViewModelBase
			where TArgs : class;

		Task NavigateAsync<TVmSender, TVmDestination>(TVmSender sender)
			where TVmDestination : IViewModel, INavigableAdvancedViewModelBase
			where TVmSender : class, IViewModel, INavigableAdvancedViewModelBase;

	}

	public interface INavigationServiceCommon<T> : INavigationServiceCommon
	{
		void SetNavigationContext(T navigationContext);
	}
}
