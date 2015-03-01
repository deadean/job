using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using PhotoTransfer.Data.Interfaces.Photo;
using PhotoTransfer.Implementations.ViewModels.Photo;
using PhotoTransfer.Messages.Photo;
using PhotoTransfer.UI.Common.Bases.Pages;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using PhotoTransfer.UI.Common.Interfaces.Photo;
using Windows.UI.Xaml.Navigation;

namespace PhotoTransfer.Implementations.Views.Photo
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Page2
	{
		#region Fields

		private readonly IPhotoService modPhotoService;
		private readonly INavigationServiceCommon modNavigationService;

		#endregion

		#region Ctor

		public Page2()
		{
			this.InitializeComponent();
			this.modPhotoService = SimpleIoc.Default.GetInstance<IPhotoService>();
			this.modNavigationService = SimpleIoc.Default.GetInstance<INavigationServiceCommon>();
		}

		#endregion

		#region Private Methods
		#endregion
		#region Public Methods
		#endregion

		#region Protected Methods

		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			Messenger.Default.Register<TakePhotoMessage>(this, OnTakePhotoMessage);

			await this.modPhotoService.GetNewPhoto(PhotoPreview);
		}

		
		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);

			Messenger.Default.Unregister<TakePhotoMessage>(this);

			this.modPhotoService.Dispose();
		}

		#endregion

		#region Dependency Properties
		#endregion
		#region Properties
		#endregion
		#region Commands
		#endregion
		#region Commands Execute Handlers
		#endregion
		#region Commands Can Execute Handlers
		#endregion
		#region Message Handlers

		private async void OnTakePhotoMessage(TakePhotoMessage message)
		{
			IPhotoSource photoSource = await modPhotoService.GetSavedPhoto();
			modNavigationService.Navigate<PagePhotoSavingVm>(photoSource);
		}

		#endregion
		#region Events Handlers
		#endregion

	}
}
