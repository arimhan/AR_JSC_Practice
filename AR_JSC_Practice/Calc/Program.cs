using System;
namespace MyApp
{
    public enum ResultCode
    {
        E_SUCCESS = 0,
        E_QUIT =1,
        E_FAIL = 100,
        E_FAIL_PARSENUM_ERROR,
        E_FAIL_PARSEOPER_ERROR,
        E_FAIL_CALC_DIVIDEZERO,
    }
    public class Calculator
    {
        //public int ret = 0;
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        public int Sub(int num1, int num2)
        {
            return num1 - num2;
        }
        public int Mul(int num1, int num2)
        {
            return num1 * num2;
        }
        public void Div(int num1, int num2, out int quotient, out float remainder)
        {
            quotient = num1 / num2;
            remainder = num2 % num2;
        }
        public ResultCode Operation(int num1, string numoperator, int num2, out int ret, out ResultCode outretcode)
        {
            ret = 0;
            outretcode = ResultCode.E_SUCCESS;
            ErrorCheck er = new ErrorCheck();
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
                    outretcode = ResultCode.E_FAIL_CALC_DIVIDEZERO;
                    er.ErrorDisplay(outretcode);
                    return outretcode;
                }
                else
                {
                    ret = Div(num1, num2, out int q, out float r);
                }
            }
            return ResultCode.E_SUCCESS;
        }
    }
    public class ErrorCheck
    {
        public ResultCode retcode = ResultCode.E_SUCCESS;
        public void InputQuit()
        {
            retcode = ResultCode.E_QUIT;
        }
        public void ErrorDisplay(ResultCode retcode)
        {
            switch (retcode)
            {
                case ResultCode.E_FAIL_PARSENUM_ERROR:
                    {
                        Console.Write($"\n{retcode}\n");
                        Console.Write("\n숫자를 잘못 입력하셨습니다.\n");
                        break;
                    }
                case ResultCode.E_FAIL_PARSEOPER_ERROR:
                    {
                        Console.Write($"\n{retcode}\n");
                        Console.Write("\n0입력 가능한 연산자는 +, -, *, / 4가지 입니다.\n");
                        break;
                    }
                case ResultCode.E_FAIL_CALC_DIVIDEZERO:
                    {
                        Console.Write($"\n{retcode}\n");
                        Console.Write("\n0으로 나눌 수 없습니다.\n");
                        break;
                    }
                case ResultCode.E_QUIT:
                    {
                        Console.Write($"\n{retcode}\n");
                        Console.Write($"\n계산기 프로그램을 종료합니다\n");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
    public class Input
    {
        ErrorCheck er = new ErrorCheck();
        //Output op = new Output();
        public void InputValue(out int num1, out string numoperator, out int num2, out ResultCode outretcode, out bool run)
        {
            string calcnum;
            calcnum = Console.ReadLine();
            num1 = 0;
            num2 = 0;
            numoperator = null;
            string[] stringcheck = calcnum.Split(' ');


            outretcode = ResultCode.E_SUCCESS;
            run = true;
            if ((calcnum.Equals("q") == true)|| (calcnum.Equals("Q") == true))
            {
                outretcode = ResultCode.E_QUIT;
                run = false;
                er.ErrorDisplay(outretcode);
            }
            else
            {
                for (int i = 0; i < stringcheck.Length; i++)
                {
                    if (i == 0)
                    {
                        num1 = int.Parse(stringcheck[0]);
                    }
                    else if (i == 1)
                    {
                        numoperator = stringcheck[1];
                    }
                    else if (i == 2)
                    {
                        num2 = int.Parse(stringcheck[2]);
                    }
                    else
                    {
                        er.retcode = ResultCode.E_FAIL_PARSENUM_ERROR;
                    }
                }
            }
        }
    }
    public class Output
    {
        public void OutputDisplay(int num1, string numoperator, int num2, int ret)
        {
            Calculator calc = new Calculator();
            Console.WriteLine($"\n계산결과: {num1.ToString()} {numoperator.ToString()} {num2.ToString()} = {ret.ToString()}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.Write("\n   계산기~~(Q:종료)\n\n");
                Console.Write("\n 계산할 식을 입력해주세요.(공백으로 구분) ---> \t");
                Input input = new Input();
                ErrorCheck er = new ErrorCheck();
                input.InputValue(out int num1, out string numoperator, out int num2, out ResultCode outretcode, out run);
                if (outretcode != ResultCode.E_QUIT)
                {
                    Calculator calc = new Calculator();
                    calc.Operation(num1, numoperator, num2, out int ret, out ResultCode outretcode2);
                    if (outretcode2 != ResultCode.E_FAIL_CALC_DIVIDEZERO)
                    {
                        Output output = new Output();
                        output.OutputDisplay(num1, numoperator, num2, ret);
                    }
                }
            }
        }
    }
}
