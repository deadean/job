using FeduciaTestTask.FeduciaTestTask.Data.Interfaces.Entities.Web;
using FeduciaTestTask.Services.Interfaces.Navigation;
using FeduciaTestTask.UI.Common.Interfaces.DependencyBlocks;
using FeduciaTestTask.UI.Common.Interfaces.ViewModels;
using Library.Commands;
using Library.Types.Implemantions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FeduciaTestTask.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class ModificationsPageVm : ViewModelBase, IModificationsPageVm
	{

		#region Fields

		private IModifications _modifications;

		#endregion

		#region Properties

		public ObservableCollection<IModification> ModificationItems { get; set; }

		private string _currentPage;

		public string CurrentPage
		{
			get { return _currentPage; }
			set { _currentPage = value; this.NotifyPropertyChanged("CurrentPage"); }
		}

		private string _errorDescription;

		public string ErrorDescription
		{
			get { return _errorDescription; }
			set { _errorDescription = value; this.NotifyPropertyChanged("ErrorDescription");}
		}

		private int _totalCount;

		public int TotalCount
		{
			get { return _totalCount; }
			set { _totalCount = value; this.NotifyPropertyChanged("TotalCount");}
		}

		public ICustomNavigationService NavigationServiceCustom
		{
			get;
			private set;
		}

		#endregion

		#region Commads

		public ICommand ItemClickCommand { get; private set; }

		#endregion

		#region Ctor

		public ModificationsPageVm()
		{
			ItemClickCommand = new AsyncCommand<IModification>(OnItemClickCommand);
			NavigationServiceCustom = ServiceLocator.Current.GetInstance<IModificationsPageDependnecyBlock>().NavigationService;
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion

		#region Command Execute Handlers

		private async Task OnItemClickCommand(IModification arg)
		{
			NavigationServiceCustom.NavigateTo<ModificationPageVm>(arg);
		}

		#endregion

		protected override void Initialize(object parameter)
		{
			_modifications = parameter as IModifications;
			if (_modifications == null)
				return;

			ModificationItems = new ObservableCollection<IModification>(_modifications.Items);
			this.NotifyPropertyChanged("ModificationItems");

			this.ErrorDescription = _modifications.ErrorDescription;
			this.TotalCount = _modifications.TotalCount;
			this.CurrentPage = _modifications.CurrentPage;
		}

		
	}
}
