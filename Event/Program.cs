
using static Event.MyEventPublisher;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEventPublisher publisher = new MyEventPublisher(); // 이벤트를 제작한 선언
            publisher.MyEvent += MyEventHandler; // 이벤트 발행(실행)자의 이벤트 발생 목록에 함수를 저장 = 일종의 델리게이트 체인
            publisher.MyShow += ShowCount; // 이벤트 발행(실행)자의 이벤트 발생 목록에 함수를 저장 = 일종의 델리게이트 체인
            for (int i = 0; i < 10; i++)
            {
                if( i == 5)
                {
                    publisher.StartEvent(); // 이벤트를 실행
                }
                else
                {
                    publisher.OnShowEvent(i);
                }
            }
        }
        /// <summary>
        /// object sender = 이벤트가 발생한 객체 자체
        /// EventArgs e = 이벤트와 관련된 데이터를 담고 있는 객체
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void MyEventHandler(object sender, EventArgs e) // EventHandler가 (object sender, EventArgs e)를 변수로 가지는 delegate
        {
            Console.WriteLine($"출력합니다.");
        }
        static void ShowCount(int count)
        {
            Console.WriteLine(count);
        }
    }

    public class MyEventPublisher
    {
        // 변수를 받는 이벤트 제작을 위한 델리게이트
        public delegate void ShowEvent(int value);

        public event ShowEvent MyShow; // 변수를 받는 이벤트 제작
        public event EventHandler MyEvent; // 이벤트 핸들러 등록

        /// <summary>
        /// 이벤트로 제작되었기 때문에
        /// 클래스 외부에서 이벤트를 출력 불가능 = 함수로 이벤트 출력을 제어함
        /// </summary>
        public void StartEvent()
        {
            // MyEvent를 선언한 외부에서 이대로 출력 불가능
            MyEvent?.Invoke(this, EventArgs.Empty); // 이벤트 핸들러 등록 여부 확인 후 호출
        }
        public void OnShowEvent(int value)
        {
            MyShow?.Invoke(value);
        }
    }
}