ScheduleService scheduleService = new ScheduleService();
InputHelper inputHelper = new InputHelper();
JsonScheduleRepository repository = new JsonScheduleRepository("schedule.json");

ConsoleMenu menu = new ConsoleMenu(scheduleService, inputHelper, repository);
menu.Run();
