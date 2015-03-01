using PhotoTransfer.Common.Interfaces.Special;
using PhotoTransfer.Data.Interfaces.File;
using Windows.Storage;

namespace PhotoTransfer.WP.Data.Interfaces.File
{
    public interface IStorageFileContainer : IContainer<StorageFile>, IFileSource
    {
			
    }
}
