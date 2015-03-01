using ToDo.Services.DataBases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.UI.Common.Interfaces.DependencyBlock
{
	public interface IMainPageDependencyBlock
	{
		IInternalModelService ModelService { get; }
	}
}
