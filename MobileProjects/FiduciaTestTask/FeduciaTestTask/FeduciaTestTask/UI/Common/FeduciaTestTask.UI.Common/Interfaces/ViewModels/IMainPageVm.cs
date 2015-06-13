using FeduciaTestTask.UI.Common.Interfaces.Bases;
using Library.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Common.Interfaces.ViewModels
{
	public interface IMainPageVm:IPageVm
	{
		AsyncCommand SendRequestCommand { get; }
	}
}
