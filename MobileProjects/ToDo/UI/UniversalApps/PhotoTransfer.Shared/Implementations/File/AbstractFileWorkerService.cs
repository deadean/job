using PhotoTransfer.Data.Interfaces.File;
using PhotoTransfer.Data.Interfaces.Folder;
using FileConstants = PhotoTransfer.UI.Common.Constants.Constants.File;
using PhotoTransfer.UI.Common.Constants;
using PhotoTransfer.UI.Common.Enums.File;
using PhotoTransfer.UI.Common.Interfaces.File;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.IO;
using System.Text;
using System.Linq;
using PhotoTransfer.WP.Data.Interfaces.File;
using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.UI.UniversalApps.Data.Implementations.Folder;
using PhotoTransfer.UI.UniversalApps.Data.Implementations.File;
using PhotoTransfer.WP.Data.Interfaces.Folder;
using PhotoTransfer.UI.UniversalApps.Data.Extensions;

namespace PhotoTransfer.Implementations.File
{
	public abstract class AbstractFileWorkerService : IFileWorkerService
	{
		#region Fields

		IFileSource modFileSource;
		FileOpenPicker modFilePicker;

		#endregion

		#region Properties

		protected FileOpenPicker ProtectedFilePicker
		{
			get
			{
				return modFilePicker;
			}
		}

		protected IFileSource ProtectedFileSource
		{
			get
			{
				return modFileSource;
			}

			set
			{
				modFileSource = value;
			}
		}

		#endregion

		#region Private services

		async Task LaunchFileSelectionAsync(enFileWorkerLocation startupLocation = enFileWorkerLocation.Default, params string[] typeFilters)
		{
			modFilePicker = new FileOpenPicker();
			SetStartupLocation(startupLocation);

			if (typeFilters.Length == 0)
			{
				modFilePicker.FileTypeFilter.Add(FileConstants.ALL_FILES_EXTENSION);
			}
			else
			{
				typeFilters.ForEach(modFilePicker.FileTypeFilter.Add);
			}

			await PickFileAsync();
		}

		IFileSource CompleteOutstandingSelectionService()
		{
			var file = this.modFileSource;
			this.modFileSource = null;
			this.modFilePicker = null;
			AdditionalCleanUp();
			return file;
		}

		#endregion

		#region Protected services

		protected virtual void SetStartupLocation(enFileWorkerLocation startupLocation)
		{
			switch (startupLocation)
			{
				case enFileWorkerLocation.Downloads:
					modFilePicker.SuggestedStartLocation = PickerLocationId.Downloads;
					break;
				case enFileWorkerLocation.Documents:
					modFilePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
					break;
				case enFileWorkerLocation.Pictures:
					modFilePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
					break;
				case enFileWorkerLocation.Videos:
					modFilePicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
					break;
				case enFileWorkerLocation.Music:
					modFilePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
					break;
			}
		}

		protected virtual void AdditionalCleanUp() { }

		protected abstract Task PickFileAsync();

		#endregion

		#region IFileWorkerService implementation

		public async Task<IFileSource> PickFileAsync(enFileWorkerLocation startupLocation = enFileWorkerLocation.Default, params string[] typeFilters)
		{
			await LaunchFileSelectionAsync(startupLocation, typeFilters);
			return CompleteOutstandingSelectionService();
		}

		public async Task<enFileOperationResult> MoveFileAsync(IFileSource fileSource, enFileWorkerLocation locationToSave, string newName)
		{
			try
			{
				var fileSourceObj = fileSource as IStorageFileContainer;
				var folderForSaveTo = GetFolderFromLocation(locationToSave);

				if (await CheckFileExistsInFolderAsync(new FolderContainer(folderForSaveTo), newName))
				{
					return enFileOperationResult.FileAlreadyExists;
				}
				else
				{
					await fileSourceObj.ContainerObject.MoveAsync(folderForSaveTo, newName, NameCollisionOption.FailIfExists);
					return enFileOperationResult.Succeed;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(Constants.Constants.ErrorMessages.MOVE_FILE_ASYNC_ERROR, ex);
			}
		}

		public async Task<enFileOperationResult> RenameFileAsync(IFileSource fileSource, string newName)
		{
			try
			{
				var fileSourceObj = fileSource as IStorageFileContainer;

				if (await CheckFileExistsInSameFolderAsync(fileSourceObj, newName))
				{
					return enFileOperationResult.FileAlreadyExists;
				}

				await fileSourceObj.ContainerObject.RenameAsync(newName);
				return enFileOperationResult.Succeed;
			}
			catch (Exception ex)
			{
				throw new Exception(Constants.Constants.ErrorMessages.RENAME_FILE_ASYNC_ERROR, ex);
			}
		}

		public async Task<bool> CheckFileExistsInSameFolderAsync(IFileSource fileSource, string fileName)
		{
			var folder = await GetParentFolderAsync(fileSource);

			if (folder == null)
				return true;

			return await CheckFileExistsInFolderAsync(folder, fileName);
		}

		public async Task<IFolderSource> GetParentFolderAsync(IFileSource fileSource)
		{
			var fileSourceObj = fileSource as IStorageFileContainer;

			if (fileSourceObj == null)
				return null;

			var folderPath = fileSourceObj.With(x => x.ContainerObject.GetParentDirectoryPath());

			if (folderPath == null)
				return null;

			var storageFolder = await StorageFolder.GetFolderFromPathAsync(folderPath);

			return storageFolder.With(x => new FolderContainer(x));
		}

		public async Task<bool> CheckFileExistsInFolderAsync(IFolderSource folderSource, string fileName)
		{
			try
			{
				var folderSourceObj = folderSource as IFolderContainer;
				await folderSourceObj.ContainerObject.With(x => x.GetFileAsync(fileName));
				return true;
			}
			catch (FileNotFoundException)
			{
				return false;
			}
		}

		public async Task<enFileOperationResult> SaveToTextFileAsync(string fileName, string data, enFileWorkerLocation locationToSave = enFileWorkerLocation.Default, bool isReplacingExisted = false)
		{
			try
			{
				var folder = GetFolderFromLocation(locationToSave);
				var folderSource = new FolderContainer(folder);

				if (!isReplacingExisted && await CheckFileExistsInFolderAsync(folderSource, fileName))
				{
					return enFileOperationResult.FileAlreadyExists;
				}

				var file = await folder.CreateFileAsync(fileName, isReplacingExisted ? CreationCollisionOption.OpenIfExists : CreationCollisionOption.FailIfExists);
				var fileBytes = Encoding.UTF8.GetBytes(data.ToCharArray());
				using (var stream = await file.OpenStreamForWriteAsync())
				{
					stream.Write(fileBytes, 0, fileBytes.Length);
				}

				return enFileOperationResult.Succeed;
			}
			catch (Exception ex)
			{
				throw new Exception(Constants.Constants.ErrorMessages.TEXT_FILE_SAVING_ERROR, ex);
			}
		}

		public async Task<IFileSource> GetFileAsync(string filePath)
		{
			try
			{
				var file = await StorageFile.GetFileFromPathAsync(filePath);
				return new StorageFileContainer(file, false);
			}
			catch (Exception ex)
			{
				throw new Exception(Constants.Constants.ErrorMessages.GETTING_TEXT_FILE_ERROR, ex);
			}
		}

		public async Task<IFileSource> TryGetFileAsync(string fileName, enFileWorkerLocation location)
		{
			try
			{
				var folder = GetFolderFromLocation(location);
				var fileExists = await CheckFileExistsInFolderAsync(new FolderContainer(folder), fileName);
				return fileExists ? new StorageFileContainer(await folder.GetFileAsync(fileName), false) : null;
			}
			catch (Exception ex)
			{
				throw new Exception(Constants.Constants.ErrorMessages.GETTING_TEXT_FILE_ERROR, ex);
			}
		}

		#endregion

		#region Static Services

		public virtual StorageFolder GetFolderFromLocation(enFileWorkerLocation location)
		{
			switch (location)
			{
				case enFileWorkerLocation.Documents:
					return KnownFolders.DocumentsLibrary;
				case enFileWorkerLocation.Pictures:
					return KnownFolders.PicturesLibrary;
				case enFileWorkerLocation.Videos:
					return KnownFolders.VideosLibrary;
				case enFileWorkerLocation.Music:
					return KnownFolders.MusicLibrary;
				default:
					return ApplicationData.Current.LocalFolder;
			}
		}

		#endregion
	}
}
