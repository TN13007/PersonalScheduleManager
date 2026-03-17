public class TaskItemBuilder
{
    private TaskItem _taskItem;

    public TaskItemBuilder()
    {
        _taskItem = new TaskItem();
    }

    public TaskItemBuilder WithTitle(string title)
    {
        _taskItem.Title = title;
        return this;
    }

    public TaskItemBuilder WithDescription(string description)
    {
        _taskItem.Description = description;
        return this;
    }

    public TaskItemBuilder WithPriority(Priority priority)
    {
        _taskItem.Priority = priority;
        return this;
    }

    public TaskItemBuilder WithDeadline(DateTime deadline)
    {
        _taskItem.Deadline = deadline;
        return this;
    }

    public TaskItemBuilder WithStatus(Status status)
    {
        _taskItem.Status = status;
        return this;
    }

    public TaskItem Build()
    {
        return _taskItem;
    }
}