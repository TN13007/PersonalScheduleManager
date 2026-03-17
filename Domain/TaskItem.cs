using System;

/// Đại diện cho một công việc (Task) trong hệ thống lịch.
/// Mỗi công việc có một thời hạn hoàn thành (Deadline) và trạng thái hoàn thành.
public class TaskItem : ScheduleItem
{
    /// Lưu thời hạn hoàn thành của công việc.
    private DateTime _deadline;
    /// Cho biết công việc đã được hoàn thành hay chưa.
    private bool _isCompleted;

    /// Lấy hoặc thiết lập thời hạn hoàn thành của công việc.
    public DateTime Deadline
    {
        get { return _deadline; }
        set { _deadline = value; }
    }
    /// Lấy hoặc thiết lập trạng thái hoàn thành của công việc.
    public bool IsCompleted
    {
        get { return _isCompleted; }
        set { _isCompleted = value; }
    }
    /// Khởi tạo một đối tượng TaskItem mới.
    /// Mặc định công việc chưa được hoàn thành.
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
        if (other == null)
        {
            return false;
        }
        return false;
    }

    public void MarkAsCompleted()
    {
        _isCompleted = true;
        Status = Status.Done;
    }
}