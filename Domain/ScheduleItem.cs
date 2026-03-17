using System.Text.Json.Serialization;

[JsonDerivedType(typeof(TaskItem), typeDiscriminator: "task")]
[JsonDerivedType(typeof(EventItem), typeDiscriminator: "event")]
[JsonDerivedType(typeof(ReminderItem), typeDiscriminator: "reminder")]
public abstract class ScheduleItem
{
    private string _id;
    private string _title = string.Empty;
    private string _description = string.Empty;
    private Priority _priority;
    private Status _status;
    private DateTime _createdAt;

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public Priority Priority
    {
        get { return _priority; }
        set { _priority = value; }
    }

    public Status Status
    {
        get { return _status; }
        set { _status = value; }
    }

    public DateTime CreatedAt
    {
        get { return _createdAt; }
        set { _createdAt = value; }
    }

    protected ScheduleItem()
    {
        _id = Guid.NewGuid().ToString();
        _createdAt = DateTime.Now;
        _status = Status.Planned;
        _priority = Priority.Normal;
    }

    public void MarkDone()
    {
        _status = Status.Done;
    }

    public void Cancel()
    {
        _status = Status.Canceled;
    }

    public abstract string GetTypeName();

    public abstract string Display();

    public abstract bool IsValid();

    public abstract bool Overlaps(ScheduleItem other);
}