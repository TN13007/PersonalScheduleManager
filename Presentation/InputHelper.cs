public class InputHelper
{
    public string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }

    public int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            DisplayError("Invalid input. Please enter a valid number.");
        }
    }

    public DateTime ReadDateTime(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
                return result;
            DisplayError("Invalid format. Please use: yyyy-MM-dd HH:mm");
        }
    }

    public Priority ReadPriority(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            Console.WriteLine("  0 - Low");
            Console.WriteLine("  1 - Normal");
            Console.WriteLine("  2 - High");
            Console.Write("Choose: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && Enum.IsDefined(typeof(Priority), choice))
                return (Priority)choice;
            DisplayError("Invalid choice. Please try again.");
        }
    }

    public Status ReadStatus(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            Console.WriteLine("  0 - Planned");
            Console.WriteLine("  1 - Done");
            Console.WriteLine("  2 - Canceled");
            Console.Write("Choose: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && Enum.IsDefined(typeof(Status), choice))
                return (Status)choice;
            DisplayError("Invalid choice. Please try again.");
        }
    }

    public TimeRange ReadTimeRange(string prompt)
    {
        Console.WriteLine(prompt);
        DateTime start = ReadDateTime("  Start time (yyyy-MM-dd HH:mm): ");
        DateTime end = ReadDateTime("  End time (yyyy-MM-dd HH:mm): ");
        return new TimeRange(start, end);
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayError(string error)
    {
        ConsoleColor prev = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
        Console.ForegroundColor = prev;
    }

    public void ClearScreen()
    {
        Console.Clear();
    }
}
