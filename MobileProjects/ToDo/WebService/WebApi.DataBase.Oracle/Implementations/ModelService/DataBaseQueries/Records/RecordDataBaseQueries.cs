using System;
using System.Linq;
using System.Text;
using WebApi.Common.Implementations.Extensions;
using WebApi.Data.Implementations.Entities;
using WebApi.Data.Interfaces.Entities;
using ClassTypes = WebApi.Data.Implementations.Constants.ConstantsRecords.ClassTypes;
using RecStatus = WebApi.Data.Implementations.Constants.ConstantsRecords.VURRecordStatusID;
using StrangeConstats = WebApi.Data.Implementations.Constants.ConstantsRecords.StrangeConstants;
using ValueBounds = WebApi.Data.Implementations.Constants.ConstantsRecords.ValuesBounds;

namespace WebApi.DataBase.Oracle.Implementations.ModelService.DataBaseQueries.Records
{
	internal static class RecordDataBaseQueries
	{
		#region Procedure names

		public const string SQL_START_SYNC_BLOB_INDEX_PROCEDURE = "AD_UTIL.iet_document_source_sync";
		public const string SQL_START_SYNC_RECORD_INDEX_PROCEDURE = "AD_UTIL.iet_vur_object_sync";

		#endregion

		#region CDBQuery Queries

		public static CDBQuery sqlRecordLinkInsert(ILink link)
		{
			CDBQuery parameters = new CDBQuery("AD_REC.record_link_insert");
			parameters.Add("p_master_id", link.ID);
			parameters.Add("p_rec_id", link.Container.ID);
			parameters.Add("p_link_type", link.LinkType);
			return parameters;
		}

		public static CDBQuery sqlRecordLinkUpdate(ILink link)
		{
			CDBQuery parameters = new CDBQuery("AD_REC.record_link_update");
			parameters.Add("p_master_id", link.ID);
			parameters.Add("p_rec_id", link.Container.ID);
			parameters.Add("p_link_type", link.LinkType);
			parameters.Add("p_link_date", link.LinkDate);
			parameters.Add("p_protected_yn", link.IsProtected);
			return parameters;
		}

		public static CDBQuery sqlRecordInsert(IRecord record)
		{
			CDBQuery parameters = new CDBQuery("AD_REC.record_insert");
			parameters.Add("p_rec_id", record.ID);
			parameters.Add("p_class_type", record.ClassType);

			//if (string.IsNullOrEmpty(record.EntryUserID))
			//    record.EntryUserID = adACC.Engine.Singleton.CurrentUser.ID;
			//parameters.Add("p_entryuser_id", record.EntryUserID);

			record.EntryDate = DateTime.Now;

			//if (csFunctions.IsNullOrEmptyDate(record.EntryDate))
			//    record.EntryDate = DateTime.Now;
			//else
			//    record.EntryDate = CheckDateTime(record.EntryDate);
			parameters.Add("p_entry_date", record.EntryDate);
			return parameters;
		}

		public static CDBQuery sqlRecordUpdate(IRecord record)
		{
			CDBQuery parameters = new CDBQuery("AD_REC.record_update");

			parameters.Add("p_rec_id", record.ID);
			parameters.Add("p_class_type", record.ClassType);
			parameters.Add("p_status_id", RecStatus.Active);
			parameters.Add("p_inheritance_yn", 0);
			//parameters.Add("p_inheritance_yn", record.IsInheritance ? 1 : 0);

			if (record.ClassType == ClassTypes.BLOB) //&& csFunctions.IsNullOrEmptyDate(record.BeginDate))
				record.BeginDate = record.EndDate;

			parameters.Add("p_begin_date", record.BeginDate);
			parameters.Add("p_end_date", record.EndDate);
			parameters.Add("p_vub_class_id", StrangeConstats.VUB_CLASS_ID_FOR_BLOB);
			parameters.Add("p_vub_sub_class_id", StrangeConstats.VUB_SUB_CLASS_ID_FOR_BLOB);
			parameters.Add("p_rec_no", string.Empty);	//record.RecNO);
			parameters.Add("p_rec_name", record.Name);

			parameters.Add("p_short_name", record.Name.TrimString(50));//Math.Min(record.Name.Length, 50)));
			//parameters.Add("p_short_name", string.Empty);
			parameters.Add("p_sys_note_id", string.Empty);//record.SysNoteID);

			record.ChangeDate = DateTime.Now;

			//if (csFunctions.IsNullOrEmptyDate(record.ChangeDate))
			//    record.ChangeDate = DateTime.Now;
			//else
			//    record.ChangeDate = CheckDateTime(record.ChangeDate);
			parameters.Add("p_change_date", record.ChangeDate);

			parameters.Add("p_changeuser_id", string.Empty);//record.ChangeUserID);
			parameters.Add("p_remark", record.Remark);
			parameters.Add("p_syst_remark", string.Empty);//record.SysRemark);
			record.EntryDate = DateTime.Now;
			//if (csFunctions.IsNullOrEmptyDate(record.EntryDate))
			//    record.EntryDate = DateTime.Now;
			//else
			//    record.EntryDate = CheckDateTime(record.EntryDate);
			parameters.Add("p_entry_date", record.EntryDate);

			parameters.Add("p_entryuser_id", string.Empty);//record.EntryUserID);
			return parameters;
		}

		public static CDBQuery sqlDocumentAttributeInsert(IRecord document)
		{
			var parameters = new CDBQuery("AD_REC.document_attribute_insert");
			parameters.Add("p_doc_id", document.ID);
			parameters.Add("p_doc_name", document.Name.TrimString(ValueBounds.MAX_NAME_LENGTH));//csFunctions.SubString(recDocument.DocumentName, maxNameLength));
			parameters.Add("p_date_inserted", document.DateInserted);
			return parameters;
		}

		public static CDBQuery sqlDocumentAttributeUpdate(IDocument recDocument)
		{
			string docName = recDocument.Name ?? string.Empty;
			string docExt = recDocument.Extension ?? string.Empty;

			if (docExt.Length > ValueBounds.MAX_EXTENSION_LENGTH)
			{
				docName = docName + docExt;
				docExt = string.Empty;
			}

			var parameters = new CDBQuery("AD_REC.document_attribute_update");
			parameters.Add("p_doc_id", recDocument.ID);
			parameters.Add("p_type_id", recDocument.DocumentTypeID);
			parameters.Add("p_doc_name", recDocument.Name.TrimString(ValueBounds.MAX_NAME_LENGTH));
			parameters.Add("p_remark", recDocument.Remark.TrimString(ValueBounds.MAX_REMARK_LENGTH));
			parameters.Add("p_date_inserted", recDocument.DateInserted);
			parameters.Add("p_doc_ext", recDocument.Extension.TrimString(ValueBounds.MAX_EXTENSION_LENGTH));
			parameters.Add("p_doc_attribute", 0);//recDocument.DocumentAttribute);
			return parameters;
		}

		public static CDBQuery sqlBitmapDocumentInsert(IDocument document)
		{
			var parameters = new CDBQuery("ad_blob.document_insert");
			parameters.Add("p_doc_id", document.ID);
			return parameters;
		}

		public static CDBQuery sqlBitmapDocumentEmpty(IDocument document)
		{
			var parameters = new CDBQuery("ad_blob.document_empty");
			parameters.Add("p_doc_id", document.ID);
			return parameters;
		}

		public static CDBQuery sqlBitmapDocumentUpdate(IDocument document)
		{
			var parameters = new CDBQuery("ad_blob.document_update_new");
			parameters.Add("p_doc_id", document.ID);
			parameters.Add("p_document", document.Data);
			return parameters;
		}

		#endregion
	}
}
