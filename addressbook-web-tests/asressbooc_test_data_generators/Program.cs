using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using WebAddressbookTests;
using Json.Net;
using Excel = Microsoft.Office.Interop.Excel;



namespace asressbooc_test_data_generators
{
    class Program
    {

        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);

            string filenameGroup = args[1];
            string filenameContact = args[2];


        string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContactsData> contacts = new List<ContactsData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBasse.GenerateRandomString(10))
                {
                    Header = TestBasse.GenerateRandomString(10),
                    Footer = TestBasse.GenerateRandomString(10)
                });

                contacts.Add(new ContactsData(TestBasse.GenerateRandomString(10), "admin", "secret")
                {
                    MiddleName = TestBasse.GenerateRandomString(20),
                    LastName = TestBasse.GenerateRandomString(20),
                    Nickname = TestBasse.GenerateRandomString(20),
                    Company = TestBasse.GenerateRandomString(20),
                    Title = TestBasse.GenerateRandomString(20),
                    Address = TestBasse.GenerateRandomString(20),
                    Home = TestBasse.GenerateRandomString(20),
                    Mobile = TestBasse.GenerateRandomString(20),
                    Work = TestBasse.GenerateRandomString(20),
                    Fax = TestBasse.GenerateRandomString(20),
                    Email = TestBasse.GenerateRandomString(20),
                    Email2 = TestBasse.GenerateRandomString(20),
                    Email3 = TestBasse.GenerateRandomString(20),
                    Homepage = TestBasse.GenerateRandomString(20),
                    BDay = TestBasse.GenerateRandomDay(),
                    BMonth = TestBasse.GenerateRandomString(20),
                    BYear = TestBasse.GenerateRandomYer(),
                    ADay = TestBasse.GenerateRandomDay(),
                    AMonth = TestBasse.GenerateRandomString(20),
                    AYear = TestBasse.GenerateRandomYer(),
                    SAddress = TestBasse.GenerateRandomString(20),
                    SHome = TestBasse.GenerateRandomString(20),
                    SNotes = TestBasse.GenerateRandomString(20),
                });
            }

            if (format == "excel")
            {
                writeGroupsToExcelFile(groups, filenameGroup);
            }
            else
            {
                StreamWriter writerGroup = new StreamWriter(filenameGroup);
                StreamWriter writerContact = new StreamWriter(filenameContact);

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writerGroup);

                }
                else if (format == "xml")
                {
                    writwGroupsToXmlFile(groups, writerGroup);
                    writwContactsToXmlFile(contacts, writerContact);
                }
                else if (format == "json")
                {
                    writwGroupsToJsonFile(groups, writerGroup);
                    writwContactsToJsonFile(contacts, writerContact);
                }

                else
                {
                    Console.WriteLine("Unrecognased format " + format);
                }
                writerGroup.Close();
            }
            
             
        }

        private static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();

            //app.Visible = true;

            Excel.Workbook wb = app.Workbooks.Add();

            Excel.Worksheet sheet = wb.ActiveSheet;

            for (int i = 0; i < groups.Count; i++)
            {
                sheet.Cells[(i + 1), 1] = groups[i].Name;
                sheet.Cells[(i + 1), 2] = groups[i].Header;
                sheet.Cells[(i + 1), 3] = groups[i].Footer;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);

            File.Delete(fullPath);

            wb.SaveAs(fullPath);

            wb.Close();

            app.Quit();

        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine($"{group.Name}, {group.Header}, {group.Footer}");
            }
        }

        static void writwGroupsToXmlFile(List<GroupData> groups, StreamWriter writer    )
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        
        static void writwContactsToXmlFile(List<ContactsData> contacts, StreamWriter writer    )
        {
            new XmlSerializer(typeof(List<ContactsData>)).Serialize(writer, contacts);
        }

        static void writwGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonNet.Serialize(groups));
        }        
        
        static void writwContactsToJsonFile(List<ContactsData> contacts, StreamWriter writer)
        {
            writer.Write(JsonNet.Serialize(contacts));
        }

    }
}
