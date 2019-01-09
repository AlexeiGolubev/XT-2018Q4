using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL
{
    public class FileHelper
    {
        public const string UsersDataPath = @"users_data.txt";
        public const string AwardsDataPath = @"awards_data.txt";
        public const string UsersAnsAwardsDataPath = @"users_and_awards_data.txt";
        public const char FileDataDelimiter = ';';

        public static Dictionary<int, User> ReadUsersData()
        {
            Dictionary<int, User> users = new Dictionary<int, User>();
            if (!File.Exists(UsersDataPath))
            {
                return users;
            }

            using (StreamReader sr = new StreamReader(UsersDataPath))
            {
                string buffer;
                string[] data;
                while (!sr.EndOfStream)
                {
                    buffer = sr.ReadLine();
                    data = buffer.Split(FileDataDelimiter);
                    try
                    {
                        int id = int.Parse(data[0]);
                        DateTime dateTime = DateTime.Parse(data[2]);
                        users.Add(
                            id,
                            new User()
                            {
                                Id = id,
                                Name = data[1],
                                DateOfBirth = dateTime,
                            });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return users;
        }

        public static void WriteUsersData(Dictionary<int, User> users)
        {
            if (!File.Exists(UsersDataPath))
            {
                File.Create(UsersDataPath).Close();
            }

            using (StreamWriter sw = new StreamWriter(UsersDataPath))
            {
                foreach (var item in users)
                {
                    sw.WriteLine($"{item.Value.Id}{FileDataDelimiter}{item.Value.Name}{FileDataDelimiter}{item.Value.DateOfBirth.ToShortDateString()}");
                }
            }
        }

        public static Dictionary<int, Award> ReadAwardsData()
        {
            Dictionary<int, Award> awards = new Dictionary<int, Award>();
            if (!File.Exists(AwardsDataPath))
            {
                return awards;
            }

            using (StreamReader sr = new StreamReader(AwardsDataPath))
            {
                string buffer;
                string[] data;
                while (!sr.EndOfStream)
                {
                    buffer = sr.ReadLine();
                    data = buffer.Split(FileDataDelimiter);
                    try
                    {
                        int id = int.Parse(data[0]);
                        awards.Add(
                            id,
                            new Award()
                            {
                                Id = id,
                                Title = data[1],
                            });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return awards;
        }

        public static void WriteAwardsData(Dictionary<int, Award> awards)
        {
            if (!File.Exists(AwardsDataPath))
            {
                File.Create(AwardsDataPath).Close();
            }

            using (StreamWriter sw = new StreamWriter(AwardsDataPath))
            {
                foreach (var item in awards)
                {
                    sw.WriteLine($"{item.Value.Id}{FileDataDelimiter}{item.Value.Title}");
                }
            }
        }

        public static List<AwardedUser> ReadAwardedUsersData()
        {
            List<AwardedUser> awardedUsers = new List<AwardedUser>();
            if (!File.Exists(UsersAnsAwardsDataPath))
            {
                return awardedUsers;
            }

            using (StreamReader sr = new StreamReader(UsersAnsAwardsDataPath))
            {
                string buffer;
                string[] data;
                while (!sr.EndOfStream)
                {
                    buffer = sr.ReadLine();
                    data = buffer.Split(FileDataDelimiter);
                    try
                    {
                        int idUser = int.Parse(data[0]);
                        int idAward = int.Parse(data[1]);
                        awardedUsers.Add(new AwardedUser()
                        {
                            IdUser = idUser,
                            IdAward = idAward,
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return awardedUsers;
        }

        public static void WriteAwardedUsersData(List<AwardedUser> awardedUsers)
        {
            if (!File.Exists(UsersAnsAwardsDataPath))
            {
                File.Create(UsersAnsAwardsDataPath).Close();
            }

            using (StreamWriter sw = new StreamWriter(UsersAnsAwardsDataPath))
            {
                foreach (var item in awardedUsers)
                {
                    sw.WriteLine($"{item.IdUser}{FileDataDelimiter}{item.IdAward}");
                }
            }
        }
    }
}
