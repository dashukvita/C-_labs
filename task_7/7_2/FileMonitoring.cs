using System;
using System.IO;


namespace ConsoleApp1
{
    class FileMonitoring
    {
        private string fullFileName;
        private string logFileName;
        public void startMonitoring(string getFileName, string getLogFileName)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            fullFileName = getFileName;
            logFileName = getLogFileName;
            CreateLogFile(logFileName);

            watcher.Path = Path.GetDirectoryName(fullFileName);
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
            watcher.Filter = "*.cs";

            watcher.Deleted += new FileSystemEventHandler(OnDelete);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreate);
            watcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            string str = DateTime.Now + "\t" + e.Name + "\t\t" + e.ChangeType.ToString().ToUpper();
            Console.WriteLine(str);
            WrightToLogFile(logFileName, str);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            string str = DateTime.Now + "\t" + e.Name + "\t\t" + e.ChangeType.ToString().ToUpper();
            Console.WriteLine(str);
            WrightToLogFile(logFileName, str);
        }

        private void OnDelete(object source, FileSystemEventArgs e)
        {
            string str = DateTime.Now + "\t" + e.Name + "\t\t" + e.ChangeType.ToString().ToUpper();
            Console.WriteLine(str);
            WrightToLogFile(logFileName, str);
        }
        private void OnCreate(object source, FileSystemEventArgs e)
        {
            string str = DateTime.Now + "\t" + e.Name + "\t\t" + e.ChangeType.ToString().ToUpper();
            Console.WriteLine(str);
            WrightToLogFile(logFileName, str);
        }

        private void CreateLogFile(string FileName)
        {
            try
            {
                string tempPath = Path.GetTempPath();
                logFileName = Path.Combine(tempPath, FileName);
                File.AppendAllText(logFileName, "Date, Time:\t\tName:\t\t\t\tChange Type:" + Environment.NewLine);
                File.AppendAllText(logFileName, "-------------------------------------------------------" + Environment.NewLine);
                Console.WriteLine($"Cоздали log файл: {logFileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void WrightToLogFile(string fileName, string str)
        {
            try
            {
                File.AppendAllText(fileName, str + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
