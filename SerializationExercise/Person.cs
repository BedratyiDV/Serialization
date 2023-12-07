using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SerializationExercise
{
    [Serializable]
    internal class Person
    {
        [JsonProperty("personFirstName")]
        private string _firstName;

        [JsonProperty("personLastName")]
        private string _lastName;

        [JsonProperty("personAge")]
        private int _age;

        [NonSerialized]
        private int _weight;

        public Person(string firstName, string lastName, int age, int weight)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _weight = weight;
        }
        public string FirstName
        {
            get => _firstName;
        }
        public string LastName
        {
            get => _lastName;
        }
        public int Age
        {
            get => _age;
        }
        public int Weight
        {
            get => _weight;
        }
    }
}
