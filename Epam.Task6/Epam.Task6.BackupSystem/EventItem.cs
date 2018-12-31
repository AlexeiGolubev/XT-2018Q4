using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    [Serializable]
    public class EventItem
    {
        private DateTime dateCreated;
        private string nameFile;
        private string path;
        private string oldPathFile;
        private Operation operation;
        private string pathCopyFile;

        public EventItem()
        {
        }

        public EventItem(Operation variety, DateTime dateCreated, string nameFile, string path)
        {
            this.dateCreated = dateCreated;
            this.nameFile = nameFile;
            this.path = path;
            this.operation = variety;
        }

        public EventItem(Operation variety, DateTime dateCreated, string oldNameFile, string nameFile, string path)
        {
            this.dateCreated = dateCreated;
            this.nameFile = nameFile;
            this.path = path;
            this.oldPathFile = oldNameFile;
            this.operation = variety;
        }

        public DateTime DateCreated { get => this.dateCreated; set => this.dateCreated = value; }

        public string NameFile { get => this.nameFile; set => this.nameFile = value; }

        public string Path { get => this.path; set => this.path = value; }

        public string OldPathFile { get => this.oldPathFile; set => this.oldPathFile = value; }

        public string PathCopyFile { get => this.pathCopyFile; set => this.pathCopyFile = value; }

        internal Operation Operation { get => this.operation; set => this.operation = value; }

        public override bool Equals(object obj)
        {
            return obj is EventItem item &&
                   this.DateCreated == item.DateCreated &&
                   this.Path == item.Path &&
                   this.Operation == item.Operation;
        }

        public override int GetHashCode()
        {
            var hashCode = 2057857619;
            hashCode = (hashCode * -1521134295) + this.DateCreated.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.Path);
            hashCode = (hashCode * -1521134295) + this.Operation.GetHashCode();
            return hashCode;
        }
    }
}
