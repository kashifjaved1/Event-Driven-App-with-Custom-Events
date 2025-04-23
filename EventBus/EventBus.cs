/// <summary>
/// A simple in-memory implementation of the IEventBus interface.
/// Allows subscribing to and publishing domain events.
/// </summary>
public class EventBus : IEventBus
{
    // Stores a list of event handlers for each event type
    private readonly Dictionary<Type, List<Delegate>> _handlers = new();

    /// <summary>
    /// Publishes an event to all registered subscribers for its type.
    /// </summary>
    /// <typeparam name="T">The type of event being published.</typeparam>
    /// <param name="event">The event instance to publish.</param>
    public void Publish<T>(T @event) where T : IEvent
    {
        // Try to get the list of handlers registered for this event type
        if (_handlers.TryGetValue(typeof(T), out var handlers))
        {
            foreach (var handler in handlers.Cast<Action<T>>())
            {
                // Invoke each subscribed handler with the event data.
                // This is where the actual event handling logic gets executed.
                // This'll will the handler's constructer where the event subscription will gets called.
                handler(@event);
            }
        }
    }

    /// <summary>
    /// Subscribes a handler to a specific type of event.
    /// </summary>
    /// <typeparam name="T">The type of event to subscribe to.</typeparam>
    /// <param name="handler">The handler to execute when the event is published.</param>
    public void Subscribe<T>(Action<T> handler) where T : IEvent
    {
        // If there are no handlers for this event type yet, create a new list
        if (!_handlers.ContainsKey(typeof(T)))
        {
            _handlers[typeof(T)] = new List<Delegate>();
        }

        // Add the handler to the list for this event type
        _handlers[typeof(T)].Add(handler);
    }
}