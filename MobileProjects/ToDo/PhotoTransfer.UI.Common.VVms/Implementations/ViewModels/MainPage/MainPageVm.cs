using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Library.Commands;
using Library.Types;
using ToDo.Common.Implementations.Extensions;
using ToDo.Services.DataBases.Interfaces;
using ToDo.UI.Common.Bases;
using ToDo.UI.Common.Interfaces.DependencyBlock;
using ToDo.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Services.Media;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.EntitiesVms;
using ToDo.UI.Data.Implementations.Entities;

namespace ToDo.UI.Common.VVms.Implementations.ViewModels.MainPage
{
	public class MainPageVm : AdvancedPageViewModelBase
	{
		#region Fields

		private readonly IInternalModelService modModelService;
		private IList<ToDoItemVm> mvToDos;

		#endregion

		#region Commands

		#endregion

		#region Ctor

		public MainPageVm(IMainPageDependencyBlock dependencyBlock)
		{
			modModelService = dependencyBlock.ModelService;

			mvToDos = new List<ToDoItemVm>();

			mvToDos.Add(new ToDoItemVm(new ToDoItem() { Name = "Test" }));
			mvToDos.Add(new ToDoItemVm(new ToDoItem() { Name = "Test" }));
			mvToDos.Add(new ToDoItemVm(new ToDoItem() { Name = "Test" }));
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion

		#region Command Execute Handlers

		#endregion

		#region Properties


		public IList<ToDoItemVm> ToDos
		{
			get { return mvToDos; }
			set { mvToDos = value; }
		}
		

		#endregion
	}
}
