
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {  
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            //GroupData group = new GroupData("aaa");
            //group.Header = "bbb";
            //group.Footer = "ccc";

            List<GroupData> oldGroups = app.Groups.GetGroupList();
    
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
