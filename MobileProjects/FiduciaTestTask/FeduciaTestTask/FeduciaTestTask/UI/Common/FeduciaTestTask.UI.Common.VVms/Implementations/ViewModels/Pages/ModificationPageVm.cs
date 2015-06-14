using FeduciaTestTask.FeduciaTestTask.Data.Interfaces.Entities.Web;
using FeduciaTestTask.UI.Common.Interfaces.ViewModels;
using Library.Types.Implemantions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class ModificationPageVm:ViewModelBase, IModificationPageVm
	{

		#region Fields

		private IModification _modification;

		#endregion

		#region Properties

		public IModification Modification { get { return _modification; } }

		#endregion

		#region Ctor

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion

		protected override void Initialize(object parameter)
		{
			_modification = parameter as IModification;
			if (_modification == null)
				return;

			this.NotifyPropertyChanged("Modification");
		}
	}
}
