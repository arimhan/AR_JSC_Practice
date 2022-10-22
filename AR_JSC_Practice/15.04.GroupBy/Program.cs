using System;
using System.Linq;
using static System.Console;
//group by로 데이터 분류하기
//group 객체명 by 분류할 조건 into g -> 조건 true, false값을 g에 저장하여 true그룹과 false그룹으로 나눈다.
namespace _15._04.GroupBy
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
                new Profile(){Name = "하하", Height = 171},
            };

            var listProfile = from profile in arrProfile
                              orderby profile.Height
                              group profile by profile.Height < 175 into g //예를들어 profile.Height < 175 true/false와 해당 이름,키 값을 g에 분류하여 저장한다.
                              select new { GroupKey = g.Key, Profiles = g };
            foreach (var Group in listProfile)
            {
                WriteLine($"-  175cm 미만? : {Group.GroupKey}");
                foreach( var profile in Group.Profiles)
                    WriteLine($">>> {profile.Name}, {profile.Height}");
            }
        }
    }
}
