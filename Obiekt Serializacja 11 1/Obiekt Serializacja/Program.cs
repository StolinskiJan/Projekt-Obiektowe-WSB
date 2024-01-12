using System.Net.Cache;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
/*
namespace Obiekt_Serializacja_8_3
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { FirstName = "Franek", LastName = "Kowalski", Age = 21 };
            XmlSerializer serializer = new XmlSerializer(typeof(Person));

            using (FileStream s = File.Create("osoba.xml"))
            {
                serializer.Serialize(s, person);

            }

            

        }
    }
}
*/


namespace Obiekt_Serializacja_8_3_1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public XmlSchema? GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            FirstName = reader.GetAttribute("FirstName", FirstName);
            LastName = reader.GetAttribute("LastName",FirstName);
            Age = int.Parse(reader.GetAttribute("Age"));

        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("FirstName", FirstName);
            writer.WriteAttributeString("LastName", LastName);
            writer.WriteAttributeString("Age", Age.ToString());
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { FirstName = "Franek", LastName = "Kowalski", Age = 21 };
            XmlSerializer serializer = new XmlSerializer(typeof(Person));

            using (FileStream s = File.Create("osoba.xml"))
            {
                serializer.Serialize(s, person);

            }

            using (FileStream s = File.OpenRead("osoba.xml"))
            {
                Person p2 = (Person)serializer.Deserialize(s);
                s.Close();
                Console.WriteLine("Imię:  {0}, nazwisko: {1}, wiek: {2}",p2.FirstName, p2.LastName, p2.Age);
            }

        }
    }
}