﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL
{
    public class UserDao : IUserDao
    {
        private readonly Dictionary<int, User> repoUsers = new Dictionary<int, User>();

        public UserDao()
        {
            this.repoUsers = FileHelper.ReadUsersData();
        }

        public void Add(User user)
        {
            var lastId = this.repoUsers.Any()
                ? this.repoUsers.Keys.Max()
                : 0;
            user.Id = ++lastId;
            this.repoUsers.Add(user.Id, user);
            FileHelper.WriteUsersData(this.repoUsers);
        }

        public void Delete(int id)
        {
            if (!this.repoUsers.Remove(id))
            {
                throw new Exception("User is not deleted");
            }

            FileHelper.WriteUsersData(this.repoUsers);
            FileHelper.RemoveImage(id, FileHelper.UserImagesPath);
        }

        public void Update(User user)
        {
            if (!this.repoUsers.ContainsKey(user.Id))
            {
                throw new Exception("User is not found");
            }

            this.repoUsers[user.Id] = user;
            FileHelper.WriteUsersData(this.repoUsers);
        }

        public User GetById(int id)
        {
            return this.repoUsers.TryGetValue(id, out var user)
                ? user
                : null;
        }

        public IEnumerable<User> GetAll()
        {
            return this.repoUsers.Values;
        }

        public void AddImage(int id, byte[] image)
        {
            FileHelper.WriteImage(id, image, FileHelper.UserImagesPath);
            User user = GetById(id);
            user.Image = image;
            Update(user);
        }

        public void RemoveImage(int id)
        {
            FileHelper.RemoveImage(id, FileHelper.UserImagesPath);
            User user = GetById(id);
            user.Image = null;
            Update(user);
        }
    }
}
