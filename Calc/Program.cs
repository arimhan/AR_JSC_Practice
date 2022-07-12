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
        public ErrorCode errorcode = ErrorCode.None;

        ErrorCheck errorchk = new ErrorCheck();

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

        public ErrorCode Operation(float num1, string numoperator, float num2, out float ret)
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
                    return ErrorCode.CalcDivideZero;
                    //Console.Write("Error)0으로 나눌 수 없습니다!");
                }
                else
                {
                    ret = Div(num1, num2);
                }
            }
            //Console.WriteLine("\n계산결과: {0} {1} {2} = {3}", num1.ToString(), numoperator.ToString(), num2.ToString(), ret.ToString());
            return ErrorCode.None;

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

                Input input = new Input();
                input.InputDisplay(ref num1, ref numoperator, ref num2);
                Output output = new Output();
                output.OutputDisplay(num1, numoperator, num2, ret);

            }
            return false;
        }


    }

    public class ErrorCheck
    {
        //public ErrorCode CheckOperation(float num1, string numoperator, float num2, out float ret)
        //{
        //    ret = 0;

        //    if (numoperator == "+")
        //    {
        //        ret = Add(num1, num2);
        //    }
        //    else if (numoperator == "-")
        //    {
        //        ret = Sub(num1, num2);
        //    }
        //    else if (numoperator == "*")
        //    {
        //        ret = Mul(num1, num2);
        //    }
        //    else if (numoperator == "/")
        //    {
        //        if (num2 == 0)
        //        {
        //            return ErroCode.CalcDivideZero;
        //            //Console.Write("Error)0으로 나눌 수 없습니다!");
        //        }
        //        else
        //        {
        //            ret = Div(num1, num2);
        //        }
        //    }

        //    return ErroCode.None;
        //    //Console.WriteLine("\n계산결과: {0} {1} {2} = {3}", num1.ToString(), numoperator.ToString(), num2.ToString(), ret.ToString());
        //}

        public void ErrorDisplay()
        {
            Calculator calc = new Calculator();
            if (calc.errorcode == ErrorCode.CalcDivideZero)
            {
                Console.Write("Error)0으로 나눌 수 없습니다!");
            }
            else if (calc.errorcode == ErrorCode.None)
            {
                Console.Write("");
            }
            else if (calc.errorcode == ErrorCode.None)
            {
                Console.Write("");
            }
            else { }

        }
    }
    public class Input
    {
        public ErrorCode Parse(string inputStr)
        {
            if (inputStr.Equals("ParseNumError") == true)
            {
                Console.Write("ParseNumError");
                return ErrorCode.ParseNumError;
            }
            else if (inputStr.Equals("Quit") == true)
            {
                Console.Write("Quit");
                return ErrorCode.Quit;
            }
            //errorcode = ErrorCode.None;
            //todo
            return ErrorCode.None;
        }

        public string calcnum = null;

        public void InputDisplay(ref float num1, ref string numoperator, ref float num2)
        {

            calcnum = Console.ReadLine();
            string[] stringcheck = calcnum.Split(' ');

            int i = 0;

            if (calcnum.Equals("q") == true || calcnum.Equals("Q") == true)
            {
                string errorstring = (ErrorCode.Quit).ToString();
                Parse(errorstring);
                //return ErrorCode.Quit;
                //Console.WriteLine("\n계산기 프로그램을 종료합니다.");

            }
            else if (calcnum.Equals(" ") == true)
            {
                foreach (char c in calcnum)
                {
                    if (c < '0' || c > '9')
                    {
                        //Console.WriteLine("Error)숫자 및 연산자만 입력하세요!!");
                        //return ErrorCode.ParseNumError;
                    }
                    i++;
                    //return ErrorCode.None;
                }
            }
            for (; i < stringcheck.Length; i++)
            {

                if (i == 0)
                    num1 = float.Parse(stringcheck[0]);

                else if (i == 1)
                    numoperator = stringcheck[1];

                else if (i == 2)
                    num2 = float.Parse(stringcheck[2]);
                else
                    Console.Write("Error)");
            }
            //if (errorcode == ErrorCode.None)
            //{
            //    Operation(num1, numoperator, num2, out ret);
            //}
            //Operation(num1, numoperator, num2, out ret);
            //return ErrorCode.None;
        }
    }
    public class Output
    {
        public void OutputDisplay(float num1, string numoperator, float num2, float ret)
        {
            Console.WriteLine("\n계산결과: {0} {1} {2} = {3}", num1.ToString(), numoperator.ToString(), num2.ToString(), ret.ToString());
        }

        //public ErrorCode NumInput(float num1, string numoperator, float num2)
        //{

        //    calcnum = Console.ReadLine();
        //    string[] stringcheck = calcnum.Split(' ');

        //    int i = 0;
        //    errorcode = 0;
        //    string errorstring = (ErrorCode.ParseNumError).ToString();
        //    Parse(errorstring);

        //    if (calcnum.Equals("q") == true || calcnum.Equals("Q") == true)
        //    {
        //        return ErrorCode.Quit;
        //        //Console.WriteLine("\n계산기 프로그램을 종료합니다.");

        //    }
        //    else if (calcnum.Equals(" ") == true)
        //    {
        //        foreach (char c in calcnum)
        //        {
        //            if (c < '0' || c > '9')
        //            {
        //                //Console.WriteLine("Error)숫자 및 연산자만 입력하세요!!");
        //                return ErrorCode.ParseNumError;
        //            }
        //            i++;
        //            return ErrorCode.None;
        //        }
        //    }
        //    for (; i < stringcheck.Length; i++)
        //    {

        //        if (i == 0)
        //            num1 = float.Parse(stringcheck[0]);

        //        else if (i == 1)
        //            numoperator = stringcheck[1];

        //        else if (i == 2)
        //            num2 = float.Parse(stringcheck[2]);
        //        else
        //            Console.Write("Error)");
        //    }
        //    if (errorcode == ErrorCode.None)
        //    {
        //        Operation(num1, numoperator, num2, out ret);
        //    }
        //    //Operation(num1, numoperator, num2, out ret);
        //    return ErrorCode.None;
        //}
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