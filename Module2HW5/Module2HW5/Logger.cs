namespace Module2HW5
{
    public class Logger
    {
        private static readonly List<LogItem> Data = new List<LogItem>();
        private static Logger? instance;

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }

                return instance;
            }
        }

        public static void AddLog(LogType type, string message)
        {
            Data.Add(new LogItem(type, message));
        }

        public List<LogItem> GetData()
        {
            return Data;
        }
    }
}
