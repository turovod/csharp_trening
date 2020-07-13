using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using WebAddressbookTests;
using Json.Net;
using Microsoft.


namespace asressbooc_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);

            string filename = args[1];

            string format = args[2];

            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBasse.GenerateRandomString(10))
                {
                    Header = TestBasse.GenerateRandomString(10),
                    Footer = TestBasse.GenerateRandomString(10)
                });
            }

            if (format == "excel")
            {
                writeGroupsToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);

                }
                else if (format == "xml")
                {
                    writwGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writwGroupsToJsonFile(groups, writer);
                }

                else
                {
                    Console.WriteLine("Unrecognased format" + format);
                }
                writer.Close();
            }
            
             
        }

        private static void writeGroupsToExcelFile(List<GroupData> groups, string v)
        {
            throw new NotImplementedException();
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

        static void writwGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonNet.Serialize(groups));
        }

    }
}
