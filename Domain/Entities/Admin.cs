namespace Domain.Entities
{
    public class Admin : User
    {
        public ICollection<Trip> Trips { get; set; } = [];
    }
}
