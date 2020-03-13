using System;

namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[3]
            {
                new Customer{name ="ayse"},
                new student{name="Bilal"},
                new Person{name="reyhan"}
            };
            foreach (var person in people)
            {
                Console.WriteLine(person.talk());
                Console.WriteLine(person.name);
            }


        }
    }
    class Person
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public virtual string talk() { return "Helloo"; }  //virtual method metodu kendine gore degisterebilirsin
    }
    class student : Person //iki tane class i inherit edemiyorsun (ilk once inheritance sonra interfaceler )
    {                      //ama interface te olur 
        public string city { get; set; }

    }
    class Customer : Person
    {
        public int department { get; set; }
        public override string talk()  //overriding
        {
            // return base.talk();
            return "hiii";
        }
    }
}
