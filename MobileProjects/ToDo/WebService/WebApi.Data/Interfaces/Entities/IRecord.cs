using System;
using System.Collections.Generic;
using WebApi.Data.Entities.Interfaces;

namespace WebApi.Data.Interfaces.Entities
{
	public interface IRecord : IEntity
	{
		DateTime DateInserted { get; set; }

		DateTime EntryDate { get; set; }

		DateTime BeginDate { get; set; }

		DateTime EndDate { get; set; }

		DateTime ChangeDate { get; set; }

		string VUBClass { get; set; }

		string VUBSubClass { get; set; }

		string ClassType { get; }

		string Name { get; set; }

		string Remark { get; }

		void AddLinkToParent(string parentID);

		IEnumerable<ILink> Links { get; }
	}
}
