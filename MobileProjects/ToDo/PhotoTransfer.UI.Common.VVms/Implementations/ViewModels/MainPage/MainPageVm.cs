using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Library.Commands;
using Library.Types;
using Library.Extensions;
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
using PhotoTransfer.Data.Interfaces.Entities;
using System.Collections.ObjectModel;

namespace ToDo.UI.Common.VVms.Implementations.ViewModels.MainPage
{
	public class MainPageVm : AdvancedPageViewModelBase
	{
		#region Fields

		private readonly IInternalModelService modModelService;
		private ObservableCollection<ToDoItemVm> mvToDos;

		private bool mvIsAdding;
		private AsyncCommand mvAddToDoCommand;
		private AsyncCommand mvSaveToDoCommand;

		#endregion

		#region Commands

		public AsyncCommand AddToDoCommand { get { return mvAddToDoCommand; } }
		public AsyncCommand SaveToDoCommand { get { return mvSaveToDoCommand; } }
		

		#endregion

		#region Ctor

		public MainPageVm(IMainPageDependencyBlock dependencyBlock)
		{
			try
			{
				modModelService = dependencyBlock.ModelService;

				mvToDos = new ObservableCollection<ToDoItemVm>();

				mvAddToDoCommand = new AsyncCommand(OnAddToDoCommand);
				mvSaveToDoCommand = new AsyncCommand(OnSaveToDoCommand);
			}
			catch (Exception ex)
			{

			}

		}

		

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		protected override async Task OnNavigationParameterChanged(object navigationParameter)
		{
			try
			{
				var items = await modModelService.Items<ToDoItem>();

				foreach (var item in items)
				{
					ToDos.Add(new ToDoItemVm(item));
				}
			}
			catch (Exception ex)
			{
			}
		}

		#endregion

		#region Command Execute Handlers

		private async Task OnAddToDoCommand()
		{
			IsAdding = true;
			Name = string.Empty;
		}

		private async Task OnSaveToDoCommand()
		{
			try
			{
				IsAdding = false;

				var newToDoItem = (ToDoItem)await modModelService.CreateEntity<IToDo>();
				newToDoItem.Name = Name;

				await modModelService.SaveEntity<ToDoItem>(newToDoItem);
				
				ToDos.Add(new ToDoItemVm(newToDoItem));
			}
			catch (Exception ex)
			{

			}
		}

		#endregion

		#region Properties

		private string mvName;

		public string Name
		{
			get { return mvName; }
			set { mvName = value; this.OnPropertyChanged(); }
		}
		
		

		public bool IsAdding
		{
			get { return mvIsAdding; }
			set { mvIsAdding = value; this.OnPropertyChanged(); }
		}
		

		public ObservableCollection<ToDoItemVm> ToDos
		{
			get { return mvToDos; }
			set { mvToDos = value; this.OnPropertyChanged(); }
		}
		

		#endregion
	}
}
