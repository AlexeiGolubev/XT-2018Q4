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
        public static Dictionary<int, User> ReadUsersData()
        {
            Dictionary<int, User> users = new Dictionary<int, User>();
            if (!File.Exists(Constants.USERS_DATA_PATH))
            {
                return users;
            }

            using (StreamReader sr = new StreamReader(Constants.USERS_DATA_PATH))
            {
                string buffer;
                string[] data;
                while (!sr.EndOfStream)
                {
                    buffer = sr.ReadLine();
                    data = buffer.Split(Constants.FILE_DATA_DELIMITIER);
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
            if (!File.Exists(Constants.USERS_DATA_PATH))
            {
                File.Create(Constants.USERS_DATA_PATH).Close();
            }

            using (StreamWriter sw = new StreamWriter(Constants.USERS_DATA_PATH))
            {
                foreach (var item in users)
                {
                    sw.WriteLine($"{item.Value.Id}{Constants.FILE_DATA_DELIMITIER}{item.Value.Name}{Constants.FILE_DATA_DELIMITIER}{item.Value.DateOfBirth.ToShortDateString()}");
                }
            }
        }
    }
}
