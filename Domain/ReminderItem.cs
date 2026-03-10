public class ReminderItem : ScheduleItem
{
    private DateTime _remindTime;
    private TimeSpan _remindOffset;
    private bool _isNotified;

    public DateTime RemindTime
    {
        get { return _remindTime; }
        set { _remindTime = value; }
    }

    public TimeSpan RemindOffset
    {
        get { return _remindOffset; }
        set { _remindOffset = value; }
    }

    public bool IsNotified
    {
        get { return _isNotified; }
        set { _isNotified = value; }
    }

    public ReminderItem()
    {
        _isNotified = false;
    }

    public override string Display()
    {
        return $"[{GetTypeName()}] {Title} | Remind At: {RemindTime:yyyy-MM-dd HH:mm} | Priority: {Priority} | Status: {Status}";
    }

    public override string GetTypeName()
    {
        return "Reminder";
    }

    public override bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Title)
            && RemindTime != default
            && RemindOffset >= TimeSpan.Zero
            && Enum.IsDefined(typeof(Priority), Priority)
            && Enum.IsDefined(typeof(Status), Status);
    }

    public override bool Overlaps(ScheduleItem other)
    {
        if (other == null)
        {
            return false;
        }

        if (other is ReminderItem reminder)
        {
            return RemindTime == reminder.RemindTime;
        }

        if (other is TaskItem task)
        {
            return RemindTime == task.Deadline;
        }

        if (other is EventItem ev && ev.TimeRange != null && ev.TimeRange.IsValid())
        {
            return RemindTime >= ev.TimeRange.StartTime && RemindTime < ev.TimeRange.EndTime;
        }

        return false;
    }

    public void SetReminder(TimeSpan offset)
    {
        if (offset < TimeSpan.Zero)
        {
            throw new ArgumentException("Offset cannot be negative.", nameof(offset));
        }

        _remindOffset = offset;
        _remindTime = DateTime.Now.Add(offset);
    }

    public void SendNotification()
    {
        _isNotified = true;
    }
}