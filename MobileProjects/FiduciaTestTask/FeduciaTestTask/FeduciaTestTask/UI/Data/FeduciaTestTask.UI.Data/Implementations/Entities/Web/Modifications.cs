using FeduciaTestTask.FeduciaTestTask.Data.Interfaces.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Data.Implementations.Entities.Web
{
	public class Modifications:IModifications
	{
		public string CurrentPage { get; set; }
		public string ErrorDescription { get; set; }
		public int TotalCount { get; set; }

		public IEnumerable<Modification> RecordList { get; set; }


		public IEnumerable<IModification> Items
		{
			get { return RecordList; }
		}
	}
}
