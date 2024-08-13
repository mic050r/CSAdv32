﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAdv32
{
    class Wanted<T>  // Generic 
    {
        public T Value;
        public Wanted(T value)
        {
            Value = value;
        }
    }

    class Needed<T, U> // Generic
    {
        public T Value1;
        public U Value2;
        public Needed(T value1, U value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }

    class SpecialNeeded<T, U> // Generic
        where T : IComparable // 인터페이스만 들어가도록 제한
        where U : IComparable, IDisposable // 인터페이스만 들어가도록 제한
    {
        public T Value1;
        public U Value2;
        public SpecialNeeded(T value1, U value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }

    class SquareCalculator
    {
        public int this[int i] // Indexer
        {
            get { return i * i; }
        }
    }

    internal class Program
    {
        static void NextPos(int x, int y, int vx,  int vy, out int rx, out int ry) // 4가지 변수를 가져오고, 2가지 변수를 반환
        {
            rx = x + vx;
            ry = y + vy;
        }


        static void Main(string[] args)
        {
            Wanted<int> wantedInt = new Wanted<int>(65535);
            Wanted<string> wantedString = new Wanted<string>("Hello, World!");
            Wanted<double> wantedDouble = new Wanted<double>(3.14159);

            Console.WriteLine(wantedInt.Value);
            Console.WriteLine(wantedString.Value);
            Console.WriteLine(wantedDouble.Value);

            SquareCalculator s = new SquareCalculator();
            Console.WriteLine(s[255]); // 배열처럼 사용 가능

            Console.Write("숫자 입력 : ");
            int output;
            bool result = int.TryParse(Console.ReadLine(), out output);
            if(result)
            {
                Console.WriteLine("입력한 숫자 : " + output);
            } else
            {
                Console.WriteLine("숫자를 입력해주세요. " + output); // 기본값이 0이 들어감
            }

            int x = 0;
            int y = 0;
            int vx = 1;
            int vy = 1;

            Console.WriteLine("현재 좌표 x: {0}, y: {1}", x, y); // {} -> 위치
            NextPos(x, y, vx, vy, out x, out y);
            Console.WriteLine("다음 좌표 x: {0}, y: {1}", x, y); // out x -> int x로 좌표가 갱신됨
        }
    }
}