using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public class Menu
    {
        private readonly FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
        private BackupManager backupManager = new BackupManager("backup");

        public void MenuItem()
        {
            while (true)
            {
                int number = this.MenuItemChoose();
                switch (number)
                {
                    case 0:
                        {
                            this.WhenMenuQuit(this);
                            Environment.Exit(0);
                        }

                        break;
                    case 1:
                        {
                            this.Watch(this);
                        }

                        break;
                    case 2:
                        {
                            this.Backup(this);
                        }

                        break;
                }
            }
        }

        private int MenuItemChoose()
        {
            int number = 0;
            bool success = false;
            do
            {
                Console.WriteLine("Choose menu item:");
                Console.WriteLine(" 1 - watch");
                Console.WriteLine(" 2 - back up");
                Console.WriteLine(" 0 - quit");
                success = int.TryParse(Console.ReadLine(), out number);
                if (number < 0 || number > 2)
                {
                    success = false;
                }
            }
            while (!success);
            return number;
        }

        private bool IsEmptyChange(string name, DateTime date)
        {
            if (this.backupManager.Events.Count != 0)
            {
                var lastEvent = this.backupManager.Events[this.backupManager.Events.Count - 1];
                if (lastEvent.NameFile == name
                    && lastEvent.DateCreated >= date.AddMilliseconds(-200))
                {
                    return true;
                }
            }

            return false;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!this.IsEmptyChange(e.Name, DateTime.Now))
            {
                DateTime dt = DateTime.Now;
                Console.WriteLine($"Change: {e.Name} ----- {dt}");
                EventItem item = new EventItem(Operation.Change, dt, e.Name, e.FullPath);
                this.backupManager.CopyFile(e.FullPath, item);
                this.backupManager.Events.Add(item);
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine($"Create: {e.Name} ----- {dt}");
            EventItem item = new EventItem(Operation.Creature, dt, e.Name, e.FullPath);
            this.backupManager.CopyFile(e.FullPath, item);
            this.backupManager.Events.Add(item);
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine($"Delete: {e.Name} ----- {dt}");
            EventItem item = new EventItem(Operation.Deletion, dt, e.Name, e.FullPath);
            this.backupManager.Events.Add(item);
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine($"Rename: {e.OldName} in {e.Name} ----- {dt}");
            EventItem item = new EventItem(Operation.Renaming, dt, e.OldFullPath, e.Name, e.FullPath);
            this.backupManager.Events.Add(item);
        }

        private void Watch(object sender)
        {
            Console.WriteLine("Print the directory: ");
            var path = string.Empty;
            DirectoryInfo dirInfo;
            do
            {
                path = Console.ReadLine();
                dirInfo = new DirectoryInfo(path);
            }
            while (!dirInfo.Exists);

            this.backupManager.PathTarget = path;

            this.fileSystemWatcher.Path = this.backupManager.PathTarget;
            this.fileSystemWatcher.Filter = "*.txt";
            this.fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            this.fileSystemWatcher.IncludeSubdirectories = true;

            this.fileSystemWatcher.Changed += new FileSystemEventHandler(this.OnChanged);
            this.fileSystemWatcher.Created += new FileSystemEventHandler(this.OnCreated);
            this.fileSystemWatcher.Deleted += new FileSystemEventHandler(this.OnDeleted);
            this.fileSystemWatcher.Renamed += new RenamedEventHandler(this.OnRenamed);

            Console.WriteLine("Selected folder for watch: " + this.backupManager.PathTarget);
            if (File.Exists($"{backupManager.PathBackup}/backupEvents.dat"))
            {
                this.AskAboutRecovery();
                this.ShowEvents();
            }

            this.fileSystemWatcher.EnableRaisingEvents = true;

            this.Quit();
        }

        private void AskAboutRecovery()
        {
            char answer = ' ';
            bool success = false;
            do
            {
                Console.WriteLine("Do you want to restore the history of the previous watch? (y/n)");
                success = char.TryParse(Console.ReadLine(), out answer);
                if (answer != 'y')
                {
                    success = false;
                }
            }
            while (!success);
            this.backupManager.Deserialize();
        }

        private void ShowEvents()
        {
            foreach (var item in this.backupManager.Events)
            {
                Console.WriteLine($"{item.Operation}: {item.NameFile} ----- {item.DateCreated}");
            }
        }

        private void Quit()
        {
            var quit = ' ';
            bool success = false;
            do
            {
                Console.WriteLine("Print 'q' for stop watching and quit to menu");
                Console.WriteLine();
                success = char.TryParse(Console.ReadLine(), out quit);
                if (quit != 'q')
                {
                    success = false;
                }
            }
            while (!success);
            this.StopWatch(this);
        }

        private void StopWatch(object sender)
        {
            this.fileSystemWatcher.EnableRaisingEvents = false;
            this.backupManager.SetCurrentTime();
        }

        private void Backup(object sender)
        {
            DateTime currentDate;
            bool success = false;
            do
            {
                Console.WriteLine("Print date");
                success = DateTime.TryParse(Console.ReadLine(), out currentDate);
            }
            while (!success);

            if (this.backupManager.Events.Count != 0)
            {
                this.backupManager.Backup(currentDate);
            }
        }

        private void WhenMenuQuit(object sender)
        {
            this.backupManager.Serialize();
        }
    }
}
