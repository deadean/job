using GalaSoft.MvvmLight.Ioc;
using ToDo.Services.DataBases.Interfaces;
using ToDo.UI.Common.VVms.Implementations.ViewModels.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDo.UI.Common.VVms.Implementations.Views.MainPage
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			//MessagingCenter.Subscribe<MainPageVm>(this
			//		, "PageSelectPhotoVm"
			//		, (sender) =>
			//		{
			//			var res = new PageSelectPhoto();
			//			res.BindingContext = new PageSelectPhotoVm
			//			(
			//				SimpleIoc.Default.GetInstance<IInternalModelService>(),
			//				SimpleIoc.Default.GetInstance<IImageLoader>()
			//			) { NavigationParameter = null};
			//			Navigation.PushAsync(res);
			//		});

			//MessagingCenter.Subscribe<SaveCommentsPageVm>(this
			//		, "MainPageVm"
			//		, (sender) =>
			//		{
			//			Navigation.PopToRootAsync();
			//		});

			//MessagingCenter.Subscribe<PagePhotoEditingVm>(this
			//		, "MainPageVm"
			//		, (sender) =>
			//		{
			//			Navigation.PopToRootAsync();
			//		});

			//MessagingCenter.Subscribe<PagePhotoSavingVm, IPhoto>(this
			//		, "SaveCommentsPageVm"
			//		, (sender, args) =>
			//		{
			//			var res = new SaveCommentsPage();
			//			res.BindingContext = new SaveCommentsPageVm
			//			(
			//				SimpleIoc.Default.GetInstance<IInternalModelService>(),
			//				SimpleIoc.Default.GetInstance<IFileWorkerService>(),
			//				SimpleIoc.Default.GetInstance<ISpeechRecognitionService>()
			//			) { NavigationParameter = args};
			//			Navigation.PushAsync(res);
			//		});

			//MessagingCenter.Subscribe<PagePhotoEditingVm, IPhoto>(this
			//		, "SaveCommentsPageVm"
			//		, (sender, args) =>
			//		{
			//			var res = new SaveCommentsPage();
			//			res.BindingContext = new SaveCommentsPageVm
			//			(
			//				SimpleIoc.Default.GetInstance<IInternalModelService>(),
			//				SimpleIoc.Default.GetInstance<IFileWorkerService>(),
			//				SimpleIoc.Default.GetInstance<ISpeechRecognitionService>()
			//			) { NavigationParameter = args };
			//			Navigation.PushAsync(res);
			//		});

			//MessagingCenter.Subscribe<MainPageVm, IFileSource>(this
			//		, "PagePhotoSavingVm"
			//		, (sender, args) =>
			//		{
			//			var res = new PagePhotoSaving();
			//			res.BindingContext = new PagePhotoSavingVm
			//			(
			//				SimpleIoc.Default.GetInstance<IFileWorkerService>(),
			//				SimpleIoc.Default.GetInstance<ISpeechRecognitionService>(),
			//				SimpleIoc.Default.GetInstance<IInternalModelService>(),
			//				SimpleIoc.Default.GetInstance<IImageLoader>()
			//			) { NavigationParameter = args};
			//			Navigation.PushAsync(res);
			//		});

			//MessagingCenter.Subscribe<PageSelectPhotoVm, IPhoto>(this
			//		, "PagePhotoEditingVm"
			//		, (sender, args) =>
			//		{
			//			var res = new PagePhotoEditing();
			//			res.BindingContext = new PagePhotoEditingVm() { NavigationParameter = args };
			//			Navigation.PushAsync(res);
			//		});

		}
	}
}
