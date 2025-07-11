using System;
using System.Diagnostics;
using System.Security;
using System.Text;

namespace ValueRef
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Thread t = new Thread(threadFunc); // Thread 클래스 t 생성
            t.IsBackground = true;
            t.Start(); // 스레드를 시작
            
            while (true)
            {
                // 가비지컬렉터의 각 세대에서 가비지 수집이 몇 번 일어났는지 모두 체크한다
                int n = GC.CollectionCount(0) + GC.CollectionCount(1) + GC.CollectionCount(2);
                Console.WriteLine(n);
            }

            int count = 5;
            while (count>0)
            {
                // 가비지컬렉터의 각 세대에서 가비지 수집이 몇 번 일어났는지 모두 체크한다
                int n = GC.CollectionCount(0) + GC.CollectionCount(1) + GC.CollectionCount(2);
                Console.WriteLine(n);
                Thread.Sleep(1000);
                count--;
            }
            t.IsBackground = false;
            */
            /*
            MyClass mc1 = new MyClass(5);
            MyClass mc2 = mc1;
            mc1.A = 10;
            Console.WriteLine($"mc1 : {mc1.A}");
            Console.WriteLine($"mc2 : {mc2.A}");
            Console.WriteLine("=======================");
            
            MyStruct ms1 = new MyStruct(2);
            MyStruct ms2 = ms1;
            ms1.A = 5;
            Console.WriteLine($"ms1 : {ms1.A}");
            Console.WriteLine($"ms2 : {ms2.A}");
            */

            // 구조체
            /*
            int a = 1;
            int b = 5;
            Console.WriteLine($"in main : {a}, {b}");
            Console.WriteLine("=======================");
            Swap(a, b);
            Console.WriteLine($"in main : {a}, {b}");
            Console.WriteLine("=======================");
            Swap(ref a, ref b);
            Console.WriteLine($"in main : {a}, {b}");
            Console.WriteLine("=======================");
            */

            // 클래스
            /*
            MyClass mc1 = new MyClass(1, 5);
            Console.WriteLine($"in main : {mc1.A}, {mc1.B}");
            Console.WriteLine("=======================");
            Swap(mc1.A, mc1.B);
            */

            //배열
            /*
            int[] arr = new int[3];
            arr[0] = 1;
            arr[1] = 2;
            arr[2] = 3;
            Swap(arr[0],arr[1]);
            */

            // 클래스 안에 배열
            /*
            MyArrClass mac1 = new MyArrClass(1, 2, 3);
            Console.WriteLine($"in main : {mac1.ints[0]}, {mac1.ints[1]}");
            Console.WriteLine("=======================");
            Swap(mac1.ints[0], mac1.ints[1]);
            Console.WriteLine($"in main : {mac1.ints[0]}, {mac1.ints[1]}");
            Console.WriteLine("=======================");
            Swap(ref mac1.ints[0], ref mac1.ints[1]);
            Console.WriteLine($"in main : {mac1.ints[0]}, {mac1.ints[1]}");
            Console.WriteLine("=======================");
            */

            // 클래스 배열
            /*
            MyClass[] arr = new MyClass[2];
            /// 클래스 배열의 잘못된 사용 예
            /// MyClass a = new MyClass(1, 2); // 힙에 a
            /// MyClass b = new MyClass(3, 4); // 힙에 b
            /// // 힙에 저장된 a와 b를 arr 배열에 깊은 복사로 저장
            /// arr[0] = a;
            /// arr[1] = b;
            
            /// 힙에 할당된 배열에 원본을 바로 저장
            arr[0] = new MyClass(1, 2);
            arr[1] = new MyClass(3, 4);
            Console.WriteLine($"in main : {arr[0].A} / {arr[0].B}, {arr[1].A} / {arr[1].B}");
            /// Console.WriteLine($"in main : {a.A} / {a.B}, {b.A} / {b.B}");
            Console.WriteLine("=======================");
            Swap(arr[0], arr[1]);
            Console.WriteLine($"in main : {arr[0].A} / {arr[0].B}, {arr[1].A} / {arr[1].B}");
            /// Console.WriteLine($"in main : {a.A} / {a.B}, {b.A} / {b.B}");
            Console.WriteLine("=======================");
            Swap(ref arr[0], ref arr[1]);
            Console.WriteLine($"in main : {arr[0].A} / {arr[0].B}, {arr[1].A} / {arr[1].B}");
            Console.WriteLine("=======================");
            */

            // 구조체 배열
            MyStruct[] arr = new MyStruct[3];
            arr[0] = new MyStruct(1);
            arr[1] = new MyStruct(2);
            arr[2] = new MyStruct(3);

        }

        static void Swap(MyStruct a, MyStruct b)
        {
            MyStruct temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"in Swap : {a}/ {b}");
            Console.WriteLine("=======================");
        }

        static void Swap(MyClass a, MyClass b)
        {
            MyClass temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"in Swap : {a.A} / {a.B}, {b.A} / {b.B}");
            Console.WriteLine("=======================");
        }

        static void Swap(ref MyClass a, ref MyClass b)
        {
            MyClass temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"in Swap : {a.A} / {a.B}, {b.A} / {b.B}");
            Console.WriteLine("=======================");
        }

        static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"in Swap : {a}, {b}");
            Console.WriteLine("=======================");
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"in Swap ref : {a}, {b}");
            Console.WriteLine("=======================");
        }
        /*
        // 스레드의 작동으로
        private static void threadFunc()
        { 
            
            /// while(true)
            /// {
            ///     MyClass mc1 = new MyClass(2); // 클래스를 지속적으로 할당
            /// }
            /// class는 참조타입으로 생성 시 메모리의 힙에 할당
            /// while문으로 지속적으로 새로운 메모리가 할당되고, 해지되지 않음(C#)
            /// => 가비지컬렉터의 지속적인 발생을 확인 가능
            
            while(true)
            {
                MyStruct ms1 = new MyStruct(2); // 구조체를 지속적으로 할당
            }
            /// struct는 참조타입으로 생성 시 메모리의 스택에 할당
            /// while문으로 지속적으로 새로운 메모리가 할당 가비지 컬렉터 작동 대상이 아님
            /// 스레드 함수 종료 시 할당 해제
        }
    */

    }

    public class MyArrClass
    {
        public int[] ints = new int[3];
        public MyArrClass(int a, int b, int c)
        {
            ints[0] = a;
            ints[1] = b;
            ints[2] = c;
        }
    }

    public class MyClass
    {
        public int A;
        public int B;
        public MyClass(int a, int b)
        {
            A = a;
            B = b;
        }
    }
    public struct MyStruct
    {
        public int A;
        public MyStruct(int a)
        {
            A = a;
        }
    }
}