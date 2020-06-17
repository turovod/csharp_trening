using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsGroupPresent())
            {
                app.Groups.Create(new GroupData("777") { Header = "777", Footer = "777" });
            }

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[0].Name = newData.Name;

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
