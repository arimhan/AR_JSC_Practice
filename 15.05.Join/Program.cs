using System;
using System.Linq;
using static System.Console;
//531p 두 데이터 원본을 연결하는 Join
//각 데이터 원본에서 특정 필드의 값을 비교하여 일치하는 데이터끼리 연결한다. ==연산자가 아닌 Equals연산자를 사용한다.
//내부 조인 : 교집합. 두 데이터 원본 사이에서 일치하는 데이터들만 연결 후 반환한다.
//외부 조인 : 합집합. 외부 조인의 기준이 되는 데이터 원본의 모든 데이터를 조인 결과에 반드시 포함시켜 반환한다.
namespace _15._05.Join
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
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
            Product[] arrProduct =
{      
                new Product(){Title = "비트",       Star = "정우성"},
                new Product(){Title = "CF다수",     Star = "김태희"},
                new Product(){Title = "아이리스",   Star = "김태희"},
                new Product(){Title = "모래시계",   Star = "고현정"},
                new Product(){Title = "Solo예찬",   Star = "이문세"},
            };

            //원래 profile이랑 product 2개로 데이터가 나뉘어져 있는데, 이걸 join을 이용해 listProfile에 값을 저장한다.
            var listProfile =
                from profile in arrProfile
                join product in arrProduct on profile.Name equals product.Star
                select new
                {
                    Name = profile.Name,
                    Work = product.Title,
                    Height = profile.Height
                };  
            WriteLine("--- 내부 조인 결과 ---");
            foreach(var profile in listProfile)
            {
                WriteLine($"이름: {profile.Name}, \t작품 : {profile.Work}, \t키 : {profile.Height}cm"); //그럼 product를 profile.Work로 사용할 수 있다.
            }

            listProfile =
            from profile in arrProfile
            join product in arrProduct on profile.Name equals product.Star into ps
            from product in ps.DefaultIfEmpty(new Product() { Title = "그런 거 없음" })
            select new
            {
                Name = profile.Name,
                Work = product.Title,
                Height = profile.Height
            };
            WriteLine();
            WriteLine("--- 외부 조인 결과 ---");
            foreach (var profile in listProfile)
            {
                WriteLine($"이름: {profile.Name}, \t작품 : {profile.Work}, \t키 : {profile.Height}cm"); //그럼 product를 profile.Work로 사용할 수 있다.
            }
        }
    }
}
