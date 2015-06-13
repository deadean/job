using FeduciaTestTask.Services.Interfaces.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Common.Interfaces.DependencyBlocks
{
	public interface IMainPageDependencyBlock:IBaseDependencyBlock
	{
		IWebService WebService { get; }
	}
}
