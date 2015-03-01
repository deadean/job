using System;
using WebApi.Data.Entities.Interfaces;
using WebApi.Data.Interfaces.Entities;
using WebApi.Web.Data.Implementations.Entities;

namespace WebApi.Data.Implementations.Entities
{
	public class Link : EntityBaseImplementation, ILink
	{
		private readonly IEntity mvContainer;
		private readonly string mvLinkType;
		private readonly DateTime mvLinkDate;
		private readonly bool mvIsProtected;

		#region Ctor

		public Link(string masterId, IEntity container, string linkType, bool isProtected = false) : base()
		{
			ID = masterId;
			mvContainer = container;
			mvLinkType = linkType;
			mvIsProtected = isProtected;
		}

		#endregion

		#region Properties
		
		public IEntity Container 
		{
			get 
			{
				return mvContainer;
			}
		}

		public DateTime LinkDate 
		{
			get
			{
				return mvLinkDate;
			}
		}

		public string LinkType 
		{
			get
			{
				return mvLinkType;
			}
		}

		public bool IsProtected 
		{
			get
			{
				return mvIsProtected;
			}
		}

		#endregion

		#region Static methods

		public static ILink CreateNewChildLink(string masterId, IEntity container)
		{
			return new Link(masterId, container, Constants.ConstantsRecords.LinkTypes.CHILD_LINK, false);
		}

		#endregion
	}
}
