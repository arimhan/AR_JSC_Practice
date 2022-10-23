using static System.Console;
namespace _03._07.StringNumberConversion
{
    class MainApp
    {
        static void Main(string[] args)
        {
            //Parse() : 데이터 형식.Parse(파라미터) : 해당 데이터 형식이 담긴 파라미터를 숫자로 변환해준다.
            //ToString() : 데이터 형식.ToString() : 해당 데이터 형식을 문자열로 변환해준다.
            //Convert.To데이터형식 : 해당 데이터 형식으로 변환해준다.

            int a = 123;                    //Int32 : 32bit signed integer
            string b = a.ToString();        //String : 유니코드 문자열
            WriteLine("a.{0}: {1}, b.{2} : {3}", a.GetType().FullName, a, b.GetType().FullName, b);

            float c = 3.14f;
            string d = c.ToString();        //Single : 32bit single precision 부동소수점 숫자
            WriteLine("c.{0}: {1}, d.{2} : {3}", c.GetType().FullName, c, d.GetType().FullName, d);


            string e = "12345";
            int f = Convert.ToInt32(e);     
            WriteLine("e.{0}: {1}, f.{2} : {3}", e.GetType().FullName, e, f.GetType().FullName, f);

            string g = "1.2345";
            float h = float.Parse(g);
            WriteLine("g.{0}: {1}, h.{2} : {3}", g.GetType().FullName, g, h.GetType().FullName, h);
        }
    }
}