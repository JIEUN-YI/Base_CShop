using System;
using System.Runtime.InteropServices;

namespace CShop_Study
{
    class BytePadding
    {
        static void Main(string[] args)
        {
            /// MyCI myCI = new MyCI('1', 1);
            /// Console.WriteLine(Marshal.SizeOf(myCI));
            /// Console.WriteLine("===========================");
            /// 
            /// MyIC myIC = new MyIC(1, '1');
            /// Console.WriteLine(Marshal.SizeOf(myCI));
            /// Console.WriteLine("===========================");

            /// MyS myS = new MyS("dd");
            /// Console.WriteLine(Marshal.SizeOf(myS));
            /// Console.WriteLine("===========================");
            /// MySI mySI = new MySI("a", 1);
            /// Console.WriteLine(Marshal.SizeOf(mySI));
            /// Console.WriteLine("===========================");
            /// MyIS myIS = new MyIS(1, "a");
            /// Console.WriteLine(Marshal.SizeOf(mySI));
            /// Console.WriteLine("===========================");
            /// 
            /// MyCIL myCIL = new MyCIL('a', 1, 2);
            /// Console.WriteLine(Marshal.SizeOf(myCIL));
            /// Console.WriteLine("===========================");
            /// MyILC myILC = new MyILC(1, 1, 'c');
            /// Console.WriteLine(Marshal.SizeOf(myILC));
            /// Console.WriteLine("===========================");
            /// MyLCI myLCI = new MyLCI(1, 'a', 2);
            /// Console.WriteLine(Marshal.SizeOf(myLCI));
            /// Console.WriteLine("===========================");
            /// MyDCI myDCI = new MyDCI(1.2M, 'a', 1);
            /// Console.WriteLine(Marshal.SizeOf(myDCI));
            /// Console.WriteLine("===========================");
            /// 
            /// MyCDI myCDI = new MyCDI('a', 1.2M, 1);
            /// Console.WriteLine(Marshal.SizeOf(myCDI));
            /// Console.WriteLine("===========================");
            /// 
            /// MyICD myICD = new MyICD(1, 'a', 1.2M);
            /// Console.WriteLine(Marshal.SizeOf(myICD));
            /// Console.WriteLine("===========================");
        }
        public struct MyCI
        {
            char a;
            int b;
            public MyCI(char a, int b) => (this.a, this.b) = (a, b);
        }
        public struct MyIC
        {
            int a;
            char b;
            public MyIC(int a, char b) => (this.a, this.b) = (a, b);
        }
        public struct MyS
        {
            string a;
            public MyS(string a) => (this.a) = (a);
        }

        public struct MySI
        {
            // 참조타입인 string은 4byte로 할당...?
            string a;
            int b;
            public MySI(string a, int b) => (this.a, this.b) = (a, b);
        }
        public struct MyIS
        {
            // 참조타입인 string은 4byte로 할당...?
            int a;
            string b;
            public MyIS(int a, string b) => (this.a, this.b) = (a, b);
        }
        public struct MyCIL
        {
            char a;
            int b;
            long c;
            public MyCIL(char a, int b, long c) => (this.a, this.b, this.c) = (a, b, c);
        }
        public struct MyILC
        {
            int b;
            long c;
            char a;
            public MyILC(int b, long c, char a) => (this.a, this.b, this.c) = (a, b, c);
        }
        public struct MyLCI
        {
            long c;
            char a;
            int b;
            public MyLCI(long c, char a, int b) => (this.a, this.b, this.c) = (a, b, c);
        }
        public struct MyDCI
        {
            decimal a;
            char b;
            int c;
            public MyDCI(decimal a, char b, int c) => (this.a, this.b, this.c) = (a, b, c);
        }
        public struct MyCDI
        {
            char b;
            decimal a;
            int c;
            public MyCDI(char b, decimal a, int c) => (this.b, this.a, this.c) = (b, a, c);
        }
        public struct MyICD
        {
            int c;
            char b;
            decimal a;
            public MyICD(int c, char b, decimal a) => (this.c, this.b, this.a) = (c, b, a);
        }
    }

}
