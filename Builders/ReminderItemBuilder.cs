public class ReminderItemBuilder
{
    private ReminderItem _reminderItem;

    public ReminderItemBuilder()
    {
        _reminderItem = new ReminderItem();
    }

    public ReminderItemBuilder WithTitle(string title)
    {
        _reminderItem.Title = title;
        return this;
    }

    public ReminderItemBuilder WithDescription(string description)
    {
        _reminderItem.Description = description;
        return this;
    }

    public ReminderItemBuilder WithPriority(Priority priority)
    {
        _reminderItem.Priority = priority;
        return this;
    }

    public ReminderItemBuilder WithRemindTime(DateTime remindTime)
    {
        _reminderItem.RemindTime = remindTime;
        return this;
    }

    public ReminderItemBuilder WithRemindOffset(TimeSpan offset)
    {
        _reminderItem.RemindOffset = offset;
        return this;
    }

    public ReminderItemBuilder WithStatus(Status status)
    {
        _reminderItem.Status = status;
        return this;
    }

    public ReminderItem Build()
    {
        return _reminderItem;
    }
}