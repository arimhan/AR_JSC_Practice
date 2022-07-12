using System;



namespace MyApp // Note: actual namespace depends on the project name.
{
    public enum ErroCode : int
    {
        None,
        ParseNumError,
        ParseOperError,
        CalcDivideZero,
    }

    public class Calculator
    {
        string calcnum = null;
        float ret = 0;
        ErroCode errorcode = ErroCode.None;

        public ErroCode Parse(string inputStr)
        {
            errorcode = ErroCode.None;

            //todo

            return errorcode;
        }


        public float Add(float num1, float num2)
        {
            return num1 + num2;
        }
        public float Sub(float num1, float num2)
        {
            return num1 - num2;
        }
        public float Mul(float num1, float num2)
        {
            return num1 * num2;
        }
        public float Div(float num1, float num2)
        {
            return num1 / num2;
        }

        public ErroCode Operation( float num1,  string numoperator,  float num2, out float ret)
        {
            ret = 0;

            if (numoperator == "+")
            {
                ret = Add(num1, num2);
            }
            else if (numoperator == "-")
            {
                ret = Sub(num1, num2);
            }
            else if (numoperator == "*")
            {
                ret = Mul(num1, num2);
            }
            else if (numoperator == "/")
            {
                if (num2 == 0)
                {
                    return ErroCode.CalcDivideZero;
                    //Console.Write("Error)0으로 나눌 수 없습니다!");
                }
                else
                {
                    ret = Div(num1, num2);
                }
            }

            return ErroCode.None;
            //Console.WriteLine("\n계산결과: {0} {1} {2} = {3}", num1.ToString(), numoperator.ToString(), num2.ToString(), ret.ToString());
        }


        public bool RunCalc()
        {


            float num1 = 0;
            float num2 = 0;
            string numoperator = null;

            while (true)
            {
                Console.Write("\n   계산기~~(Q:종료)\n\n");
                Console.Write("\n 계산할 식을 입력해주세요.(공백으로 구분) ---> \t");

                NumInput(ref num1, ref numoperator, ref num2);
                if (errorcode != 1)
                {
                    Operation(num1, numoperator, num2);
                }
            }
            return false;
        }

        public bool NumInput(ref float num1, ref string numoperator, ref float num2)
        {
            //사용자로부터 값을 string으로 입력받아 split(' ')단위로 분할하여, 각각 num1, numoperator, num2에 해당 값을 변환하여 넣는다.
            //변수에 값을 넣기 전 에러체크를 한다.
            //여기서 변수 할당 후, Operation메서드에 의해 계산을 실행한다.
            calcnum = Console.ReadLine();
            string[] stringcheck = calcnum.Split(' ');

            int i = 0;
            errorcode = 0;

            //사용자로부터 Q를 입력받았을 경우 false를 전달하여 프로그램을 종료한다.
            //종료 Q 처리
            if (calcnum.Equals("q") == true || calcnum.Equals("Q") == true)
            {
                Console.WriteLine("\n계산기 프로그램을 종료합니다.");
                //break;
                return false;
            }
            else if (calcnum.Equals(" ") == true)
            {
                foreach (char c in calcnum)
                {
                    if (c < '0' || c > '9') //숫자 제외 오류처리
                    {
                        Console.WriteLine("Error)숫자 및 연산자만 입력하세요!!");
                        errorcode = 1;

                        return false;
                    }
                    i++;
                    return true;
                }
            }
            for (; i < stringcheck.Length; i++)
            {
                //위에서 Split(공백)단위로 자른 값들을 해당하는 변수에 넣는다. (입력 순서대로 넣기 위해 강제로 0~2번 배열을 세팅)
                if (i == 0)
                    num1 = float.Parse(stringcheck[0]);

                else if (i == 1)
                    numoperator = stringcheck[1];

                else if (i == 2)
                    num2 = float.Parse(stringcheck[2]);
                else
                    Console.Write("Error)");
            }
            return true;
        }
    }

    public class ErrorCheck

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            calc.RunCalc();
        }
    }

}