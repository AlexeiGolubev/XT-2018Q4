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
        public static string UsersDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"users_data.txt");
        public static string AwardsDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"awards_data.txt");
        public static string UsersAnsAwardsDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"users_and_awards_data.txt");
        public static string AccountsDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"accounts_data.txt");
        public const char FileDataDelimiter = ';';

        public static Dictionary<int, User> ReadUsersData()
        {
            Dictionary<int, User> users = new Dictionary<int, User>();
            if (!File.Exists(UsersDataPath))
            {
                return users;
            }
            //if (ConfigurationManager.AppSettings["UsersDaoKey"] == "file")
            //{
            //    if (!File.Exists(ConfigurationManager.AppSettings["UserDaoFilePath"]))
            //    {
            //        return users;
            //    }
            //}
            //else
            //{
            //    if (!File.Exists(UsersDataPath))
            //    {
            //        return users;
            //    }
            //}

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

        public static Dictionary<int, Account> ReadAccountsData()
        {
            Dictionary<int, Account> accounts = new Dictionary<int, Account>();
            if (!File.Exists(AccountsDataPath))
            {
                return accounts;
            }

            using (StreamReader sr = new StreamReader(AccountsDataPath))
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
                        accounts.Add(id, new Account(id: id, login: data[1], password: data[2], email: data[3], role: data[4]));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return accounts;
        }

        public static void WriteAccountsData(Dictionary<int, Account> accounts)
        {
            if (!File.Exists(AccountsDataPath))
            {
                File.Create(AccountsDataPath).Close();
            }

            using (StreamWriter sw = new StreamWriter(AccountsDataPath))
            {
                foreach (var item in accounts)
                {
                    sw.WriteLine($"{item.Value.Id}{FileDataDelimiter}{item.Value.Login}{FileDataDelimiter}{item.Value.Password}{FileDataDelimiter}{item.Value.Email}{FileDataDelimiter}{item.Value.Role}");
                }
            }
        }
    }
}
