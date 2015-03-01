using GalaSoft.MvvmLight.Messaging;
using Library.Commands;
using ToDo.Messages.Photo;
using ToDo.UI.Common.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.UI.UniversalApps.VVms.Implementations.ViewModels.Photo
{
	public class Page2Vm : AdvancedPageViewModelBase
	{
		#region Fields

		private readonly DelegateCommand mvTakePhotoCommand;

		#endregion
		#region Ctor

		public Page2Vm()
		{
			mvTakePhotoCommand = new DelegateCommand(OnTakePhoto);
		}

		#endregion
		#region Private Methods
		#endregion
		#region Public Methods
		#endregion
		#region Protected Methods

		#endregion
		#region Dependency Properties
		#endregion
		#region Properties
		#endregion
		#region Commands

		public DelegateCommand TakePhotoCommand
		{
			get { return mvTakePhotoCommand; }
		}

		#endregion
		#region Commands Execute Handlers

		private void OnTakePhoto()
		{
			Messenger.Default.Send<TakePhotoMessage>(null);
		}

		#endregion
		#region Commands Can Execute Handlers
		#endregion
		#region Message Handlers
		#endregion
		#region Events Handlers
		#endregion
	}
}
