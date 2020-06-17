using NUnit.Framework;
using System.Collections.Generic;

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

            List<GroupData> olgGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            olgGroups.RemoveAt(0);

            Assert.AreEqual(olgGroups, newGroups);
        }

    }
}
