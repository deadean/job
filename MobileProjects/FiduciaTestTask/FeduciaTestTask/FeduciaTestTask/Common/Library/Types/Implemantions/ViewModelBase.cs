using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Forms.Mvvm;

namespace Library.Types.Implemantions
{
	public abstract class ViewModelBase : ViewModel, IViewModel
	{
		protected abstract void Initialize(object parameter);
	}
}
