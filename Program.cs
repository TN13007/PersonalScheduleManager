using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== TEST TASK =====");

        TaskItem task = new TaskItem();
        task.Title = "Finish OOP Assignment";
        task.Description = "Complete schedule project";
        task.Deadline = new DateTime(2026, 3, 20, 23, 59, 0);

        Console.WriteLine(task.Display());

        Console.WriteLine("Is task valid: " + task.IsValid());

        task.MarkAsCompleted();

        Console.WriteLine("After completion:");
        Console.WriteLine(task.Display());


        Console.WriteLine();
        Console.WriteLine("===== TEST EVENT =====");

        EventItem ev = new EventItem();
        ev.Title = "Team Meeting";
        ev.Description = "Discuss project progress";
        ev.Location = "Room A";

        TimeRange range = new TimeRange(new DateTime(2026, 3, 18, 10, 0, 0), new DateTime(2026, 3, 18, 11, 0, 0));

        ev.TimeRange = range;

        Console.WriteLine(ev.Display());
        Console.WriteLine("Is event valid: " + ev.IsValid());


        Console.WriteLine();
        Console.WriteLine("===== TEST REMINDER =====");

        ReminderItem reminder = new ReminderItem();
        reminder.Title = "Wake up";
        reminder.Description = "Morning reminder";
        reminder.RemindTime = new DateTime(2026, 3, 18, 7, 0, 0);
        reminder.RemindOffset = TimeSpan.FromMinutes(30);

        Console.WriteLine(reminder.Display());
        Console.WriteLine("Is reminder valid: " + reminder.IsValid());

        reminder.SendNotification();

        Console.WriteLine("Reminder notified: " + reminder.IsNotified);


        Console.WriteLine();
        Console.WriteLine("===== TEST OVERLAPS =====");

        TaskItem task2 = new TaskItem();
        task2.Title = "Submit report";
        task2.Deadline = new DateTime(2026, 3, 18, 10, 30, 0);

        Console.WriteLine("Task overlaps event: " + task2.Overlaps(ev));

        ReminderItem reminder2 = new ReminderItem();
        reminder2.Title = "Meeting reminder";
        reminder2.RemindTime = new DateTime(2026, 3, 18, 10, 15, 0);

        Console.WriteLine("Reminder overlaps event: " + reminder2.Overlaps(ev));

        Console.WriteLine();
        Console.WriteLine("===== TEST DONE =====");
    }
}