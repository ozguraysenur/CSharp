using System;
using System.Collections.Generic;
using System.Linq;
namespace lecture8
{
    class Program
    {

        public static List<Emp> GetEmps()
        {
            var list = new List<Emp>();
            list.Add(new Emp { Empno = 1, Ename = "JAKE", comm = 10, Deptno = 10, hiredate = DateTime.Now, salary = 2000 });
            list.Add(new Emp { Empno = 2, Ename = "MIKE", comm = null, Deptno = 20, hiredate = DateTime.Now, salary = 5000 });
            list.Add(new Emp { Empno = 3, Ename = "SMITH", comm = 10, Deptno = 10, hiredate = DateTime.Now, salary = 2000 });
            //...

            return list;
        }

        public static List<Dept> GetDepts()
        {
            var list = new List<Dept>();
            list.Add(new Dept { Deptno = 10, Dname = "RESEARCH" });
            list.Add(new Dept { Deptno = 20, Dname = "SALES" });
            list.Add(new Dept { Deptno = 30, Dname = "WAREHOUSE" });

            return list;
        }

        static void Main(string[] args)
        {
            //1-Extension method
            string index = "s1234";
            if (index.isCorrectIndex(4))
            {
                Console.WriteLine("hello");
            }


            //2-Anonymous types
            var anon = new //look it doesnt have any class 
            {
                name = "Aysenur",
                lastname = "Ozgur"
            };
            //ve bu degerlere baska bisey assign edemeyiz cunku sadece readonly 
            //anon.lastname = "sss";

            Console.WriteLine(anon.lastname);

            //3-anonymous methods (lambdas)
            //map,reduce,filter-> select,aggregate,where
            var nums = new List<int>()
            {
                1,2,3,4,5,6,7,8
            };
            //var odds = Filter(nums, (n)=>n%2==1);
            var odds = nums.Filter((n) => n % 2 == 1).Filter(n => n > 10);

            //LINQ
            //1-Query syntax
            //2-Extension Methods and Lambdas

            var emps = GetEmps();
            //all the emps with salary >1000;

            //1.query syntax
            var r1 = from e in emps // emps should be an enumerable type 
                     where e.salary > 1000
                     select e;

            //2.Extension Methods
            var r1_e = emps.Where((e) => e.salary > 1000);

            var r2 = from e in emps
                     where e.salary > 1000
                     select e.Ename;


            var r2_e = emps.Where((e) => e.salary > 1000).Select((e) => e.Ename);

            //SELECT * FROM Emps WHERE Deptno==10 AND Ename LIKE 'S%' ORDER BY Ename;
            var r3 = from e in emps
                     where e.Deptno==10 && e.Ename.StartsWith("S")
                     orderby e.Ename
                     select e;

           // r3.add();

            var r3_e = emps.Where((e) => e.Deptno == 10 && e.Ename.StartsWith("S")).OrderBy(e => e.Ename);

            var r4 =( from e in emps
                     where e.Deptno == 10 && e.Ename.StartsWith("S")
                     orderby e.Ename descending
                     select e).ToList(); //buda list oldu??

           // r4.Add(new Emp());

            var r4_e = emps.Where((e) => e.Deptno == 10 && e.Ename.StartsWith("S")).OrderByDescending(e => e.Ename);


            int g = 10;
            var r5 = from e in emps
                     join dept in GetDepts() on e.Deptno equals dept.Deptno
                     where e.Deptno == 10 && e.Ename.StartsWith("S")
                     orderby e.Ename descending
                     select new
                     {
                         e.Ename,  // her iki clastanda field dondurmek istiyosan anonymous type kullanmak faydali
                         dept.Dname,   //yoksa ayri bir class olusturup  istediklerini dondurmek vs cok is
                          smt = g
                     };

            var r5_e = emps.Where((e, i) => e.Deptno == 10 && e.Ename.StartsWith("S"))
                          .HiredateDuringBirthday() //extension
                          .Join(GetDepts(), e => e.Deptno, q => q.Deptno, (r, w) => new { r, w })
                          .OrderByDescending(w => w.r.Ename)
                          .Select(w => new
                          {
                              w.r.Ename,
                              w.w.Dname
                          });





            //bu listler hep  enum list olarak olusuyor bisey eklemek istedigimiz de ekleyemicez 
            // bunu extension methodla degistirebilriz


            //extension method

            var count = emps.Count(e => e.comm != null);
            var max = emps.Max(e => e.salary);
            var min = emps.Min(e => e.salary);
            var average = emps.Average(e => e.salary);


            //map=select, filter=where, reduce=aggregate
            var htmlList = emps.Select(s => "<li>" + s.Ename + "</li>").ToList();//map
            htmlList[0] = "smt";
            //tolist yaparak enumerable dan listeye cevirdik
            var boss = emps.Aggregate((e1, e2) => new Emp { Ename = "BOSS", salary = e1.salary + e2.salary });//reduce

            var sth = emps.Select(e => new
            {
                e.Ename,
                NumberOfDepts = GetDepts().Distinct().Count() // we can use nested 
            });



            var areMore1000 = emps.All(s => s.salary > 1000);
            var are = emps.Any(s => s.salary > 1000);

            emps.Skip(10).Take(10);  // skip 10 elements and take next 10 element

            emps.First(); // it will take first element of the list but if there is no data then it will return exception
            emps.FirstOrDefault(); //it will return null if  there is no element.
            emps.Sort();
            emps.Reverse();
           // emps.AsParallel().Select..; //paralelization of the query

        }

        //linq language working on objects within ram memory so it doesnt have anything to do communicating with databse

        //linq + linq to xml(library) allow us to use linq lan to query the xml document 

        //dynamic linq
        //plinq paralel linq  threadpool


        /* public static bool shhshs(int a)
         {
             return a % 2 == 1;
         }
         */
    }
}

