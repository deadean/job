using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.FeduciaTestTask.Data.Interfaces.Entities.Web
{
	public interface IModifications
	{
		string CurrentPage { get; set; }
		string ErrorDescription { get; set; }
		int TotalCount { get; set; }

		IEnumerable<IModification> Items { get; }
	}
}
