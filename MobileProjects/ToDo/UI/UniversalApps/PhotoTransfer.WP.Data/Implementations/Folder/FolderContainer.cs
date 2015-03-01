using PhotoTransfer.Common.Implementations.Special;
using PhotoTransfer.WP.Data.Interfaces.Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PhotoTransfer.UI.UniversalApps.Data.Implementations.Folder
{
	public class FolderContainer : Container<StorageFolder>, IFolderContainer
	{
		public FolderContainer(StorageFolder folder) : base(folder) {}

		public object Folder
		{
			get 
			{
				return ContainerObject;
			}
		}
	}
}
