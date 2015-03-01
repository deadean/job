using System;
using System.Threading.Tasks;
using PhotoTransfer.Common.Implementations.Special;
using PhotoTransfer.WP.Data.Interfaces.File;

using Windows.Storage;

namespace PhotoTransfer.UI.UniversalApps.Data.Implementations.File
{
	public class StorageFileContainer : Container<StorageFile>, IStorageFileContainer
	{
		bool mvIsNew;

		public string FileName { get; private set; }

		public StorageFileContainer(StorageFile file, bool isNew) : base(file)
		{
			mvIsNew = isNew;			
			FileName = file.Name;
		}

		public object File
		{
			get 
			{
				return ContainerObject;
			}
		}

		public bool IsNew
		{
			get
			{
				return mvIsNew;
			}
		}

		public string Name
		{
			get 
			{
				return ContainerObject == null ? string.Empty : ContainerObject.DisplayName;
			}
		}

		public string FullName
		{
			get 
			{
				return ContainerObject == null ? string.Empty : ContainerObject.Name;
			}
		}

    public async Task<string> GetFileContentAsync()
    {
        return await FileIO.ReadTextAsync(ContainerObject);
    }
		
		public string FilePath
		{
			get 
			{
				throw new NotImplementedException(); 
			}
		}
	}
}
