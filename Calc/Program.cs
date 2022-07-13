using System;
namespace MyApp
{
    public enum ErrorCode : int
    {
        None,
        ParseNumError,
        ParseOperError,
        CalcDivideZero,
        Quit,
    }
    public class Calculator
    {
        //public float ret = 0;
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
        public ErrorCode Operation(float num1, string numoperator, float num2, out float ret, out ErrorCode _errorCode)
        {
            ret = 0;
            _errorCode = ErrorCode.None;
            ErrorCheck er = new ErrorCheck();
            //Output op = new Output();
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
                    _errorCode =  ErrorCode.CalcDivideZero;
                    er.ErrorDisplay(_errorCode);
                    return _errorCode;
                }
                else
                {
                    ret = Div(num1, num2);
                }
            }
            return ErrorCode.None;
        }
    }
    public class ErrorCheck
    {
        public ErrorCode errorCode = ErrorCode.None;
        public void InputQuit()
        {
            errorCode = ErrorCode.Quit;
        }
        public void ErrorDisplay(ErrorCode errorCode)
        {
            switch (errorCode)
            {
                case ErrorCode.ParseNumError:
                    {
                        Console.Write("\n계산기 프로그램을 종료합니다\n");
                        break;
                    }
                case ErrorCode.ParseOperError:
                    {
                        Console.Write("\n0입력 가능한 연산자는 +, -, *, / 4가지 입니다.\n");
                        break;
                    }
                case ErrorCode.CalcDivideZero:
                    {
                        Console.Write("\n0으로 나눌 수 없습니다.\n");
                        break;
                    }
                case ErrorCode.Quit:
                    {
                        Console.Write("\n계산기 프로그램을 종료합니다\n");
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
        public void InputValue(out float num1, out string numoperator, out float num2, out ErrorCode errorCode, out bool run)
        {
            string calcnum;
            calcnum = Console.ReadLine();
            num1 = 0;
            num2 = 0;
            numoperator = null;
            string[] stringcheck = calcnum.Split(' ');
            errorCode = ErrorCode.None;
            run = true;
            if ((calcnum.Equals("q") == true)|| (calcnum.Equals("Q") == true))
            {
                errorCode = ErrorCode.Quit;
                run = false;
                er.ErrorDisplay(errorCode);
            }
            else
            {
                for (int i = 0; i < stringcheck.Length; i++)
                {
                    if (i == 0)
                    {
                        num1 = float.Parse(stringcheck[0]);
                    }
                    else if (i == 1)
                    {
                        numoperator = stringcheck[1];
                    }
                    else if (i == 2)
                    {
                        num2 = float.Parse(stringcheck[2]);
                    }
                    else
                    {
                        er.errorCode = ErrorCode.ParseNumError;
                    }
                }
            }
        }
    }
    public class Output
    {
        public void OutputDisplay(float num1, string numoperator, float num2, float ret)
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
                input.InputValue(out float num1, out string numoperator, out float num2, out ErrorCode errorCode, out run);
                if (!((errorCode == ErrorCode.Quit) == true))
                {
                    Calculator calc = new Calculator();
                    calc.Operation(num1, numoperator, num2, out float ret, out ErrorCode _errorCode);
                    if (!((_errorCode == ErrorCode.CalcDivideZero) == true))
                    {
                        Output output = new Output();
                        output.OutputDisplay(num1, numoperator, num2, ret);
                    }
                }
            }
        }
    }
}
