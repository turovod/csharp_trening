using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsGroupPresent())
            {
                app.Groups.Create(new GroupData("777") { Header = "777", Footer = "777" });
            }

            app.Groups.Remove(1);
            
        }
     
    }
}
