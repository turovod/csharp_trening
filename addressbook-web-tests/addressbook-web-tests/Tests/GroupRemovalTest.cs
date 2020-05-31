using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBasse
    {
        [Test]
        public void GroupRemovalTest()
        {
            
            app.Groups
                .GoTpGroupsPage()
                .SelectGroup(1)
                .RemoveGroup()
                .ReturnToGroupsPage();
        }
     
    }
}
