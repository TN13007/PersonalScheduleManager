public class ConsoleMenu
{
    private ScheduleService _scheduleService;
    private InputHelper _inputHelper;
    private IScheduleRepository _repository;

    public ScheduleService ScheduleService
    {
        get { return _scheduleService; }
        set { _scheduleService = value; }
    }

    public InputHelper InputHelper
    {
        get { return _inputHelper; }
        set { _inputHelper = value; }
    }

    public IScheduleRepository Repository
    {
        get { return _repository; }
        set { _repository = value; }
    }

    public ConsoleMenu(ScheduleService scheduleService, InputHelper inputHelper, IScheduleRepository repository)
    {
        _scheduleService = scheduleService;
        _inputHelper = inputHelper;
        _repository = repository;
    }

    public void DisplayMainMenu()
    {
        throw new NotImplementedException();
    }

    public void AddTaskItem()
    {
        throw new NotImplementedException();
    }

    public void AddEventItem()
    {
        throw new NotImplementedException();
    }

    public void AddReminderItem()
    {
        throw new NotImplementedException();
    }

    public void RemoveItem()
    {
        throw new NotImplementedException();
    }

    public void UpdateItem()
    {
        throw new NotImplementedException();
    }

    public void ViewAllItems()
    {
        throw new NotImplementedException();
    }

    public void ViewItemsByDate()
    {
        throw new NotImplementedException();
    }

    public void ViewItemsByPriority()
    {
        throw new NotImplementedException();
    }

    public void SearchItems()
    {
        throw new NotImplementedException();
    }

    public void SaveSchedule()
    {
        throw new NotImplementedException();
    }

    public void LoadSchedule()
    {
        throw new NotImplementedException();
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}
