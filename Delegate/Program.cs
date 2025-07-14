namespace Delegate
{
    // 클래스 외부에 선언된 delegate
    // 해당 네임스페이스에서 접근 가능한 모든 클래스에 사용
    delegate void Delegated(string name);
    delegate int DelegatingAdd(int a, int b);
    delegate void DelegateN();
  
    class Program
    {
        static void Main(string[] args)
        {
            MyClass ms = new MyClass();

            // 델리게이트 선언
            Delegated delegating = new Delegated(ms.DelegateEx);
            DelegatingAdd delegateAdd = new DelegatingAdd(ms.Ex3Add);
            DelegateN delegateN = new DelegateN(ms.DelegateN);

            delegating("Show");

            Console.WriteLine("==========================");

            delegating += ms.DelegateEx2; // 새 델리게이트 할당 = 델리게이트 체인 제작

            delegating("Show");
            Console.WriteLine("==========================");

            int a = delegateAdd(3, 5);
            Console.WriteLine("==========================");
            Console.WriteLine(a);
            Console.WriteLine("==========================");
            delegateN();
            /*
            Thread t = new Thread(threadFunc);
            t.IsBackground = true;
            t.Start();


            while (true)
            {
                // 가비지컬렉터의 각 세대에서 가비지 수집이 몇 번 일어났는지 모두 체크한다
                int n = GC.CollectionCount(0) + GC.CollectionCount(1) + GC.CollectionCount(2);
                Console.WriteLine(n);

                Thread.Sleep(1000);
            }
            */

        }
        /*
        private static void threadFunc()
        {
            void DelegateEx(string name)
            {
                
            }
            void DelegateEx2(string name)
            {
                
            }
            void DelegateEx3(string name)
            {
                
            }

            Delegated delegating = new Delegated(DelegateEx);
            while (true)
            {
                // 델리게이트 체인
                delegating += DelegateEx2;
                delegating += DelegateEx3;
                delegating("A");
            }
        }
        */
    }

    public class MyClass
    {
        public void DelegateEx(string name)
        {
            Console.WriteLine($"Deleate Test : {name}");
        }
        public void DelegateEx2(string name)
        {
            Console.WriteLine($"Deleate Test2 : {name}");
        }
        public int Ex3Add(int x, int y)
        {
            int result = x + y;
            Console.WriteLine($"result : {result}");
            return result;
        }
        public void DelegateN()
        {
            Console.WriteLine($"매개변수 없음");
        }
    }
}