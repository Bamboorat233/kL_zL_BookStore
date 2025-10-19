/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookStoreLIB
{
    public class UserData
    {
        public int UserID { set; get; }
        public string LoginName { set; get; }
        public string Password { set; get; }
        public Boolean LoggedIn { set; get; }

        public bool LogIn(string loginName, string passWord, out string eMassage)
        {
            eMassage = "";
            if (IsNullOrWhiteSpace(loginName) || IsNullOrWhiteSpace(passWord)) {
                eMassage = "Login name or password cannot be empty.";
                return false;
            }


            if (passWord.Length != 6) {
                eMassage = "Password must be exactly 6 characters long.";
                return false;
            }
                

            if (!IsAlphaNumeric(passWord) || !HasLetterAndDigit(passWord)) {
                eMassage = "Password must be alphanumeric and contain at least one letter and one digit.";
                return false;
            }
                

            var dbUser = new DALUserInfo();
            int id = dbUser.LogIn(loginName, passWord);

            if (id > 0)
            {
                UserID = id;
                LoginName = loginName;
                Password = passWord;
                LoggedIn = true;
                return true;
            }
            else
            {
                LoggedIn = false;
                return false;
            }
        }
        private bool IsNullOrWhiteSpace(string s)
        {
            if (s == null) return true;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!(c == ' ' || c == '\t' || c == '\r' || c == '\n'))
                    return false;
            }
            return true;
        }

        private bool IsAlphaNumeric(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!IsAsciiLetter(c) && !IsAsciiDigit(c))
                    return false;
            }
            return true;
        }

        private bool IsAsciiLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }

        private bool IsAsciiDigit(char c)
        {
            return (c >= '0' && c <= '9');
        }

        private bool HasLetterAndDigit(string s)
        {
            bool hasL = false, hasD = false;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (IsAsciiLetter(c)) hasL = true;
                if (IsAsciiDigit(c)) hasD = true;
                if (hasL && hasD) return true;
            }
            return false;
        }
    }
}
