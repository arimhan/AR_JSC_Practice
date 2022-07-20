using System;
using System.Reflection;
using System.Reflection.Emit;
using static System.Console;
namespace _16._03.EmitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AssemblyBuilder newAssembly =
                AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("(CalculatorAssembly"), AssemblyBuilderAccess.Run);
            ModuleBuilder newModule = newAssembly.DefineDynamicModule("Calculator");
            TypeBuilder newType = newModule.DefineType("Sum 1 To 100");
            MethodBuilder newMethod = newType.DefineMethod("Calculator", MethodAttributes.Public, 
                           typeof(int),    //반환 형식
                           new Type[0]);   // 매개변수
            ILGenerator generator = newMethod.GetILGenerator();

            //1부터 100까지 합 => 가우스 공식
            generator.Emit(OpCodes.Ldc_I4, 1);  //32비트 정수(1)을 계산 스택에 넣는다

            for (int i = 2; i <= 100; i++)            //1을 넣었으니 2부터 시작한다. 1+2+3...
            {
                generator.Emit(OpCodes.Ldc_I4, i);  //32비트 정수(i)를 계산 스택에 넣고
                generator.Emit(OpCodes.Add);        //계산 후 계산 스택에 있는 두 개의 값을 꺼내 더한 후, 다시 계산 스택에 넣는다.
                                                    //그럼 1+2 =3 -> 3+4 =7 -> 7+5 = 13+6...
            }
            generator.Emit(OpCodes.Ret);

            newType.CreateType();
            object sum1To100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1To100.GetType().GetMethod("Calculator");
            //MethodBase.Invoke(Object, Object[]) 지정된 매개변수를 사용하여 현재 인스턴스로 나타낸 메서드 또는 생성자 호출
            WriteLine(Calculate.Invoke(sum1To100, null));   
        }
    }
}
