namespace KledsonZG.FastRequestSelector
{
    public static class Logger
    {
        private static object _locker = new();
        private static DateTime _now = DateTime.Now;
        private static string _fileNameFormat = Configuration.LoggingPath + $"{_now.Year}-{(_now.Month < 10 ? $"0{_now.Month}" : _now.Month)}-{(_now.Day < 10 ? $"0{_now.Day}" : _now.Day)}" + 
            $" {(_now.Hour < 10 ? $"0{_now.Hour}" : _now.Hour)}-{(_now.Minute < 10 ? $"0{_now.Minute}" : _now.Minute)}-{(_now.Second < 10 ? $"0{_now.Second}" : _now.Second)}.txt";

        public static void Log(string text)
        {
            if(!Configuration.EnableLogging)
                return;
            
            lock(_locker)
            {
                if(!Directory.Exists(Configuration.LoggingPath) )
                    Directory.CreateDirectory(Configuration.LoggingPath);
            
                using (var writer = new StreamWriter(File.Open(_fileNameFormat, FileMode.Append) ) )
                {
                    writer.WriteLine(text);
                }
            }
        }
    }
}