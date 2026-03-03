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
        throw new NotImplementedException();
    }

    public override string GetTypeName()
    {
        throw new NotImplementedException();
    }

    public override bool IsValid()
    {
        throw new NotImplementedException();
    }

    public override bool Overlaps(ScheduleItem other)
    {
        throw new NotImplementedException();
    }

    public void SetReminder(TimeSpan offset)
    {
        throw new NotImplementedException();
    }

    public void SendNotification()
    {
        throw new NotImplementedException();
    }
}