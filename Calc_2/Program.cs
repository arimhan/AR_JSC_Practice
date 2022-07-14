using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n   계산기~~(Q:종료)\n\n");
            Console.Write("\n 계산할 식을 입력해주세요.(공백으로 구분) ---> \t");

            //input
            string calcnum;
            calcnum = Console.ReadLine();
            float num1 = 0;
            float num2 = 0;
            numoperator = null;
            string[] stringcheck = calcnum.Split(' ');
            outretcode = ResultCode.E_SUCCESS;
            run = true;
            if ((calcnum.Equals("q") == true) || (calcnum.Equals("Q") == true))
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
                        er.retcode = ResultCode.E_FAIL_PARSENUM_ERROR;
                    }
                }
            }
    }
}