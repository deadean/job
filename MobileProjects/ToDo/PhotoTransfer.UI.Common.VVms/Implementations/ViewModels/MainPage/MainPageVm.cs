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
		private ToDoItemVm modEditedToDo;
		private AsyncCommand mvAddToDoCommand;
		private AsyncCommand mvSaveToDoCommand;
		private AsyncCommand mvRemoveToDoCommand;
		private AsyncCommand mvEditToDoCommand;
		private AsyncCommand mvCloseToDoCommand;

		#endregion

		#region Commands

		public AsyncCommand AddToDoCommand { get { return mvAddToDoCommand; } }
		public AsyncCommand SaveToDoCommand { get { return mvSaveToDoCommand; } }
		public AsyncCommand RemoveCommand { get { return mvRemoveToDoCommand; } }
		public AsyncCommand EditCommand { get { return mvEditToDoCommand; } }
		public AsyncCommand CloseCommand { get { return mvCloseToDoCommand; } }
		

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
				mvRemoveToDoCommand = new AsyncCommand(OnRemoveCommand);
				mvEditToDoCommand = new AsyncCommand(OnEditCommand);
				mvCloseToDoCommand = new AsyncCommand(OnCloseCommand);
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

				if (modEditedToDo != null)
				{
					modEditedToDo.Name = Name;
					await modModelService.UpdateEntityAsync<ToDoItem>(modEditedToDo.ToDo);
					modEditedToDo = null;
					return;
				}

				var newToDoItem = (ToDoItem)await modModelService.CreateEntity<IToDo>();
				newToDoItem.Name = Name;

				await modModelService.SaveEntity<ToDoItem>(newToDoItem);
				
				ToDos.Add(new ToDoItemVm(newToDoItem));
			}
			catch (Exception ex)
			{
				var test = ex.Message;
			}
		}

		private async Task OnRemoveCommand()
		{
			try
			{
				if (SelectedToDo == null)
					return;

				var selectedToDo = SelectedToDo.ToDo;

				await modModelService.Remove<ToDoItem>((ToDoItem)selectedToDo);

				ToDos.Remove(SelectedToDo);
			}
			catch (Exception ex)
			{

			}
		}

		private async Task OnEditCommand()
		{
			try
			{
				if (SelectedToDo == null)
					return;


				modEditedToDo = SelectedToDo;

				IsAdding = true;
				Name = SelectedToDo.Name;
			}
			catch (Exception ex)
			{

			}
		}

		private async Task OnCloseCommand()
		{
			try
			{
				IsAdding = false;
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

		private ToDoItemVm mvSelectedToDo;

		public ToDoItemVm SelectedToDo
		{
			get { return mvSelectedToDo; }
			set { mvSelectedToDo = value; IsMenuOpen = value != null; this.OnPropertyChanged(); }
		}

		private bool mvIsMenuOpen;

		public bool IsMenuOpen
		{
			get { return mvIsMenuOpen; }
			set { mvIsMenuOpen = value; this.OnPropertyChanged(); }
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
