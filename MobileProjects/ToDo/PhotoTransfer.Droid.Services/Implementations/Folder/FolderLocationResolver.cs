using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PhotoTransfer.UI.Common.Interfaces.Folder;
using PhotoTransfer.UI.Common.Enums.File;
using PhotoTransfer.Driod.Data.Extensions;
using Xamarin.Forms;
using PhotoTransfer.Driod.Services.Implementations.Folder;

[assembly: Dependency(typeof(FolderLocationResolver))]

namespace PhotoTransfer.Driod.Services.Implementations.Folder
{
	public class FolderLocationResolver : IFolderLocationResolver
	{
		public string ResolveLocation(enFileWorkerLocation location, bool isRelativeLocation)
		{
			return isRelativeLocation ? location.ToRelativePath() : location.ToPath();
		}
	}
}