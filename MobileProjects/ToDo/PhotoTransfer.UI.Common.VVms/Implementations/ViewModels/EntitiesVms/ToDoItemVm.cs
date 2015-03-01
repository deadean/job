using Library.Types;
using Library.Extensions;
using PhotoTransfer.Data.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.EntitiesVms
{
	public sealed class ToDoItemVm : AdvancedViewModelBase
	{

		private readonly IToDo modTodo;

		public ToDoItemVm(IToDo todo)
		{
			modTodo = todo;

			Name = modTodo.Name;
		}


		private string mvName;

		public string Name
		{
			get { return mvName; }
			set { mvName = value; this.OnPropertyChanged(); }
		}
		

	}
}
