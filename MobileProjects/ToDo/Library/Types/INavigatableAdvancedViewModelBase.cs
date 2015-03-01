namespace Library.Types
{
	public interface INavigableAdvancedViewModelBase
	{
		object NavigationParameter { set; }
		void SetNavigationHelper(INavigationHelper navigationHelper);
	}
}
