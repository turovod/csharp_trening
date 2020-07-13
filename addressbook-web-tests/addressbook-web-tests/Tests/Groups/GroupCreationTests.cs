
using Json.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();

            string[] line = File.ReadAllLines(@"groups.csv");

            foreach (var item in line)
            {
                string[] parts = item.Split(',');

                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"))
                                                                                        as List<GroupData>; 
        }


        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonNet.Deserialize<List<GroupData>>(new StreamReader(@"groups.xml"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
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
