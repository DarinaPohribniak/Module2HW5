using Newtonsoft.Json;

namespace Module2HW5
{
    public static class FileService
    {
        private static Config? _config = new Config();
        private static string _configFile = string.Empty;
        public static void CreateLog(string data)
        {
            ReadPropertiesFromFile();
            CreateDirectory();
            WriteLog(data);
        }

        private static void ReadPropertiesFromFile()
        {
            try
            {
                _configFile = File.ReadAllText("..\\..\\..\\config.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            _config = JsonConvert.DeserializeObject<Config>(_configFile);
            if (_config == null)
            {
                throw new Exception();
            }
        }

        private static void CreateDirectory()
        {
            try
            {
                string path = _config!.LogPath! + _config.LogDirectoryName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void WriteLog(string message)
        {
            string filePath = _config!.LogPath + _config.LogDirectoryName;
            string fileName = "\\" + DateTime.Now.ToString("hh.mm.ss dd.MM.yyyy") + ".txt";
            string fullPathToFile = filePath + fileName;
            CheckAmountFiles(filePath);
            if (!File.Exists(fullPathToFile))
            {
                FileInfo file = new FileInfo(fullPathToFile);
            }

            using StreamWriter sw = new StreamWriter(fullPathToFile, false, System.Text.Encoding.UTF8);
            try
            {
                sw.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void CheckAmountFiles(string path)
        {
            var files = Directory.GetFiles(path);
            if (files.Length > 3)
            {
                FileSystemInfo fileInfo = new DirectoryInfo(path).GetFileSystemInfos().OrderBy(fi => fi.CreationTime).First();
                File.Delete($"{path}\\{fileInfo.Name}");
            }
        }
    }
}
