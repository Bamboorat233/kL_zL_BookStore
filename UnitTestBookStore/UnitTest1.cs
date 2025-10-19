using BookStoreLIB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestBookStore
{
    [TestClass]
    public class UnitTest1
    {
        UserData userData = new UserData();
        string msg;


        [TestMethod]
        public void Test_Success_dclark_dc1234()
        {
            string inputName = "dclark";
            string inputPassword = "dc1234";

            bool expectedReturn = true;
            int expectedUserId = 1;

            bool actualReturn = userData.LogIn(inputName, inputPassword, out msg);
            int actualUserId = userData.UserID;

            Assert.AreEqual(expectedReturn, actualReturn, msg);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void Test_Fail_EmptyInputs()
        {
            bool ok = userData.LogIn("", "", out msg);
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void Test_Fail_PasswordTooShort()
        {
            bool ok = userData.LogIn("someone", "dc123", out msg); // 5 位
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void Test_Fail_PasswordTooLong()
        {
            bool ok = userData.LogIn("someone", "dc12345", out msg); // 7 位
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void Test_Fail_PasswordHasSymbol()
        {
            bool ok = userData.LogIn("someone", "dc12*4", out msg);
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void Test_Fail_PasswordOnlyLetters()
        {
            bool ok = userData.LogIn("someone", "abcdef", out msg);
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void Test_Fail_PasswordOnlyDigits()
        {
            bool ok = userData.LogIn("someone", "123456", out msg);
            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void Test_Fail_WrongCredentials()
        {
            bool ok = userData.LogIn("nosuchuser", "dc1234", out msg);
            Assert.IsFalse(ok);
        }
    }
}
