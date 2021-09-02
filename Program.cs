using System;

using System.Xml;

namespace XMLReaderWriterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlWriter xmlWriter = XmlWriter.Create("D:\\wizzie\\DOT NET\\XMLReaderWriterDemo\\Dept.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Departments");

            xmlWriter.WriteStartElement("Department");
            xmlWriter.WriteAttributeString("Id", "1001");
            xmlWriter.WriteString("Purchase");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Department");
            xmlWriter.WriteAttributeString("Id", "1002");
            xmlWriter.WriteString("Sales");

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            using (XmlReader reader = XmlReader.Create("D:\\wizzie\\DOT NET\\XMLReaderWriterDemo\\Dept.xml"))
            {
                while (reader.Read())
                {
                    //if (reader.IsStartElement())
                    //{
                    //return only when you have START tag  
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.WriteLine("{0}", reader.Name);
                            break;
                        case XmlNodeType.Text:
                            Console.WriteLine(reader.Value);
                            break;
                    }
                    //}
                    Console.WriteLine("");
                }
            }
            using (XmlReader reader = XmlReader.Create("D:\\wizzie\\DOT NET\\XMLReaderWriterDemo\\Dept.xml"))
            {
                while (reader.Read())
                {
                    reader.ReadToFollowing("Department");
                    reader.MoveToContent();
                    string success = reader.GetAttribute("Id");
                    Console.WriteLine(success);
                }
            }
        }
    }
}
