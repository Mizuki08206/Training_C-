using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1006Console
{
    internal class Person
    {
        private string name;
        private int age;

        public Person(string name,int age)
        {
            this.name = name;
            this.age = age;
        }
        public string GetName()
        {
            return this.name;
        }
        public int GetAge()
        {
            return this.age;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAge(int age)
        {
            this.age = age;
        }

    }
}
