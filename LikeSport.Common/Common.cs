using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LikeSport.Common
{
    public class Common
    {
        public const string Url = "http://localhost:52614/api/";
        private static readonly string[] VietnameseSigns = new string[]
        {

                     "aAeEoOuUiIdDyY",

                    "áàạảãâấầậẩẫăắằặẳẵ",

                    "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

                    "éèẹẻẽêếềệểễ",

                    "ÉÈẸẺẼÊẾỀỆỂỄ",

                    "óòọỏõôốồộổỗơớờợởỡ",

                    "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

                    "úùụủũưứừựửữ",

                    "ÚÙỤỦŨƯỨỪỰỬỮ",

                    "íìịỉĩ",

                    "ÍÌỊỈĨ",

                    "đ",

                    "Đ",

                    "ýỳỵỷỹ",

                    "ÝỲỴỶỸ"

        };
        public static string RemoveSign4VietnameseString(string str)

        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]).Trim();

            }
            return Regex.Replace(str.Trim().ToLower(), @"[^0-9a-zA-Z]+", "-"); ; ;

        }
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
