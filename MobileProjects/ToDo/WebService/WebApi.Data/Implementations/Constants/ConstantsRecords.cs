namespace WebApi.Data.Implementations.Constants
{
	public class ConstantsRecords
	{
		public static class BlobTypes
		{
			public const string PHOTO_TYPE_ID = "PHOTO_0000000000000000";
		}

		public static class ValuesBounds
		{
			public const int MAX_NAME_LENGTH = 256;
			public const int MAX_EXTENSION_LENGTH = 32;
			public const int MAX_REMARK_LENGTH = 100;
		}

		public static class ClassTypes
		{
			public const string BLOB = "BLOB";
		}

		public static class StrangeConstants
		{
			public const string VUB_CLASS_ID_FOR_BLOB = "BDOCUMENT_000000000000";
			public const string VUB_SUB_CLASS_ID_FOR_BLOB = "BDOCUMENT_000000000001";
		}

		// Strange too
		public static class VURRecordStatusID
		{
			public const string Active = "0309241901784576888708";
		}

		public static class LinkTypes
		{
			public const string CHILD_LINK = "CHILD";
		}

		public static class DefaultParentsForBlobs
		{
			public const string MASTER_OPERATION_ID = "150131151826OPER582819";
		}
	}
}
