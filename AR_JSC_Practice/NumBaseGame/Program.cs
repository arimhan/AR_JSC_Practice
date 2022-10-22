using System;
using System.Linq;
namespace NumBaseballGame
{
    public enum NumCheck
    {
        E_CLEAR = 100,
        E_FAIL,         // 3Out, 9 GameCount 시 게임 종료
    }
    public class GameResultData
    {
        private int retStrike;
        private int retOut;
        private int retBall;
        public int StrikeData
        {
            get { return retStrike; }
            set { retStrike = value; }
        }
        public int OutData
        {
            get { return retOut; }
            set { retOut = value; }
        }
        public int BallData
        {
            get { return retBall; }
            set { retBall = value; }
        }
    }
    public class BaseballGame
    {
        public int[] BaseNum = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int[] SelectNum = new int[3];  //원래 int형태
        public int[] iJugnum = new int[3];
        Random RBaseNum = new Random();
        int RBValue;                             
        public NumCheck Nc;
        public void Init()
        {
            CreateGoalNums();
        }
        public void CreateGoalNums()
        {
            for (int i = 0; i < SelectNum.Length; i++)
            {
                RBValue = RBaseNum.Next(1, 9);     
                int index = Array.IndexOf(SelectNum, RBValue);
                if (index > -1)                     
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
        //판정
        public int[] IsJudgment( ref int[] inputNums, ref GameResultData getdata, ref NumCheck Nc)
        {
            //InputNumCheck 메소드에서 값을 체크, 상태별로 int[]에 해당하는 index의 value를 추가 및 증가시키고 여기서 판정하여 Display에 출력한다.
            int[] result = new int[3];
            result = inputNums;
            if (result[0] == 3)
            {
                getdata.StrikeData = 3;
                Nc = NumCheck.E_CLEAR;
            }
            else if (result[1] == 3)
            {
                getdata.BallData = 3;
            }
            else if (result[2] == 3)
            {
                getdata.OutData = 3;
                Nc = NumCheck.E_FAIL;
            }
            else //클리어, 실패가 아니라면 int배열에 있는 숫자를 넘겨준다.
            {
                int rstrike = result[0];
                getdata.StrikeData = rstrike;
                int rball = result[1];
                getdata.BallData = rball; 
                int rout = result[2];
                getdata.OutData = rout;
             }
            return result;
        }
        //결과
        public bool IsWin(NumCheck Nc)
        {
            if(Nc == NumCheck.E_CLEAR)
            {
                return true;
            }
            return false;
        }
        public bool IsLose(NumCheck Nc)
        {
            if (Nc == NumCheck.E_FAIL)
            {
                return true;
            }
            return false;
        }
    }
    public class PlayerInput
    {
        public void InputNumCheck(int[] SelectNum, ref GameResultData _getdata, ref NumCheck Nc)
        {
            int[] InputNum = Console.ReadLine().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            BaseballGame bg = new BaseballGame();
            for (int i = 0; i < InputNum.Length; i++)
            {
                int InputIndex = Array.IndexOf(InputNum, SelectNum[i], 0);
                int SelectIndex = Array.IndexOf(SelectNum, InputNum[i], 0);
                if (InputNum[i] == SelectNum[i])        
                {
                    Console.Write($"\n\n\t숫자:{SelectNum[i]} ,\t\t내 숫자: {InputNum[i]}");
                    bg.iJugnum[0] += 1;
                }
                else if (SelectIndex > -1)     
                {
                    Console.Write($"\n\n\t숫자:{SelectNum[i]} ,\t\t내 숫자: {InputNum[i]}");
                    bg.iJugnum[1] += 1;
                }
                else                                   
                {
                    Console.Write($"\n\n\t숫자:{SelectNum[i]} ,\t\t내 숫자: {InputNum[i]}");
                    bg.iJugnum[2] += 1;
                }
            }
            bg.IsJudgment(ref bg.iJugnum, ref _getdata, ref bg.Nc); //판정메서드에서 판정 후 getdata와 Nc값을 참조로 넘긴다
            Nc = bg.Nc;     //값을 그대로 전달하기 위해 Nc변수에 넣는다
        }
    }
    public class GameOutput
    {
        public void ResultDisplay(GameResultData getdata) // 결과값만 출력
        {
            if (getdata.StrikeData == 3) //IsJudgment메서드에서 판정한 getdata를 기준으로 msg를 출력한다
            {
                Console.Write($"\n\n\t\t{getdata.StrikeData} Strike 입니다. \n\t\t게임 클리어!");
            }
            else if (getdata.OutData == 3)
            {
                Console.Write($"\n\n\t\t{getdata.OutData} Out 입니다. \n\t\t게임 실패!");
            }
            else
            {
                Console.Write($"\n\n\t\t{getdata.StrikeData} Strike, {getdata.OutData} Out, {getdata.BallData} Ball  입니다.\n");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseballGame bg = new BaseballGame();
            bg.Init();
            bool IsRun = true;
            PlayerInput Input = new PlayerInput();
            GameOutput Display = new GameOutput();
            GameResultData getdata = new GameResultData();
            while (IsRun)
            {
                Console.Write("\n\t3개의 숫자를 입력하세요(1~9사이, 중복불가, 띄어쓰기):  ");
                Input.InputNumCheck(bg.SelectNum, ref getdata, ref bg.Nc);
                Display.ResultDisplay(getdata);
                if (bg.IsWin(bg.Nc) == true || bg.IsLose(bg.Nc) == true)
                {
                    IsRun = false;
                }
            }
        }
    }
}


