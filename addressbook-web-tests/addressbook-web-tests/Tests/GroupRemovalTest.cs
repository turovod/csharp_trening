using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBasse
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Groups.GoTpGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.RemoveGroup();
            app.Groups.ReturnToGroupsPage();
        }
     
    }
}
