namespace EventDrivenCrudApp.Events
{
    public class ProductCreatedEvent : IEvent
    {
        public Product? Product { get; set; }
    }

}
