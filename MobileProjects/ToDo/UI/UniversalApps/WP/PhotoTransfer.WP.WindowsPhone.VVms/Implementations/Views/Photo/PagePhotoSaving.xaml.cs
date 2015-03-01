using PhotoTransfer.Data.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PhotoTransfer.Implementations.Views.Photo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PagePhotoSaving
		{
			#region Fields
			#endregion

			#region Ctor

			public PagePhotoSaving()
			{
				this.InitializeComponent();
			}

			#endregion

			#region Private Methods
			#endregion

			#region Public Methods
			#endregion

			#region Protected Methods

			protected override void OnNavigatedFrom(NavigationEventArgs e)
			{
				base.OnNavigatedFrom(e);
			}

			protected override void OnNavigatedTo(NavigationEventArgs e)
			{
				base.OnNavigatedTo(e);

				INavigationArgs args = e.Parameter as INavigationArgs;
				if (args == null)
					return;

				IPhotoSource photoSource = args.Parameter as IPhotoSource;
				if (photoSource == null)
					return;

				Image.Source = photoSource.PhotoContainer as ImageSource;
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
			#endregion

			#region Events Handlers
			#endregion
			
    }
}
