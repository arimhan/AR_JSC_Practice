using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;
//객체 직렬화 : 객체의 상태(여기서는 객체의 필드에 저장된 값)를 메모리나 영구 저장 장치에 저장이 가능한 0과 1의 순서로 바꾸는 것.
//[Serializable] 애트리뷰트를 클래스 선언부 앞에 적어주기. -> 이 클래스는 메모리나 영구 저장 장치에 저장할 수 있는 형식이 된다.
//[NonSerialized] 직렬화 하고싶지 않은 필드 앞에 선언
namespace _18._08.Serialization
{
    [Serializable]
    class NameCard
    {
        public string Name;
        public string Phone;
        //[NonSerialized]//이렇게 하면 다음 Age필드는 직렬화가 안됨. (값이 제대로 출력x null, 0...)
        public int Age;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Stream ws = new FileStream("a.dat", FileMode.Create))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                NameCard nc = new NameCard();
                nc.Name = "박상현";
                nc.Phone = "010-123-4567";
                nc.Age = 33;
                serializer.Serialize(ws, nc);
            }
            using Stream rs = new FileStream("a.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            NameCard nc2;
            nc2 = (NameCard)deserializer.Deserialize(rs);

            WriteLine($"Name:   {nc2.Name}");
            WriteLine($"Phone:  {nc2.Phone}");
            WriteLine($"Age:    {nc2.Age}");
        }
    }
}
