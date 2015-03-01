using LinkTypes = WebApi.Data.Implementations.Constants.ConstantsRecords.LinkTypes;
using Parents = WebApi.Data.Implementations.Constants.ConstantsRecords.DefaultParentsForBlobs;
using System;
using System.Text;
using WebApi.Data.Implementations.Special;
using WebApi.Data.Interfaces.Entities;

namespace WebApi.Data.Implementations.Entities
{
	public sealed class Document : Record, IDocument
	{
		#region Fields

		private readonly string mvExtension;
		private readonly byte[] mvData;

		#endregion

		#region Properties

		public byte[] Data
		{
			get
			{
				return mvData;
			}
		}

		public string DataAsString
		{
			get
			{
				return Encoding.ASCII.GetString(mvData);
			}
		}

		public string DocumentTypeID { get; set; }

		public string Extension 
		{
			get
			{
				return mvExtension;
			}
		}

		#endregion

		#region Ctor

		public Document(byte[] data, string name, string extension, string remark = null)
				: base(name, remark ?? string.Empty, Constants.ConstantsRecords.ClassTypes.BLOB)
		{
			mvData = data;
			mvExtension = extension;
		}

		public Document(byte[] data) : this(data, DateTime.Now.ToString(), string.Empty) { }

		#endregion

		#region StaticMethods

		public static IDocument CreateImageDocumentWithComment(string name, string extension, byte[] imageData, string comment, DateTime lastWriteTime, DateTime creationTime)
		{
			var newBitmapDocument = new Document(imageData, name, extension, comment)
			{
				ID = KeyGenerator.GetKey(Constants.ConstantsRecords.ClassTypes.BLOB),
				DateInserted = DateTime.Now,
				ChangeDate = lastWriteTime,
				BeginDate = creationTime,
				EndDate = creationTime,
				EntryDate = DateTime.Now,
				DocumentTypeID = Constants.ConstantsRecords.BlobTypes.PHOTO_TYPE_ID,
				VUBClass = Constants.ConstantsRecords.StrangeConstants.VUB_CLASS_ID_FOR_BLOB,
				VUBSubClass = Constants.ConstantsRecords.StrangeConstants.VUB_SUB_CLASS_ID_FOR_BLOB
			};

			// Default Link
			newBitmapDocument.AddLinkToParent(Parents.MASTER_OPERATION_ID);
			return newBitmapDocument;
		}

		#endregion
	}
}
