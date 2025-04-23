namespace EventDrivenCrudApp.Events
{
    public class ProductDeletedEvent : IEvent
    {
        public Guid ProductId { get; set; }
    }
}
