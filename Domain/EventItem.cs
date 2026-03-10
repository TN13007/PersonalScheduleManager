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
        string timeLabel = _timeRange == null
            ? "N/A"
            : $"{_timeRange.StartTime:yyyy-MM-dd HH:mm} - {_timeRange.EndTime:yyyy-MM-dd HH:mm}";

        return $"[{GetTypeName()}] {Title} | Time: {timeLabel} | Location: {Location} | Priority: {Priority} | Status: {Status}";
    }

    public override string GetTypeName()
    {
        return "Event";
    }

    public override bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Title)
            && _timeRange != null
            && _timeRange.IsValid()
            && !string.IsNullOrWhiteSpace(Location)
            && Enum.IsDefined(typeof(Priority), Priority)
            && Enum.IsDefined(typeof(Status), Status);
    }

    public override bool Overlaps(ScheduleItem other)
    {
        if (_timeRange == null || !_timeRange.IsValid() || other == null)
        {
            return false;
        }

        if (other is EventItem ev && ev.TimeRange != null && ev.TimeRange.IsValid())
        {
            return _timeRange.Overlaps(ev.TimeRange);
        }

        if (other is TaskItem task)
        {
            return task.Deadline >= _timeRange.StartTime && task.Deadline < _timeRange.EndTime;
        }

        if (other is ReminderItem reminder)
        {
            return reminder.RemindTime >= _timeRange.StartTime && reminder.RemindTime < _timeRange.EndTime;
        }

        return false;
    }

    public void EnableReminder()
    {
        _isReminder = true;
    }

    public void DisableReminder()
    {
        _isReminder = false;
    }
}