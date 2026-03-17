using System;

public class TaskItem : ScheduleItem
{
    private DateTime _deadline;
    private bool _isCompleted;

    public DateTime Deadline
    {
        get { return _deadline; }
        set { _deadline = value; }
    }

    public bool IsCompleted
    {
        get { return _isCompleted; }
        set { _isCompleted = value; }
    }

    public TaskItem()
    {
        _isCompleted = false;
    }

    public override string Display()
    {
        string deadlineText = Deadline.ToString("yyyy-MM-dd HH:mm");

        string result =
            "[" + GetTypeName() + "] " +
            Title +
            " | Deadline: " + deadlineText +
            " | Priority: " + Priority +
            " | Status: " + Status;

        return result;
    }

    public override string GetTypeName()
    {
        return "Task";
    }

    public override bool IsValid()
    {
        if (Title == null || Title.Trim() == "")
        {
            return false;
        }

        if (Deadline == default(DateTime))
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

        TaskItem? task = other as TaskItem;
        if (task != null)
        {
            if (Deadline == task.Deadline)
            {
                return true;
            }
        }

        ReminderItem? reminder = other as ReminderItem;
        if (reminder != null)
        {
            if (Deadline == reminder.RemindTime)
            {
                return true;
            }
        }

        EventItem? ev = other as EventItem;
        if (ev != null)
        {
            if (ev.TimeRange != null && ev.TimeRange.IsValid())
            {
                if (Deadline >= ev.TimeRange.StartTime &&
                    Deadline < ev.TimeRange.EndTime)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void MarkAsCompleted()
    {
        _isCompleted = true;
        Status = Status.Done;
    }
}