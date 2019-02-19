using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL
{
    public class AwardDao : IAwardDao
    {
        private readonly Dictionary<int, Award> repoAwards = new Dictionary<int, Award>();

        public AwardDao()
        {
            this.repoAwards = FileHelper.ReadAwardsData();
        }

        public void Add(Award award)
        {
            var lastId = this.repoAwards.Any()
                ? this.repoAwards.Keys.Max()
                : 0;
            award.Id = ++lastId;
            this.repoAwards.Add(award.Id, award);
            FileHelper.WriteAwardsData(this.repoAwards);
        }

        public void Delete(int id)
        {
            if (!this.repoAwards.Remove(id))
            {
                throw new Exception("Award is not deleted");
            }

            FileHelper.WriteAwardsData(this.repoAwards);
            FileHelper.RemoveImage(id, FileHelper.AwardImagesPath);
        }

        public void Update(Award award)
        {
            if (!this.repoAwards.ContainsKey(award.Id))
            {
                throw new Exception("Award is not found");
            }

            this.repoAwards[award.Id] = award;
            FileHelper.WriteAwardsData(this.repoAwards);
        }

        public Award GetById(int id)
        {
            return this.repoAwards.TryGetValue(id, out var award)
                ? award
                : null;
        }

        public IEnumerable<Award> GetAll()
        {
            return this.repoAwards.Values;
        }

        public void AddImage(int id, byte[] image)
        {
            FileHelper.WriteImage(id, image, FileHelper.AwardImagesPath);
            Award award = GetById(id);
            award.Image = image;
            Update(award);
        }

        public void RemoveImage(int id)
        {
            FileHelper.RemoveImage(id, FileHelper.AwardImagesPath);
            Award award = GetById(id);
            award.Image = null;
            Update(award);
        }
    }
}
