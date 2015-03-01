using ToDo.Data.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services.DataBases.Interfaces
{
	public interface IInternalModelService
	{
		Task SaveEntity<T>(T item) where T : IEntity;
		Task UpdateEntityAsync<T>(T item) where T : IEntity, new();
		Task<T> ItemById<T>(string id) where T : IEntity, new();
		Task<List<T>> Items<T>() where T : IEntity, new();
		Task<T> CreateEntity<T>() where T : IEntity;
	}
}
