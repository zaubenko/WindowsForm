using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Person
    {
        string name;
        string surname;
        int age;
        Adress adress;
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public int Age { get { return age; } set { age = value; } }
        public Adress Adress { get { return adress; } set { adress = value; } }
        public Person(string Name, string Surname, int Age, Adress addres)
        {
            name = Name;
            surname = Surname;
            age = Age;
            adress = addres;
        }
    }
}
