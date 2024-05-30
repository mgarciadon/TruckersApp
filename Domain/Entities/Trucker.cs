namespace Domain.Entities
{
    public class Trucker : User
    {
        public ICollection<Trip> Trips { get; set; } = [];
    }
}
