using System;
using System.Collections.Generic;
using System.Text;

namespace lecture8
{
    public class Emp
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public int salary { get; set; }
        public DateTime hiredate { get; set; }
        public int Deptno { get; set; }
        public int? comm { get; set; }   //? comm  can be nullable

    }

    public class Dept
    {
        public int Deptno { get; internal set; }
        public string Dname { get; set; }
    }

}
