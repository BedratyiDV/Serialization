using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SerializationExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating an instance of Person object
            Person personDorian = new Person("Dorian","Grey", 43, 80);

            //SerializationMethod defining
            void SerializationMethod(Person person) 
            
            {
                //Serialization into JSON
                var serialized = JsonConvert.SerializeObject(person);
                Console.WriteLine(serialized);

                //Serialization into binary format
                IFormatter formatter = new BinaryFormatter();
                byte[] serializedData;
                using (MemoryStream stream = new MemoryStream()) 
                
                { 
                    formatter.Serialize(stream, serialized);
                    serializedData = stream.ToArray();
                    Console.WriteLine("Serialized Data:");
                    Console.WriteLine(BitConverter.ToString(serializedData).Replace("-", " "));
                    
                }
                //Deserialization from binary to JSON
                using (MemoryStream stream = new MemoryStream(serializedData))
                {
                    string jsonString = formatter.Deserialize(stream).ToString();
                    Console.WriteLine();
                    Console.WriteLine(jsonString);

                    //Deserialization from JSON into Person object
                    Person deserializedPerson = JsonConvert.DeserializeObject<Person>(jsonString);
                    
                    Console.WriteLine("Deserialized Person First name:");
                    Console.WriteLine(deserializedPerson.FirstName);
                    Console.WriteLine("Deserialized Person Last name:");
                    Console.WriteLine(deserializedPerson.LastName);
                    Console.WriteLine("Deserialized Person Age:");
                    Console.WriteLine(deserializedPerson.Age);
                    Console.WriteLine("Deserialized Person Weight:");
                    Console.WriteLine(deserializedPerson.Weight);

                }
            }
            //Call of SerializationMethod 
            SerializationMethod(personDorian);
        }
    }
}