namespace WebApi.Data.Interfaces.Entities
{
    public interface IPersonHeader
    {
        string PersonID { get; set; }
        string PreName { get; set; }
        string PostName { get; set; }
    }
}
