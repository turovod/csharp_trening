using NUnit.Framework;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBasse
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random random = new Random();

        public static string GenerateRandomString(int max)
        {
            Random random = new Random();

            int l = random.Next(0, max);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(random.Next(0, 223))));
            }

            return builder.ToString();
        }

        public static string GenerateRandomYer()
        {
            StringBuilder builder = new StringBuilder();

            return  (builder.Append("2").Append(random.Next(0, 2)).Append(random.Next(0, 9)).Append(random.Next(0, 9))).ToString();
        }

        public static string GenerateRandomDay()
        {
            StringBuilder builder = new StringBuilder();

            return (builder.Append(random.Next(0, 3)).Append(random.Next(0, 9))).ToString();
        }

    }
}
