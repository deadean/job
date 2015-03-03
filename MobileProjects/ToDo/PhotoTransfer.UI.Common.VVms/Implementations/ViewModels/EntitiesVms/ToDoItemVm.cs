using Library.Types;
using Library.Extensions;
using PhotoTransfer.Data.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.UI.Data.Implementations.Entities;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.EntitiesVms
{
	public sealed class ToDoItemVm : AdvancedViewModelBase
	{

		private ToDoItem modTodo;

		public ToDoItemVm(ToDoItem todo)
		{
			modTodo = todo;

			Name = modTodo.Name;
		}

		public ToDoItem ToDo { get { return modTodo; } }


		private string mvName;

		public string Name
		{
			get { return mvName; }
			set { mvName = value; modTodo.Name = value; this.OnPropertyChanged(); }
		}
		

	}
}
