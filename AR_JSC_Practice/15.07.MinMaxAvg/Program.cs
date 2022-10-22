using System;
using System.Linq;
using static System.Console;
// ? :  삼항연산자 (Ternary Operator)
//condition ? consequent : alternative
//(condition : bool type -> true / false -> true이면 return consequent, false이면 return alternative)
namespace _15._07.MinMaxAvg
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile(){Name = "정우성", Height = 186},
                new Profile(){Name = "김태희", Height = 158},
                new Profile(){Name = "고현정", Height = 172},
                new Profile(){Name = "이문세", Height = 178},
                new Profile(){Name = "하하",   Height = 171},
            };

            var heightStat = from profile in arrProfile
                             group profile by profile.Height < 175 into g
                             select new
                             {
                                 Group      = g.Key == true ? "175미만" : "175이상",    //175미만 true, 175이상 false
                                 Count      = g.Count(),
                                 Max        = g.Max     (profile => profile.Height),
                                 Min        = g.Min     (profile => profile.Height),
                                 Average    = g.Average (profile => profile.Height)
                             };
            foreach(var stat in heightStat)
            {
                Write($"{stat.Group} - Count:{stat.Count}, Max:{stat.Max}");
                WriteLine($"Min : {stat.Min}, Average:{stat.Average}");
            }
        }
    }
}
