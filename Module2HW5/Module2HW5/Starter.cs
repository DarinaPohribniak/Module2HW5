using System.Text;

namespace Module2HW5
{
    public static class Starter
    {
        public static void Run()
        {
            var random = new Random();
            var action = new Actions();

            for (int i = 0; i < 100; i++)
            {
                int actionIndex = random.Next(1, 4);
                bool result;
                switch (actionIndex)
                {
                    case 1:
                        result = action.Action1();
                        break;
                    case 2:
                        var ex = action.Action2();
                        Logger.AddLog(LogType.Warning, $"Action got this custom Exception: {ex.Message}");
                        break;
                    case 3:
                        try
                        {
                            action.Action3();
                        }
                        catch (Exception ex2)
                        {
                            Logger.AddLog(LogType.Error, $"Action failed by reason: {ex2}");
                        }

                        break;
                }
            }

            StringBuilder builder = ComposeData();
            FileService.CreateLog(builder.ToString());

            Console.ReadLine();
        }

        private static StringBuilder ComposeData()
        {
            var data = Logger.Instance.GetData();
            StringBuilder builder = new StringBuilder();
            foreach (var item in data)
            {
                builder.Append($"{item.Date}: {item.Type}: {item.Message}\n");
            }

            return builder;
        }
    }
}
