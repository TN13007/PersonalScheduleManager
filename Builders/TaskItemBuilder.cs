public class TaskItemBuilder
{
    private TaskItem _taskItem;

    public TaskItemBuilder()
    {
        _taskItem = new TaskItem();
    }

    public TaskItemBuilder WithTitle(string title)
    {
        throw new NotImplementedException();
    }

    public TaskItemBuilder WithDescription(string description)
    {
        throw new NotImplementedException();
    }

    public TaskItemBuilder WithPriority(Priority priority)
    {
        throw new NotImplementedException();
    }

    public TaskItemBuilder WithDeadline(DateTime deadline)
    {
        throw new NotImplementedException();
    }

    public TaskItemBuilder WithStatus(Status status)
    {
        throw new NotImplementedException();
    }

    public TaskItem Build()
    {
        throw new NotImplementedException();
    }
}