using FeduciaTestTask.FeduciaTestTask.Data.Interfaces.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Data.Implementations.Entities.Web
{
	public class Modification:IModification
	{

		#region Fields

		#endregion

		#region Properties

		public string CompanyCode { get; set; }

		public string Description { get; set; }

		public string KeyName { get; set; }

		public string ID { get; set; }

		public int ModId { get; set; }

		public IEnumerable<string> ModVariables { get; set; }

		public string Name { get; set; }

		public bool RequiresLookupUDF { get; set; }

		#endregion

		#region Ctor

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion
		
	}
}
