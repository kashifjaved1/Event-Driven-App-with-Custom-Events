namespace EventDrivenCrudApp.Events
{
    public class ProductUpdatedEvent : IEvent
    {
        public Product? Product { get; set; }
    }
}
