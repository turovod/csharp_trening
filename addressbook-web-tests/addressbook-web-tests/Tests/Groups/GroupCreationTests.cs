
using Json.Net;
using Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

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
           // return JsonNet.Deserialize<List<GroupData>>(new StreamReader(@"groups.json"));
            return JsonNet.Deserialize<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();

            Excel.Application app = new Application();

            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));

            Excel.Worksheet sheet = wb.ActiveSheet;

            Excel.Range range = sheet.UsedRange;

            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value

                });
            }

            wb.Close();
            app.Visible = false;
            app.Quit();

            return groups;
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
        
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;

            List<GroupData> fromUI = app.Groups.GetGroupList();

            DateTime end = DateTime.Now;

            Console.WriteLine(end.Subtract(start));

            start = DateTime.Now;

            AdressBookDB dB = new AdressBookDB();

            List<GroupData> fromDB = (from g in dB.Grouos select g).ToList();

            dB.Close();

            end = DateTime.Now;

            Console.WriteLine(end.Subtract(start));


        }

    }
}
