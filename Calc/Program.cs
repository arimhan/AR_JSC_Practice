using System;



namespace MyApp // Note: actual namespace depends on the project name.
{
    public enum ErrorCode : int
    {
        None,
        ParseNumError,
        ParseOperError,
        CalcDivideZero,
        Quit,
        Result,
    }

    public class Calculator
    {

        public float ret = 0;
        public bool run = true;

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

        public ErrorCode Operation( float num1,  string numoperator,  float num2, out float ret)
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
                    ErrorCheck er = new ErrorCheck();
                    er.errorcode = ErrorCode.CalcDivideZero;
                    er.ErrorDisplay(er.errorcode);

                    return ErrorCode.CalcDivideZero;
                }
                else
                {
                    ret = Div(num1, num2);
                }
            }
            return ErrorCode.None;

        }

        public bool RunCalc()
        {
            //bool run = true;
            while (run == true)
            {
                
                Calculator calc = new Calculator();
                Input input = new Input(); 
                Output output = new Output();
                ErrorCheck er = new ErrorCheck();

                Console.Write("\n   계산기~~(Q:종료)\n\n");
                Console.Write("\n 계산할 식을 입력해주세요.(공백으로 구분) ---> \t");

                input.InputDisplay(out float num1, out string numoperator, out float num2, out string calcnum, out ErrorCode _errorcode);

                er.errorcode = _errorcode;
                if(er.errorcode == ErrorCode.Quit)
                {
                    run = false;
                    return false;
                }

                if(er.errorcode == ErrorCode.None)
                {
                    calc.Operation(num1, numoperator, num2, out ret);
                    output.OutputDisplay(num1, numoperator, num2, ret);

                    //return true;
                }
                //return true;
            }
            return true;
        }
    }



    public class ErrorCheck
    {
        public ErrorCode errorcode = ErrorCode.None;

        public bool InputErrorCheck(string clacnum, string[] stringcheck, float num1, string numoperator, float num2, out ErrorCode errorcode)
        {
            errorcode = ErrorCode.None;
            if ((clacnum.Equals("q") == true))
            {
                errorcode = ErrorCode.Quit;
                ErrorDisplay(errorcode);
                return false;
            }
            return true;
        }

        public bool ErrorDisplay(ErrorCode errorcode)
        {

            if (errorcode == ErrorCode.CalcDivideZero)
            {
                Console.Write("Error)0으로 나눌 수 없습니다!");

                return true;
                //return false;
            }
            else if (errorcode == ErrorCode.Quit)
            {

                Console.Write("\n계산기 프로그램을 종료합니다");
                return false;
            }
            else if (errorcode == ErrorCode.CalcDivideZero)
            {
                Console.Write("");
            }
            return true;
        }
    }
    public class Input
    {
        //public ErrorCode Parse(string inputStr)
        //{
        //    if (inputStr.Equals("ParseNumError") == true)
        //    {
        //        Console.Write("ParseNumError");
        //        return ErrorCode.ParseNumError;
        //    }
        //    else if (inputStr.Equals("Quit") == true)
        //    {
        //        Console.Write("Quit");
        //        return ErrorCode.Quit;
        //    }
        //    //errorcode = ErrorCode.None;
        //    //todo
        //    return ErrorCode.None;
        //}

        public string calcnum = null;

        public bool InputDisplay(out float num1, out string numoperator, out float num2, out string calcnum, out ErrorCode errorcode)
        {
            Calculator calc = new Calculator();

            ErrorCheck er = new ErrorCheck();
            calcnum = Console.ReadLine();

            num1 = 0;
            num2 = 0;
            numoperator = null;
            string[] stringcheck = calcnum.Split(' ');

            er.InputErrorCheck(calcnum, stringcheck, num1, numoperator, num2, out ErrorCode _errorCode);

            errorcode = _errorCode;

            if (errorcode == ErrorCode.None)
            {

                int i = 0;

                for (; i < stringcheck.Length; i++)
                {
                    if (i == 0)
                        num1 = float.Parse(stringcheck[0]);

                    else if (i == 1)
                        numoperator = stringcheck[1];

                    else if (i == 2)
                        num2 = float.Parse(stringcheck[2]);
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
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
            Calculator calc = new Calculator();
            calc.RunCalc();
        }
    }
}