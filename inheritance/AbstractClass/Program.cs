using System;

namespace AbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {  //abstractinda interface inde objesi olusturulumaz.
            DataBase sql = new SqlServer();
            sql.add();
            sql.Delete();

        }

        abstract class DataBase // abstract class interface ve virtual in karisimi
        {                       //icinde bos metodda olabilir doluda
            public void add()
            {
                Console.WriteLine("added by default");
            }
            public abstract void Delete();
        }
        class SqlServer : DataBase
        {
            public override void Delete()
            {
                Console.WriteLine("deleted by sql");
            }
        }
    }
}

