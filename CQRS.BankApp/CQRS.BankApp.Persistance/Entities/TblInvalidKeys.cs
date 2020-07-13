namespace CQRS.BankApp.Persistance.Entities
{
    public class TblInvalidKeys : IMockEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Key { get; set; }
    }
}
