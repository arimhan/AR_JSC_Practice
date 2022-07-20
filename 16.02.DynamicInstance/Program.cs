using System;
using System.Reflection;
using static System.Console;
namespace _16._02.DynamicInstance
{
    class Profile
    {
        private string name;
        private string phone;
        public Profile()
        { name = ""; phone = ""; }
        public Profile(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
        public void Print()
        {
            WriteLine($"{name}, {phone}");
        }
        public string Name 
        { 
            get { return name; }
            set { name = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Type type = Type.GetType("DynamicInstance.Profile"); 원래 소스코드를 사용할 경우 type은 null을 반환한다...에러발생.
            //1번 방법) 참조할 인스턴스를 생성한 뒤 인스턴스.GetType을 한다.
            Profile tprofile = new Profile();
            Type type = tprofile.GetType();
            //typeof 클래스 자체의 타입을 가져온다
            //Object.GetType() 현재 인스턴스의 Type을 가져온다. 런타임 시 생성되는 인스턴스의 타입.
            //2번 방법) 그냥 typeof(Profile클래스)를 가져온다.
            //Type type = typeof(Profile);
            MethodInfo methodInfo = type.GetMethod("Print");
            PropertyInfo nameProperty = type.GetProperty("Name");
            PropertyInfo phoneProperty = type.GetProperty("Phone");
            object profile = Activator.CreateInstance(type, "박상현", "512-1234");
            methodInfo.Invoke(profile, null);
            profile = Activator.CreateInstance(type);
            nameProperty.SetValue(profile, "박찬호", null);
            phoneProperty.SetValue(profile, "997-5511", null);

            WriteLine($"{nameProperty.GetValue(profile, null)}, {phoneProperty.GetValue(profile, null)}");
        }
    }
}
