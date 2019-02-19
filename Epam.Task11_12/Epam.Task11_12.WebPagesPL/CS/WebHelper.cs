using Epam.Task7.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;

namespace Epam.Task11_12.WebPagesPL.CS
{
    public static class WebHelper
    {
        private const string DefaultUserImageFilePath = "/Content/images/imgUser.png";
        private const string DefaultAwardImageFilePath = "/Content/images/imgAward.png";

        public static bool CheckName(this string name)
        {
            if (name.Length < 1 || name.Length > 30)
            {
                return false;
            }

            return true;
        }

        public static bool CheckDate(this DateTime date)
        {
            DateTime now = DateTime.Now;

            if (now.Year - date.Year > 150 || date > now)
            {
                return false;
            }

            return true;
        }

        public static bool CheckTitle(this string title)
        {
            if (title.Length < 1 || title.Length > 100)
            {
                return false;
            }

            return true;
        }

        public static bool CheckEmailFormat(string email)
        {
            string emailTemplate = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            return Regex.IsMatch(email, emailTemplate, RegexOptions.IgnoreCase);
        }

        public static bool CheckLoginFormat(string login)
        {
            string loginTemplate = "^[a-zA-Z]{3,30}$";
            
            return Regex.IsMatch(login, loginTemplate, RegexOptions.IgnoreCase);
        }

        public static bool CheckPasswordFormat(string password, string repeatPassword)
        {
            string passwordTemplate = "^[a-zA-Z0-9]{5,30}$";

            return Regex.IsMatch(password, passwordTemplate, RegexOptions.IgnoreCase)
                && password == repeatPassword;
        }

        public static bool CheckPasswordFormat(string password)
        {
            string passwordTemplate = "^[a-zA-Z0-9]{5,30}$";

            return Regex.IsMatch(password, passwordTemplate, RegexOptions.IgnoreCase);
        }

        public static string GetUserImagePath(User user)
        {
            if (user.Image != null)
            {
                WebImage img = new WebImage(user.Image);

                return $"data:image/{img.ImageFormat};base64,{Convert.ToBase64String(user.Image)}";
            }

            return DefaultUserImageFilePath;
        }

        public static string GetAwardImagePath(Award award)
        {
            if (award.Image != null)
            {
                WebImage img = new WebImage(award.Image);

                return $"data:image/{img.ImageFormat};base64,{Convert.ToBase64String(award.Image)}";
            }

            return DefaultAwardImageFilePath;
        }

        public static void WorkWithImage(WebImage img, int x, int y)
        {
            int width = img.Width;
            int height = img.Height;
            int sizeDiff = width - height;

            if (sizeDiff > 0)
            {
                img.Crop(0, sizeDiff / 2, 0, sizeDiff / 2);
            }
            else if (sizeDiff < 0)
            {
                sizeDiff = ~sizeDiff + 1;

                img.Crop(sizeDiff / 2, 0, sizeDiff / 2, 0);
            }

            img.Resize(x, y);
        }
    }
}