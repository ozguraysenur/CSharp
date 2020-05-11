using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lecture8
{
    public static class extensionmethods
    {

        

        public static bool isCorrectIndex(this string str)  //this-> specify which class we are extending
                                                                              //suan string i extend ediyor  
        {
            return str[0] == 's' && str.Length == 5;
        }

        public static bool isCorrectIndex(this string str,int num)                                                            
        {
            return str[0] == 's' && str.Length == 5;
        }
        public static List<int> Filter(this List<int> nums, Func<int, bool> funct) //accepts int returns bool
        {
            List<int> odd = new List<int>();
            foreach (var n in nums)
            {
                if (n % 2 == 1) odd.Add(n);
            }
            return odd;
        }

        public static IEnumerable<Emp> HiredateDuringBirthday(this IEnumerable<Emp> emps)
        {
            return emps.Where(e => e.hiredate == new DateTime(1989, 4, 2));
        }


    }
}
