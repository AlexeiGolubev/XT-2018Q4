using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Epam.Task6.BackupSystem
{
    public class BackupManager
    {
        private List<EventItem> events = new List<EventItem>();
        private string pathBackup;
        private string pathTarget;
        private DateTime currentTime;
        private DateTime lastTargetTime;
        private int indexCurrentEvent;

        public BackupManager(string pathBackup)
        {
            this.PathBackup = pathBackup;
            DirectoryInfo dirInfo = new DirectoryInfo(this.PathBackup);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }

        public string PathTarget { get => this.pathTarget; set => this.pathTarget = value; }

        public string PathBackup { get => this.pathBackup; set => this.pathBackup = value; }

        internal List<EventItem> Events { get => this.events; set => this.events = value; }

        public static bool FileIsLocked(string filePath)
        {
            bool isLocked = false;
            try
            {
                bool tmp = File.Exists(filePath);
            }
            catch (IOException)
            {
                isLocked = true;
            }

            return isLocked;
        }

        public void SetCurrentTime()
        {
            if (this.Events.Count != 0)
            {
                this.indexCurrentEvent = this.Events.Count - 1;
                this.currentTime = this.Events[this.indexCurrentEvent].DateCreated;
                this.lastTargetTime = this.currentTime;
            }
        }

        public void CopyFile(string path, EventItem e)
        {
            FileInfo fileInf = new FileInfo(path);
            bool repeat = true;
            while (repeat)
            {
                repeat = FileIsLocked(path);
            }

            e.PathCopyFile = $"{PathBackup}/{e.GetHashCode()}.txt";
            File.Copy(path, e.PathCopyFile, true);
        }

        public void Backup(DateTime targetTime)
        {
            if (this.currentTime == targetTime
                || this.lastTargetTime == targetTime
                || this.Events.Count == 0)
            {
                return;
            }

            int indexTargetEvent = this.FindIndexEventTarget(targetTime);

            if (this.indexCurrentEvent >= indexTargetEvent && targetTime < this.currentTime)
            {
                if (this.indexCurrentEvent == 0 && this.currentTime >= this.lastTargetTime)
                {
                    return;
                }

                for (int i = this.indexCurrentEvent; i >= indexTargetEvent; i--)
                {
                    this.Rollback(i);
                }

                this.indexCurrentEvent = indexTargetEvent == 0 ? 0 : indexTargetEvent - 1;
            }
            else if (this.indexCurrentEvent <= indexTargetEvent && targetTime > this.currentTime)
            {
                if (this.indexCurrentEvent == this.Events.Count - 1 && this.currentTime <= this.lastTargetTime)
                {
                    return;
                }

                int i = 0;
                if (this.lastTargetTime <= this.Events[0].DateCreated)
                {
                    i = this.indexCurrentEvent;
                }
                else
                {
                    i = this.indexCurrentEvent + 1;
                }

                for (; i <= indexTargetEvent; i++)
                {
                    this.ReverseRollback(i);
                }

                this.indexCurrentEvent = indexTargetEvent;
            }

            this.currentTime = this.Events[this.indexCurrentEvent].DateCreated;
            this.lastTargetTime = targetTime;
        }

        public void Serialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream($"{PathBackup}/backupEvents.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this.Events);
            }
        }

        public void Deserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream($"{PathBackup}/backupEvents.dat", FileMode.OpenOrCreate))
            {
                this.Events = (List<EventItem>)formatter.Deserialize(fs);
            }

            if (this.Events.Count != 0)
            {
                this.indexCurrentEvent = this.Events.Count - 1;
                this.currentTime = this.Events[this.indexCurrentEvent].DateCreated;
            }
        }

        public void ResetAfterBackup()
        {
            this.Events = this.Events.GetRange(0, this.indexCurrentEvent);
        }

        private int FindIndexEventTarget(DateTime targetTime)
        {
            int indexTargetEvent = 0;
            if (targetTime >= this.Events[this.Events.Count - 1].DateCreated)
            {
                return this.Events.Count - 1;
            }

            if (targetTime <= this.Events[0].DateCreated)
            {
                return 0;
            }

            if (this.currentTime > targetTime)
            {
                for (int i = this.indexCurrentEvent; i >= 0; i--)
                {
                    if (this.Events[i].DateCreated == targetTime)
                    {
                        return i;
                    }

                    if (this.Events[i].DateCreated < targetTime)
                    {
                        return i + 1;
                    }
                }
            }
            else
            {
                for (int i = this.indexCurrentEvent; i < this.Events.Count; i++)
                {
                    if (this.Events[i].DateCreated == targetTime)
                    {
                        return i;
                    }

                    if (this.Events[i].DateCreated > targetTime)
                    {
                        return i - 1;
                    }
                }
            }

            return indexTargetEvent;
        }

        private void Rollback(int i)
        {
            switch (this.Events[i].Operation)
            {
                case Operation.Creature:
                    File.Delete(this.Events[i].Path);
                    break;
                case Operation.Change:
                    File.Copy(this.Events[this.FindIndexDeleteFile(i)].PathCopyFile, this.Events[i].Path, true);
                    break;
                case Operation.Deletion:
                    this.CreateFoldersToFile(i);
                    File.Copy(this.Events[this.FindIndexDeleteFile(i)].PathCopyFile, this.Events[i].Path, true);
                    break;
                case Operation.Renaming:
                    File.Move(this.Events[i].Path, this.Events[i].OldPathFile);
                    break;
                default:
                    break;
            }
        }

        private void ReverseRollback(int i)
        {
            switch (this.Events[i].Operation)
            {
                case Operation.Creature:
                    this.CreateFoldersToFile(i);
                    File.Copy(this.Events[i].PathCopyFile, this.Events[i].Path);
                    break;
                case Operation.Change:
                    File.Copy(this.Events[i].PathCopyFile, this.Events[i].Path, true);
                    break;
                case Operation.Deletion:
                    File.Delete(this.Events[i].Path);
                    break;
                case Operation.Renaming:
                    File.Move(this.Events[i].OldPathFile, this.Events[i].Path);
                    break;
                default:
                    break;
            }
        }

        private int FindIndexDeleteFile(int index)
        {
            string path = this.Events[index].Path;
            for (int i = index - 1; i >= 0; i--)
            {
                if (this.Events[i].Operation == Operation.Renaming)
                {
                    if (path == this.Events[i].Path)
                    {
                        path = this.Events[i].OldPathFile;
                    }
                }
                else if (this.Events[i].Operation == Operation.Creature || this.Events[i].Operation == Operation.Change)
                {
                    if (path == this.Events[i].Path)
                    {
                        return i;
                    }
                }
            }

            return 0;
        }

        private void CreateFoldersToFile(int i)
        {
            string pathToFile = this.Events[i].Path.Substring(0, this.Events[i].Path.Length - this.Events[i].NameFile.Length - 1);
            if (!Directory.Exists(pathToFile))
            {
                Directory.CreateDirectory(pathToFile);
            }
        }
    }
}
