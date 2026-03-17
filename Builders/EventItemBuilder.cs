public class EventItemBuilder
{
    private EventItem _eventItem;

    public EventItemBuilder()
    {
        _eventItem = new EventItem();
    }

    public EventItemBuilder WithTitle(string title)
    {
        _eventItem.Title = title;
        return this;
    }

    public EventItemBuilder WithDescription(string description)
    {
        _eventItem.Description = description;
        return this;
    }

    public EventItemBuilder WithPriority(Priority priority)
    {
        _eventItem.Priority = priority;
        return this;
    }

    public EventItemBuilder WithTimeRange(TimeRange timeRange)
    {
        _eventItem.TimeRange = timeRange;
        return this;
    }

    public EventItemBuilder WithLocation(string location)
    {
        _eventItem.Location = location;
        return this;
    }

    public EventItemBuilder WithReminder(bool isReminder)
    {
        _eventItem.IsReminder = isReminder;
        return this;
    }

    public EventItemBuilder WithStatus(Status status)
    {
        _eventItem.Status = status;
        return this;
    }

    public EventItem Build()
    {
        return _eventItem;
    }
}