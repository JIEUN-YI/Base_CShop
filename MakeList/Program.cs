namespace CShop_Study
{
    class Program
    {
        static void Main(string[] args)
        {

            MakeList<int> list1 = new MakeList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(5);
            list1.Insert(1, 10);
            list1.Add(9);
            list1.Add(6);
            list1.Add(7);
            list1.Remove(1);
            list1.RemoveAt(0);

            for(int i = 0; i < list1.capacity; i++)
            {
                Console.WriteLine(list1.array[i]);
            }
        }
    }
    public class MakeList<T>
    {
        public T[] array;
        public int size;
        public int capacity;
        /// <summary>
        /// 기본 생성자 => 기본 용량 4로 시작하는 배열 생성
        /// </summary>
        public MakeList()
        {
            this.array = new T[4];
            capacity = 4;
            size = 0;
        }

        /// <summary>
        /// 배열의 크기보다 큰 2의 거듭제곱으로 용량을 설정
        /// </summary>
        /// <param name="count"></param>
        public MakeList(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                double result = Math.Pow(2, i);
                if (count <= result)
                {
                    this.array = new T[(int)result];
                    break;
                }
                else
                {
                    continue;
                }
            }
            size = 0;
            capacity = array.Length;
        }

        /// <summary>
        /// 배열이 가득 찼는데, 추가가 일어나는 경우 배열의 크기를 변경
        /// </summary>
        public void Change()
        {
            double result = 0;
            for (int i = 1; i <= capacity; i++)
            {
                result = Math.Pow(2, i);
                if (capacity < result)
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
            for (int index = 0; index < this.array.Length; index++)
            {
                newArray[index] = this.array[index];
            }
            this.array = newArray; // 배열 변경
            capacity = newArray.Length;
        }

        /// <summary>
        /// 리스트의 맨 뒤에 삽입
        /// </summary>
        public void Add(T node)
        {
            // 배열의 마지막 자리까지 꽉 차 있다면
            if (size == capacity)
            {
                Change(); // 배열을 새로 배정
                this.array[size] = node;
                size++; // 사이즈 다음 자리
            }
            else // 자리가 남았다면
            {
                this.array[size] = node;
                size++; // 사이즈 다음 자리
            }
        }

        /// <summary>
        /// 원하는 위치(인덱스) 자리에 자료 삽입
        /// </summary>
        public void Insert(int index, T value)
        {
            for (int i = size - 1; i >= index; i--)
            {
                this.array[i + 1] = this.array[i];
            }
            this.array[index] = value;
            size++;
        }

        /// <summary>
        /// 원하는 값을 인덱스 번호 순으로 탐색하여 앞에 있는 값을 삭제 후
        /// size--;
        /// 배열의 값들을 앞으로 전부 옮기기
        /// </summary>
        public void Remove(T value)
        {
            int emtpy = 0;
            // 특정 값을 가지고 있다면
            if (this.array.Contains(value))
            {
                for (int index = 0; index < size; index++) // 탐색해서
                {
                    if (value.Equals(this.array[index]))
                    {
                        this.array[index] = default(T); // 기본값으로 변환
                        size--;
                        emtpy = index; // 현재 인덱스 값이 비었음
                        break; // 탐색 종료
                    }
                }
            }
            // 배열을 앞으로 당기기
            for (int index = emtpy; index < size; index++)
            {
                this.array[index] = this.array[index + 1];
            }
            this.array[size] = default(T); // 가장 마지막에 있는 값을 기본값으로 전환
        }

        /// <summary>
        /// 인덱스 번호를 찾아 값 삭제
        /// </summary>
        public void RemoveAt(int targetIndex)
        {
            // 전체 용량보다 인덱스가 작을때만 실행
            if (capacity > targetIndex)
            {
                this.array[targetIndex] = default(T); // 목표 인텍스 번호의 위치를 삭제
                size--;
                // 그 위치부터 배열을 앞으로 당기기
                for (int index = targetIndex; index < size; index++)
                {
                    this.array[index] = this.array[index + 1];
                }
                this.array[size] = default(T); // 가장 마지막에 있는 값을 기본값으로 전환
            }
        }
    }

}