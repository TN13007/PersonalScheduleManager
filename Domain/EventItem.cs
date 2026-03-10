public class EventItem : ScheduleItem
{
    private TimeRange _timeRange;
    private string _location;
    private bool _isReminder;

    public TimeRange TimeRange
    {
        get { return _timeRange; }
        set { _timeRange = value; }
    }

    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }

    public bool IsReminder
    {
        get { return _isReminder; }
        set { _isReminder = value; }
    }

    public EventItem()
    {
        _isReminder = false;
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

    public void EnableReminder()
    {
        throw new NotImplementedException();
    }

    public void DisableReminder()
    {
        throw new NotImplementedException();
    }
}