namespace CQRS.BankApp.Persistance.Entities
{
    public class TblEvents : IMockEntity
    {
        public int Id { get; set; }
        public string JSON { get; set; }
    }
}
