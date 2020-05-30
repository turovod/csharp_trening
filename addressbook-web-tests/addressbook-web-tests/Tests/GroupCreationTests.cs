
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBasse
    {       
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreatin();
            app.AuthOut.Logout();
        }      
    }
}
