using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
namespace _11._08.EnumerableGeneric
{
    class MyList<T> : IEnumerable<T>, IEnumerator<T>
    //foreach를 사용할 수 있는 클래스 생성 시, IEnumerable인터페이스와 IEnumerator인터페이스를 상속하고
    //이들의 메소드와 프로퍼티를 구현해야 한다.
    //일반화 버전인 IEnumerable<T> 인터페이스 메소드 안에는 IEnumerator<T> GetEnumerato() 가 2가지(기존/일반화) 있으며
    //IEnumerator<T>의 메소드와 프로피티는 MoveNext(), Reset(), Current (기존,일반) 이렇게 4가지가 존재한다.
    {
        private T[] array;
        int position = -1;
        public MyList()
        {
            array = new T[3];
        }
        public T this[int index]
        {
            get { return array[index]; }
            set 
            { 
                if(index >= array.Length)
                {
                    Array.Resize<T>(ref array, index + 1);
                    WriteLine($"Array Resized : {array.Length}");
                }
                array[index] = value; 
            }
        }
        public int Length
        {
            get { return array.Length; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        public T Current
        {
            get { return array[position]; }
        }
        object IEnumerator.Current
        {
            get { return array[position]; }
        }
        public bool MoveNext()
        {
            if(position == array.Length -1 )
            {
                Reset();
                return false;
            }
            position++;
            return (position < array.Length);
        }
        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<string> str_list = new MyList<string>();
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";

            foreach(string str in str_list)
                WriteLine(str);
            WriteLine();

            MyList<int> int_list = new MyList<int>();
            int_list[0] = 0;
            int_list[1] = 1;
            int_list[2] = 2;
            int_list[3] = 3;
            int_list[4] = 4;
            foreach (int no in int_list)
                WriteLine(no);
            WriteLine();
        }
    }
}
