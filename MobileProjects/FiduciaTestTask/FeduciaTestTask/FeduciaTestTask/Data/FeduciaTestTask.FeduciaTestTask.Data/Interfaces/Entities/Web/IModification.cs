using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.FeduciaTestTask.Data.Interfaces.Entities.Web
{
	public interface IModification
	{
		string CompanyCode { get; set; }
		string Description { get; set; }
		string KeyName { get; set; }
		string ID { get; set; }
		int ModId { get; set; }
		IEnumerable<string> ModVariables { get; set; }
		string Name { get; set; }
		bool RequiresLookupUDF { get; set; }
	}
}
