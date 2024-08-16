using System;
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
        struct Point
        {
            public int x;
            public int y;
            public string testA;
            public string testB;
            // public string testB = "init"; // 구조체 내 변수는 선언과 동시에 초기화 불가능

            // public Point() {} // 구조체 -> 기본 생성자 정의 불가능
            // 상속x -> 이미 기본 생성자를 만들어 놨다.

            public Point(int x, int y) // 구조체 생성자 -> 모든 변수 초기화 해주어야함.
            {
                this.x = x; 
                this.y = y;
                this.testA = "init";
                this.testB = "init";
            }

            public Point(int x, int y, string t) // 생성자 오버로딩 가능
            {
                this.x = x;
                this.y = y;
                this.testA = "init";
                this.testB = "init";
            }
        }

        class PointClass
        {
            public int x;
            public int y;
            public PointClass(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        struct PointStruct
        {
            public int x;
            public int y;
            public PointStruct(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

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
            NextPos(x, y, vx, vy, out x, out y); // 포인터랑 비슷한 느낌
            Console.WriteLine("다음 좌표 x: {0}, y: {1}", x, y); // out x -> int x로 좌표가 갱신됨

            // Point 구조체 실습
            Point point;   // 구조체 변수 선언. 8바이트 잡힘.
            point.x = 10;  // 구조체 변수는 반드시 초기화 해야함.(컴파일 에러)
            point.y = 10;  // 선언 안해주면 컴파일 조차 안됨.
            Console.WriteLine("point.x: {0}, point.y: {1}", point.x, point.y);

            // 구조체와 클래스 비교 실습(중요 tp)
            PointClass pCA = new PointClass(10, 10); // 클래스 변수 선언. 4바이트 잡힘
            PointClass pCB = pCA; // 클래스 변수 복사. 주소값 복사
            pCB.x = 100;
            pCB.y = 200;
            Console.WriteLine("pCA.x: {0}, pCA.y: {1}", pCA.x, pCA.y); // 둘 다 같은 객체라
            Console.WriteLine("pCB.x: {0}, pCB.y: {1}", pCB.x, pCB.y); // 출력 값이 같다.
            Console.WriteLine();

            PointStruct pSA = new PointStruct(10, 10); // 구조체 변수 선언. 8바이트 잡힘
            PointStruct pSB = pSA; // 구조체변수 복사. 값 복사!!!(주소값 복사X)
            pSB.x = 100;
            pSB.y = 200;
            Console.WriteLine("pSA.x: {0}, pSA.y: {1}", pSA.x, pSA.y); // 둘은 다른 구조체
            Console.WriteLine("pSB.x: {0}, pSB.y: {1}", pSB.x, pSB.y); // 출력 값이 다르다!!
            Console.WriteLine();
        }
    }
}