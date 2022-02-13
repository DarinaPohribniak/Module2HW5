namespace Module2HW5
{
    public class LogItem
    {
        public LogItem(LogType type, string message)
        {
            Date = DateTime.Now;
            Type = type;
            Message = message;
        }

        public DateTime Date { get; }

        public LogType Type { get; }

        public string Message { get; }
    }
}
