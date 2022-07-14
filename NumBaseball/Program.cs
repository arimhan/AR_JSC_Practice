using System;
using System.Linq;
namespace NumBaseballGame
{
    public enum NumCheck
    {
        E_NONE = 0,
        E_CLEAR = 100,
    }
    //struct Result 결과값 구조체 or 클래스화 시키기
    //{
    //    public int retStrike;
    //    public int retOut;
    //    public int retBall;
    //}
    public class BaseballGame
    {
        public int[] BaseNum = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int[] SelectNum = new int[3];
        public int retStrike = 0;
        public int retOut = 0;      //스트라이크나 볼이 없으면 아웃이니까 그렇게 처리하기
        public NumCheck nc;
        Random RBaseNum = new Random();
        int RBValue;

        //public void Run()
        //{
        //    Init();
        //    bool bRun = true;
        //    while (bRun)
        //    {
        //        PlayerInput input = new PlayerInput();
        //        input.InputNum(SelectNum, ref retStrike, ref retOut);
        //        GameOutput display = new GameOutput();
        //        display.ResultDisplay(retStrike, retOut, nc);           //메서드 안에서 수정할 게 없으면 ref(참조) 필요없음!
        //        if (nc == (NumCheck.E_CLEAR))
        //        {
        //            bRun = false;
        //        }
        //    }
        //}
        public void Init()
        {

            for (int i = 0; i < SelectNum.Length; i++)
            {
                RBValue = RBaseNum.Next(0, 10); //1~9 사이의 랜덤 값을 생성합니다
                int index = Array.IndexOf(SelectNum, RBValue);
                if (index > -1) //중복 값 있을 경우 다시 랜덤 숫자 생성
                {
                    i--;
                    continue;
                }
                else
                {
                    //수정 : 나중에 랜덤 숫자 출력 안되도록 수정할 것. (디버깅용)
                    SelectNum[i] = RBValue;
                    Console.Write($"\t랜덤 숫자{i + 1} : {RBValue}\t\t");
                }
            }
        }
    }
    public class PlayerInput
    {
        public NumCheck nc = NumCheck.E_NONE;
        public void InputNum(int[] SelectNum, ref int retStrike, ref int retOut) //ref int retball, ref int retout
        {
            Console.Write("\n\t3개의 숫자를 입력하세요(1~9사이, 중복불가, 띄어쓰기):  ");
            int[] InputNum = Console.ReadLine().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            bool isEqual = true;
            retStrike = 0;
            retOut = 0;
            for (int i = 0; i < InputNum.Length; i++)
            {
                //check메서드를 만들어서 분리하는걸 추천 or InputNum 메서드 명을 변경하거나..
                if (InputNum[i] != SelectNum[i])   //숫자,위치 -> 1쌍씩 체크
                {
                    //수정 : 나중에 내 숫자만 출력되도록 처리할것. (디버깅용)
                    Console.WriteLine($"\n\n\t숫자:{SelectNum[i]} , \t\t내 숫자: {InputNum[i]}");
                    if ((isEqual = SelectNum.SequenceEqual(InputNum)) != true)
                    {
                        retOut++;
                    }
                    else //ball 처리예정
                    {
                        //retball++;
                    }
                }
                else
                {
                    Console.Write($"\n\n\t숫자:{SelectNum[i]} ,\t\t내 숫자: {InputNum[i]}");
                    retStrike++;
                }
            }
        }
    }
    public class GameOutput
    {
        public void ResultDisplay(int retStrike, int retOut, NumCheck nc)
        {
            if (retStrike == 3)
            {
                Console.Write($"\n\n\t\t{retStrike} Strike 입니다. \n\t\t게임 클리어!");
                nc = NumCheck.E_CLEAR;
            }
            else if (retOut == 3)
            {
                Console.Write($"\n\n\t\t{retStrike} Out 입니다. \n\t\t게임 실패!");
            }
            else
            {
                Console.Write($"\n\n\t\t{retStrike} Strike,  {retOut} Out   입니다.\n");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseballGame bg = new BaseballGame();
            //bg.Run();
            bg.Init();
            bool bRun = true;
            while (bRun)
            {
                PlayerInput input = new PlayerInput();
                input.InputNum(bg.SelectNum, ref bg.retStrike, ref bg.retOut);
                GameOutput display = new GameOutput();
                display.ResultDisplay(bg.retStrike, bg.retOut, bg.nc);           //메서드 안에서 수정할 게 없으면 ref(참조) 필요없음!
                if (bg.nc == NumCheck.E_CLEAR)
                {
                    bRun = false;
                }
            }
        }
    }
}
