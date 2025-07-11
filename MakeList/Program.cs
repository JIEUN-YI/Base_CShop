using System.Drawing;

namespace CShop_Study
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeList<int> list1 = new MakeList<int>();
        }
    }
    public class MakeList<T>
    {
        public T[] array;
        /// <summary>
        /// 기본 생성자 => 기본 용량 4로 시작하는 배열 생성
        /// </summary>
        public MakeList()
        {
            this.array = new T[4];
        }

        /// <summary>
        /// 배열의 크기보다 큰 2의 거듭제곱으로 용량을 설정
        /// </summary>
        /// <param name="size"></param>
        public MakeList(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                double result = Math.Pow(2, i);
                if (size <= result)
                {
                    this.array = new T[(int)result];
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 배열이 가득 찼는데, 추가가 일어나는 경우 배열의 크기를 변경
        /// </summary>
        public void Change()
        {
            double result = 0;
            for (int i = 1; i <= this.array.Length; i++)
            {
                result = Math.Pow(2, i);
                if (this.array.Length <= result)
                {
                    
                    break;
                }
                else
                {
                    continue;
                }
            }
            T[] newArray = new T[(int)result]; // 새로운 용량의 배열을 만들기

            // 기존 배열의 원본을 복사하기
            for (int index = 0; index< this.array.Length; index++)
            {
                newArray[index] = this.array[index];
            }
            this.array = newArray; // 배열 변경
        }

        /// <summary>
        /// 리스트의 맨 뒤에 삽입
        /// </summary>
        public void Add(T node)
        {
            // 배열의 마지막 자리까지 꽉 차 있다면
            if (this.array[this.array.Length - 1] != null)
            {
                Change(); // 배열을 새로 배정
            }
            // 배열의 길이만큼 확인
            for (int index = 0; index < this.array.Length; index++)
            {
                // 자리가 비어있다면
                if (this.array[index] == null)
                {
                    this.array[index] = node;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 원하는 위치(인덱스) 자리에 자료 삽입
        /// </summary>
        public void Insert()
        {

        }

        /// <summary>
        /// 원하는 값을 인덱스 번호 순으로 탐색하여 앞 번호의 값을 삭제
        /// </summary>
        public void Remove()
        {

        }

        /// <summary>
        /// 인덱스 번호를 찾아 값 삭제
        /// </summary>
        public void RemoveAt()
        {

        }
    }

}