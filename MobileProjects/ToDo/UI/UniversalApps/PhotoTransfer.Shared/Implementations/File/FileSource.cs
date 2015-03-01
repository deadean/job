using PhotoTransfer.Data.Interfaces.File;

using Windows.Storage;

namespace PhotoTransfer.Implementations.File
{
	public class StorageFileContainer : IFileSource
	{
		public StorageFileContainer(StorageFile storageFile)
		{
			StorageFile = storageFile;
		}

		public StorageFile StorageFile { get; private set; }
	}
}
