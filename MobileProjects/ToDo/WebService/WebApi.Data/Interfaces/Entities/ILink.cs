using System;
using WebApi.Data.Entities.Interfaces;

namespace WebApi.Data.Interfaces.Entities
{
	public interface ILink : IEntity
	{
		IEntity Container { get; }

		string LinkType { get; }

		DateTime LinkDate { get; }

		bool IsProtected { get; }
	}
}
