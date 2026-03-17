using System;

public class EventItem : ScheduleItem
{
    private TimeRange? _timeRange;
    private string _location = string.Empty;
    private bool _isReminder;

    public TimeRange? TimeRange
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
        string timeLabel;

        if (_timeRange == null)
        {
            timeLabel = "N/A";
        }
        else
        {
            string start = _timeRange.StartTime.ToString("yyyy-MM-dd HH:mm");
            string end = _timeRange.EndTime.ToString("yyyy-MM-dd HH:mm");
            timeLabel = start + " - " + end;
        }

        string result =
            "[" + GetTypeName() + "] " +
            Title +
            " | Time: " + timeLabel +
            " | Location: " + Location +
            " | Priority: " + Priority +
            " | Status: " + Status;

        return result;
    }

    public override string GetTypeName()
    {
        return "Event";
    }

    public override bool IsValid()
    {
        if (Title == null || Title.Trim() == "")
        {
            return false;
        }

        if (_timeRange == null)
        {
            return false;
        }

        if (!_timeRange.IsValid())
        {
            return false;
        }

        if (Location == null || Location.Trim() == "")
        {
            return false;
        }

        if (!Enum.IsDefined(typeof(Priority), Priority))
        {
            return false;
        }

        if (!Enum.IsDefined(typeof(Status), Status))
        {
            return false;
        }

        return true;
    }

    public override bool Overlaps(ScheduleItem other)
    {
        if (_timeRange == null)
        {
            return false;
        }

        if (!_timeRange.IsValid())
        {
            return false;
        }

        if (other == null)
        {
            return false;
        }

        EventItem? ev = other as EventItem;
        if (ev != null)
        {
            if (ev.TimeRange != null && ev.TimeRange.IsValid())
            {
                return _timeRange.Overlaps(ev.TimeRange);
            }
        }

        TaskItem? task = other as TaskItem;
        if (task != null)
        {
            if (task.Deadline >= _timeRange.StartTime &&
                task.Deadline < _timeRange.EndTime)
            {
                return true;
            }
        }

        ReminderItem? reminder = other as ReminderItem;
        if (reminder != null)
        {
            if (reminder.RemindTime >= _timeRange.StartTime &&
                reminder.RemindTime < _timeRange.EndTime)
            {
                return true;
            }
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