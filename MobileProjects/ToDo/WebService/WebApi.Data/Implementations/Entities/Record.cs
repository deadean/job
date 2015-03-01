using System;
using System.Collections.Generic;
using WebApi.Data.Interfaces.Entities;
using WebApi.Web.Data.Implementations.Entities;

namespace WebApi.Data.Implementations.Entities
{
	public abstract class Record : EntityBaseImplementation, IRecord
	{
		private readonly List<ILink> mvLinks = new List<ILink>();
		private readonly string mvClassType;

		protected Record(string name, string remark, string classType)
		{
			Name = name;
			Remark = remark;
			mvClassType = classType;
		}

		public string Name { get; set; }

		public string Remark { get; set; }

		public DateTime EntryDate { get; set; }

		public DateTime BeginDate { get; set; }

		public DateTime EndDate { get; set; }

		public DateTime ChangeDate { get; set; }

		public DateTime DateInserted { get; set; }

		public string VUBClass { get; set; }

		public string VUBSubClass { get; set; }

		public string ClassType
		{
			get
			{
				return mvClassType;
			}
		}

		public void AddLinkToParent(string parentID)
		{
			mvLinks.Add(Link.CreateNewChildLink(parentID, this));
		}

		public IEnumerable<ILink> Links
		{
			get 
			{
				return mvLinks.AsReadOnly();
			}
		}
	}
}
