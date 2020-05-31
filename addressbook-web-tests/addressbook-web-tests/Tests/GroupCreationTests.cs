
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBasse
    {       
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            app.Navigator.GoToGroupsPage();
            app.Groups
                .InitNewGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreatin();
            app.AuthOut.Logout();
        }      
    }
}
