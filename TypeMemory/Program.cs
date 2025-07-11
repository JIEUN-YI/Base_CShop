using System;

namespace CShop_Study
{
    class Program
    {
        /*
        static void Main(string[] args)
        {

            MyStruct[] arr = new MyStruct[3];
            /// arr[0] = new MyStruct(1, 2);
            /// arr[1] = new MyStruct(3, 4);
            /// arr[2] = new MyStruct(5, 6);
            /// 
            /// Console.WriteLine($"in Main - arr[0] : {arr[0].a}, {arr[0].b}");
            /// Console.WriteLine($"in Main - arr[0] : {arr[1].a}, {arr[1].b}");
            /// Console.WriteLine($"===========================================================");
            /// Swap(ref arr[0], ref arr[1]);
            /// Console.WriteLine($"in Main - ms1 : arr[0] : {arr[0].a}, {arr[0].b}");
            /// Console.WriteLine($"in Main - ms2 : arr[0] : {arr[1].a}, {arr[1].b}");
            /// Console.WriteLine($"===========================================================");

            MyStruct ms1 = new MyStruct(1, 2);
            MyStruct ms2 = new MyStruct(3, 4);
            MyStruct ms3 = new MyStruct(5, 6);
            arr[0] = ms1;
            arr[1] = ms2;
            arr[2] = ms3;
            Console.WriteLine($"in Main - ms1 : {ms1.a}, {ms1.b} / arr[0] : {arr[0].a}, {arr[0].b}");
            Console.WriteLine($"in Main - ms2 : {ms2.a}, {ms2.b} / arr[0] : {arr[1].a}, {arr[1].b}");
            Console.WriteLine($"===========================================================");
            /// Swap(ref ms1, ref ms2);
            /// Console.WriteLine($"in Main - ms1 : {ms1.a}, {ms1.b} / arr[0] : {arr[0].a}, {arr[0].b}");
            /// Console.WriteLine($"in Main - ms2 : {ms2.a}, {ms2.b} / arr[0] : {arr[1].a}, {arr[1].b}");
            /// Console.WriteLine($"===========================================================");

            Swap(ref arr[0], ref arr[1]);
            Console.WriteLine($"in Main - ms1 : {ms1.a}, {ms1.b} / arr[0] : {arr[0].a}, {arr[0].b}");
            Console.WriteLine($"in Main - ms2 : {ms2.a}, {ms2.b} / arr[0] : {arr[1].a}, {arr[1].b}");
            Console.WriteLine($"===========================================================");
        }
        public static void Swap(MyStruct a, MyStruct b)
        {
            MyStruct temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"in Swap - ms1 : {a.a}, {a.b}");
            Console.WriteLine($"in Swap - ms2 : {b.a}, {b.b}");
            Console.WriteLine($"===========================================================");
        }
        public static void Swap(ref MyStruct a, ref MyStruct b)
        {
            MyStruct temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"in Swap ref - ms1 : {a.a}, {a.b}");
            Console.WriteLine($"in Swap ref - ms2 : {b.a}, {b.b}");
            Console.WriteLine($"===========================================================");
        }
        */
    }
    public struct MyStruct
    {
        public int a;
        public int b;
        public MyStruct(int a, int b)
        {
            this.a = a; this.b = b;
        }
    }

}
