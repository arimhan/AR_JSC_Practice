using System;


namespace MyApp // Note: actual namespace depends on the project name.
{
  
    public class calc
    {

        public static float add(float num1, float num2)
        {
            return num1 + num2;
        }
        public static float sub(float num1, float num2)
        {
            return num1 - num2;
        }
        public static float mul(float num1, float num2)
        {
            return num1 * num2;
        }
        public static float div(float num1, float num2)
        {
            //float ret = 0.0f;
            //ret = num1 / num2;

            return num1 / num2;
        }
        public static void quit()
        {

        }
        public static void operation(float num1, float num2, string numoperator)
        {
            float ret = 0;

            if (numoperator == "+")
            {
                ret = calc.add(num1, num2);
            }
            else if (numoperator == "-")
            {
                ret = calc.sub(num1, num2);
            }
            else if (numoperator == "*")
            {
                ret = calc.mul(num1, num2);
            }
            else if (numoperator == "/")
            {
                if (num2 == 0)
                {
                    Console.Write("0으로 나눌 수 없습니다!");
                }
                else
                {
                    ret = calc.div(num1, num2);
                }
            }
            //Console.WriteLine("계산결과: {0} {1} {2} = {3}", num1, numoperator, num2, ret);
            Console.WriteLine("계산결과: {0} {1} {2} = {3}", num1.ToString(), numoperator.ToString(), num2.ToString(), ret.ToString());
        }

        public static void calcOperator()
        {
            while (true)
            {

                float num1 = 0;
                float num2 = 0;
                string calcnum =  null;
                char getkey = '0';

                //float ret = 0;

                string numoperator = null;
                Console.Write("\n   계산기~~(Q:종료)\n\n");
                Console.Write("\n 계산할 식을 입력해주세요.(공백으로 구분)\n");

                ////char.Parse(Console.ReadLine());
                ////if (getkey == 'Q'|| getkey =='q')
                ////{
                ////    Console.Write("프로그램 종료");
                ////    break;
                ////}
                //else
      
                
                    calcnum = Console.ReadLine();
                    string[] stringcheck = calcnum.Split(' ');

                    for (int i = 0; i < stringcheck.Length; i++)
                    {
                        // Console.WriteLine(stringcheck);

                        if (i == 0)
                            num1 = float.Parse(stringcheck[0]);

                        else if (i == 1)
                            numoperator = stringcheck[1];

                        else if (i == 2)
                            num2 = float.Parse(stringcheck[2]);

                    }

                    //num1 = float.Parse(Console.ReadLine());
                    //Console.Write("두 번째 숫자: ");
                    //num2 = float.Parse(Console.ReadLine());
                    //Console.Write("연산자 : ");
                    //numoperator = Console.ReadLine();
                    operation(num1, num2, numoperator);

            }

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            calc.calcOperator();

        }
    }
}