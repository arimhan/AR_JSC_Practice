using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using static System.Console;
//리플렉션 : 객체의 형식(Type)정보를 들여다 보는 기능. -> 객체의 형식 이름, 프로퍼티 목록, 메소드 목록, 필드, 이벤트 목록 등..
//ex) 형식의 이름 -> 동적으로 인스턴스 생성 가능. 인스턴스의 메소드 호출 가능. 새로운 데이터 형식을 동적으로 만들 수 있음..
//Object.GetType() 메소드와 Type 클래스
//Object : 모든 데이터 형식의 조상 (모든 데이터 형식을 가지고 있다) -> GetType메소드를 활용해 객체의 정보를 볼 수 있는 것.
//Type형식 : .NET에서 사용되는 데이터 형식의 모든 정보 ex) GetInterfaces(), GetMethods()...
//생성자 GetConstructors(), 내부형식GetNestedTypes() ...등 활용 가능.
namespace _16._01.GetType
{
    internal class Program
    {
        static void PrintInterfaces(Type type)
        {
            WriteLine("-------------- Interfaces --------------");
            Type[] interfaces = type.GetInterfaces();       //Type[]형식이므로 ~es로 인터페이스 목록 반환
            foreach(Type i in interfaces)
                WriteLine($"Name : {i.Name} ");
            WriteLine();
        }
        static void PrintFields(Type type)
        {
            WriteLine("-------------- Fields --------------");
            FieldInfo[] fields = type.GetFields(
                BindingFlags.NonPublic  |
                BindingFlags.Public     |
                BindingFlags.Static     |
                BindingFlags.Instance   );
            foreach(FieldInfo field in fields)
            {
                String accessLevel = "protected";
                if (field.IsPublic) accessLevel = "public";
                else if (field.IsPrivate) accessLevel = "private";
                WriteLine($"Access : {accessLevel}, Type : {field.FieldType.Name}, Name : {field.Name} ");
            }
            WriteLine();
        }
        static void PrintMethods(Type type)
        {
            WriteLine("-------------- Methods --------------");
            MethodInfo[] methods = type.GetMethods();
            foreach(MethodInfo method in methods)
            {
                Write($"Type : {method.ReturnType.Name}, Name : {method.Name}, Parameter : ");
                ParameterInfo[] args = method.GetParameters();
                for(int i=0; i<args.Length; i++)
                {
                    Write($"{args[i].ParameterType.Name}");
                    if(i < args.Length - 1)
                        Write($", ");
                }
                WriteLine();
            }
            WriteLine();
        }
        static void PrintProperties(Type type)      //int 형식에는 프로퍼티 X
        {
            WriteLine("-------------- Properties --------------");
            PropertyInfo[] properties = type.GetProperties();
            foreach(PropertyInfo property in properties)
                WriteLine($"Type : {property.PropertyType.Name}, Name : {property.Name}");
            WriteLine();
        }
        static void Main(string[] args)
        {
            int a = 0;
            Type type = a.GetType();

            PrintInterfaces(type);
            PrintFields(type);
            PrintProperties(type); 
            PrintMethods(type);

        }
    }
}
