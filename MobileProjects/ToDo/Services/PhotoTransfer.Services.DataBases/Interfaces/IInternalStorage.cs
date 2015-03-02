using ToDo.Data.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services.DataBases.Interfaces
{
	public interface IInternalStorage
	{
		Task Save<T>(T item)
			where T : IEntity, new();

		Task Update<T>(T item)
			where T : IEntity, new();

		Task<List<T>> Items<T>()
			where T : IEntity, new();

		Task<T> ItemById<T>(string id)
			where T : IEntity, new();

		Task Remove<T>(T item)
			where T : IEntity, new();

	}
}
