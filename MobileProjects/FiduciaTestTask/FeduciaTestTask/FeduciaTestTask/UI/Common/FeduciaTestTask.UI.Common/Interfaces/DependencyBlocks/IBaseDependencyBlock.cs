using FeduciaTestTask.Services.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Common.Interfaces.DependencyBlocks
{
	public interface IBaseDependencyBlock
	{
		ICustomNavigationService NavigationService { get; }
	}
}
