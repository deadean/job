using PhotoTransfer.Common.Interfaces.Special;
using PhotoTransfer.Data.Interfaces.Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PhotoTransfer.WP.Data.Interfaces.Folder
{
	public interface IFolderContainer : IContainer<StorageFolder>, IFolderSource
	{
	}
}
