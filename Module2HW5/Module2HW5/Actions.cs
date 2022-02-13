namespace Module2HW5
{
    public class Actions
    {
        public bool Action1()
        {
            Logger.AddLog(LogType.Info, "Start method: Action1");
            return true;
        }

        public BusinessException Action2()
        {
            return new BusinessException("Skipped logic in method");
        }

        public void Action3()
        {
            throw new Exception("I broke a logic");
        }
    }
}
