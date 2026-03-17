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
        Console.WriteLine("========================================");
        Console.WriteLine("   PERSONAL SCHEDULE MANAGER");
        Console.WriteLine("========================================");
        Console.WriteLine("  1. Add Task");
        Console.WriteLine("  2. Add Event");
        Console.WriteLine("  3. Add Reminder");
        Console.WriteLine("  4. Remove Item");
        Console.WriteLine("  5. Update Item");
        Console.WriteLine("  6. View All Items");
        Console.WriteLine("  7. View Items by Date");
        Console.WriteLine("  8. View Items by Priority");
        Console.WriteLine("  9. Search Items");
        Console.WriteLine(" 10. Save Schedule");
        Console.WriteLine(" 11. Load Schedule");
        Console.WriteLine("  0. Exit");
        Console.WriteLine("========================================");
    }

    public void AddTaskItem()
    {
        Console.WriteLine("--- Add New Task ---");
        string title = _inputHelper.ReadString("Title: ");
        string description = _inputHelper.ReadString("Description: ");
        Priority priority = _inputHelper.ReadPriority("Priority:");
        DateTime deadline = _inputHelper.ReadDateTime("Deadline (yyyy-MM-dd HH:mm): ");

        TaskItem task = new TaskItemBuilder()
            .WithTitle(title)
            .WithDescription(description)
            .WithPriority(priority)
            .WithDeadline(deadline)
            .Build();

        if (_scheduleService.AddItemToSchedule(task))
        {
            List<ScheduleItem> conflicts = _scheduleService.GetConflictingItems(task);
            if (conflicts.Count > 0)
            {
                _inputHelper.DisplayMessage("Warning: This item conflicts with:");
                for (int i = 0; i < conflicts.Count; i++)
                    _inputHelper.DisplayMessage($"  - {conflicts[i].Display()}");
            }
            _inputHelper.DisplayMessage("Task added successfully.");
        }
        else
        {
            List<string> errors = _scheduleService.Validator.GetValidationErrors(task);
            _inputHelper.DisplayError("Failed to add task:");
            for (int i = 0; i < errors.Count; i++)
                _inputHelper.DisplayError($"  - {errors[i]}");
        }
    }

    public void AddEventItem()
    {
        Console.WriteLine("--- Add New Event ---");
        string title = _inputHelper.ReadString("Title: ");
        string description = _inputHelper.ReadString("Description: ");
        Priority priority = _inputHelper.ReadPriority("Priority:");
        TimeRange timeRange = _inputHelper.ReadTimeRange("Time Range:");
        string location = _inputHelper.ReadString("Location: ");

        EventItem ev = new EventItemBuilder()
            .WithTitle(title)
            .WithDescription(description)
            .WithPriority(priority)
            .WithTimeRange(timeRange)
            .WithLocation(location)
            .Build();

        if (_scheduleService.AddItemToSchedule(ev))
        {
            List<ScheduleItem> conflicts = _scheduleService.GetConflictingItems(ev);
            if (conflicts.Count > 0)
            {
                _inputHelper.DisplayMessage("Warning: This item conflicts with:");
                for (int i = 0; i < conflicts.Count; i++)
                    _inputHelper.DisplayMessage($"  - {conflicts[i].Display()}");
            }
            _inputHelper.DisplayMessage("Event added successfully.");
        }
        else
        {
            List<string> errors = _scheduleService.Validator.GetValidationErrors(ev);
            _inputHelper.DisplayError("Failed to add event:");
            for (int i = 0; i < errors.Count; i++)
                _inputHelper.DisplayError($"  - {errors[i]}");
        }
    }

    public void AddReminderItem()
    {
        Console.WriteLine("--- Add New Reminder ---");
        string title = _inputHelper.ReadString("Title: ");
        string description = _inputHelper.ReadString("Description: ");
        Priority priority = _inputHelper.ReadPriority("Priority:");
        DateTime remindTime = _inputHelper.ReadDateTime("Remind Time (yyyy-MM-dd HH:mm): ");

        ReminderItem reminder = new ReminderItemBuilder()
            .WithTitle(title)
            .WithDescription(description)
            .WithPriority(priority)
            .WithRemindTime(remindTime)
            .Build();

        if (_scheduleService.AddItemToSchedule(reminder))
        {
            List<ScheduleItem> conflicts = _scheduleService.GetConflictingItems(reminder);
            if (conflicts.Count > 0)
            {
                _inputHelper.DisplayMessage("Warning: This item conflicts with:");
                for (int i = 0; i < conflicts.Count; i++)
                    _inputHelper.DisplayMessage($"  - {conflicts[i].Display()}");
            }
            _inputHelper.DisplayMessage("Reminder added successfully.");
        }
        else
        {
            List<string> errors = _scheduleService.Validator.GetValidationErrors(reminder);
            _inputHelper.DisplayError("Failed to add reminder:");
            for (int i = 0; i < errors.Count; i++)
                _inputHelper.DisplayError($"  - {errors[i]}");
        }
    }

    public void RemoveItem()
    {
        List<ScheduleItem> items = _scheduleService.GetAllItems();
        if (items.Count == 0)
        {
            _inputHelper.DisplayMessage("No items to remove.");
            return;
        }

        Console.WriteLine("--- Remove Item ---");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {items[i].Display()}");
        }

        int index = _inputHelper.ReadInt("Select item number to remove: ") - 1;
        if (index < 0 || index >= items.Count)
        {
            _inputHelper.DisplayError("Invalid selection.");
            return;
        }

        if (_scheduleService.RemoveItemFromSchedule(items[index].Id))
            _inputHelper.DisplayMessage("Item removed successfully.");
        else
            _inputHelper.DisplayError("Failed to remove item.");
    }

    public void UpdateItem()
    {
        List<ScheduleItem> items = _scheduleService.GetAllItems();
        if (items.Count == 0)
        {
            _inputHelper.DisplayMessage("No items to update.");
            return;
        }

        Console.WriteLine("--- Update Item ---");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {items[i].Display()}");
        }

        int index = _inputHelper.ReadInt("Select item number to update: ") - 1;
        if (index < 0 || index >= items.Count)
        {
            _inputHelper.DisplayError("Invalid selection.");
            return;
        }

        ScheduleItem item = items[index];

        string newTitle = _inputHelper.ReadString($"New title (current: {item.Title}, leave empty to keep): ");
        if (!string.IsNullOrWhiteSpace(newTitle))
            item.Title = newTitle;

        string newDesc = _inputHelper.ReadString($"New description (current: {item.Description}, leave empty to keep): ");
        if (!string.IsNullOrWhiteSpace(newDesc))
            item.Description = newDesc;

        string updatePriority = _inputHelper.ReadString("Update priority? (y/n): ");
        if (updatePriority.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
            item.Priority = _inputHelper.ReadPriority("New priority:");

        string updateStatus = _inputHelper.ReadString("Update status? (y/n): ");
        if (updateStatus.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
            item.Status = _inputHelper.ReadStatus("New status:");

        if (item is TaskItem task)
        {
            string updateDeadline = _inputHelper.ReadString("Update deadline? (y/n): ");
            if (updateDeadline.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
                task.Deadline = _inputHelper.ReadDateTime("New deadline (yyyy-MM-dd HH:mm): ");
        }
        else if (item is EventItem ev)
        {
            string updateTime = _inputHelper.ReadString("Update time range? (y/n): ");
            if (updateTime.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
                ev.TimeRange = _inputHelper.ReadTimeRange("New time range:");

            string newLoc = _inputHelper.ReadString($"New location (current: {ev.Location}, leave empty to keep): ");
            if (!string.IsNullOrWhiteSpace(newLoc))
                ev.Location = newLoc;
        }
        else if (item is ReminderItem reminder)
        {
            string updateRemind = _inputHelper.ReadString("Update remind time? (y/n): ");
            if (updateRemind.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
                reminder.RemindTime = _inputHelper.ReadDateTime("New remind time (yyyy-MM-dd HH:mm): ");
        }

        _scheduleService.UpdateItemInSchedule(item);
        _inputHelper.DisplayMessage("Item updated successfully.");
    }

    public void ViewAllItems()
    {
        Console.WriteLine("--- All Schedule Items ---");
        _scheduleService.DisplaySchedule();
    }

    public void ViewItemsByDate()
    {
        DateTime date = _inputHelper.ReadDateTime("Enter date (yyyy-MM-dd): ");
        Console.WriteLine($"--- Items for {date:yyyy-MM-dd} ---");
        _scheduleService.DisplayScheduleByDate(date);
    }

    public void ViewItemsByPriority()
    {
        Priority priority = _inputHelper.ReadPriority("Select priority:");
        Console.WriteLine($"--- Items with priority: {priority} ---");
        List<ScheduleItem> items = _scheduleService.GetItemsByPriority(priority);
        if (items.Count == 0)
        {
            _inputHelper.DisplayMessage("No items found.");
            return;
        }
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {items[i].Display()}");
        }
    }

    public void SearchItems()
    {
        string keyword = _inputHelper.ReadString("Enter search keyword: ");
        Console.WriteLine($"--- Search results for \"{keyword}\" ---");
        List<ScheduleItem> items = _scheduleService.SearchItems(keyword);
        if (items.Count == 0)
        {
            _inputHelper.DisplayMessage("No items found.");
            return;
        }
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {items[i].Display()}");
        }
    }

    public void SaveSchedule()
    {
        _repository.Save(_scheduleService.Schedule);
        _inputHelper.DisplayMessage("Schedule saved successfully.");
    }

    public void LoadSchedule()
    {
        if (!_repository.Exists())
        {
            _inputHelper.DisplayMessage("No saved schedule found.");
            return;
        }

        Schedule loaded = _repository.Load();
        _scheduleService.Schedule = loaded;
        _inputHelper.DisplayMessage($"Schedule loaded successfully. {loaded.Items.Count} items found.");
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            DisplayMainMenu();
            int choice = _inputHelper.ReadInt("Choose option: ");
            Console.WriteLine();

            switch (choice)
            {
                case 1: AddTaskItem(); break;
                case 2: AddEventItem(); break;
                case 3: AddReminderItem(); break;
                case 4: RemoveItem(); break;
                case 5: UpdateItem(); break;
                case 6: ViewAllItems(); break;
                case 7: ViewItemsByDate(); break;
                case 8: ViewItemsByPriority(); break;
                case 9: SearchItems(); break;
                case 10: SaveSchedule(); break;
                case 11: LoadSchedule(); break;
                case 0: running = false; break;
                default: _inputHelper.DisplayError("Invalid option. Please try again."); break;
            }

            if (running)
            {
                Console.WriteLine();
                _inputHelper.ReadString("Press Enter to continue...");
            }
        }

        _inputHelper.DisplayMessage("Goodbye!");
    }
}
