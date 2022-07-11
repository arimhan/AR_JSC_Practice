using System;
//class화 -> static 사용X 대신 new 동적할당
// calc class에 input값 넣어서 계산처리 -> result를 main으로 보내기



namespace MyApp // Note: actual namespace depends on the project name.
{
  
    public class Calculator
    {
        float result;
        public float add(float num1, float num2)
        {
            return num1 + num2;
        }
        public float sub(float num1, float num2)
        {
            return num1 - num2;
        }
        public float mul(float num1, float num2)
        {
            return num1 * num2;
        }
        public float div(float num1, float num2)
        {
            return num1 / num2;
        }

        public void operation(float num1, float num2, string numoperator)
        {
            float ret = 0;

            if (numoperator == "+")
            {
                ret = new Calculator().add(num1, num2);
                //ret = calc.add
            }
            else if (numoperator == "-")
            {
                ret = new Calculator().sub(num1, num2);
                //ret = calc.sub(num1, num2);
            }
            else if (numoperator == "*")
            {
                ret = new Calculator().mul(num1, num2);
                //ret = calc.mul(num1, num2);
            }
            else if (numoperator == "/")
            {
                if (num2 == 0)
                {
                    Console.Write("0으로 나눌 수 없습니다!");
                }
                else
                {
                    ret = new Calculator().div(num1, num2);
                    //ret = calc.div(num1, num2);
                }
            }
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

                //종료 Q 처리

                calcnum = Console.ReadLine();
                string[] stringcheck = calcnum.Split(' ');

                for (int i = 0; i < stringcheck.Length; i++)
                {
                    Console.WriteLine(stringcheck);

                    //잘못된 값 입력 시 예외처리 (ex 공백만 입력했을때..)

                    if (i == 0)
                        num1 = float.Parse(stringcheck[0]);

                    else if (i == 1)
                        numoperator = stringcheck[1];

                    else if (i == 2)
                        num2 = float.Parse(stringcheck[2]);
                    else
                        Console.Write("잘못된 값을 입력했어요. 숫자(공백)연산자(공백)숫자 순으로 입력하세요!");
                }
                new Calculator().operation(num1, num2, numoperator);
                //Calculator.operation(num1, num2, numoperator);

            }

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator.calcOperator();
        }
    }
}