namespace CQRS.BankApp.Persistance.Entities
{
    public class TblNotifications : IMockEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public TblLogins Login { get; set; }
        public bool IsDisplayed { get; set; }
    }
}
