using System;

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
        string timeText = RemindTime.ToString("yyyy-MM-dd HH:mm");

        string result =
            "[" + GetTypeName() + "] " +
            Title +
            " | Remind At: " + timeText +
            " | Priority: " + Priority +
            " | Status: " + Status;

        return result;
    }

    public override string GetTypeName()
    {
        return "Reminder";
    }

    public override bool IsValid()
    {
        if (Title == null || Title.Trim() == "")
        {
            return false;
        }

        if (RemindTime == default(DateTime))
        {
            return false;
        }

        if (RemindOffset < TimeSpan.Zero)
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
        if (other == null)
        {
            return false;
        }

        ReminderItem? reminder = other as ReminderItem;
        if (reminder != null)
        {
            if (RemindTime == reminder.RemindTime)
            {
                return true;
            }
        }

        TaskItem? task = other as TaskItem;
        if (task != null)
        {
            if (RemindTime == task.Deadline)
            {
                return true;
            }
        }

        EventItem? ev = other as EventItem;
        if (ev != null)
        {
            if (ev.TimeRange != null && ev.TimeRange.IsValid())
            {
                if (RemindTime >= ev.TimeRange.StartTime &&
                    RemindTime < ev.TimeRange.EndTime)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void SetReminder(TimeSpan offset)
    {
        if (offset < TimeSpan.Zero)
        {
            throw new ArgumentException("Offset cannot be negative.", "offset");
        }

        _remindOffset = offset;
        _remindTime = DateTime.Now.Add(offset);
    }

    public void SendNotification()
    {
        _isNotified = true;
    }
}