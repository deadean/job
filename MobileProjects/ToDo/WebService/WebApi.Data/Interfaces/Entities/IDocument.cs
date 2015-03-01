namespace WebApi.Data.Interfaces.Entities
{
	public interface IDocument : IRecord
	{
        string DocumentTypeID { get; }

        string Extension { get; }

        byte[] Data { get; }
    }
}
