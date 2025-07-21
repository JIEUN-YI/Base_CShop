using System;
using static System.Net.Mime.MediaTypeNames;

namespace ArrayLesson
{
    class Program
    {
        static void Main(string[] args)
        {


        }
    }

    /* 1. 배열의 기본 개념과 사용 방법
     * 배열의 선언과
     * int[] array1;
     * 배열의 할당
     * array1 = new int[3];
     * 위의 두줄을 한줄로 선언할 수 있다.
     * int[] array2 = new int[3];
     * 인덱스를 활용하여 배열에 값을 저장하기
     * 인덱스는 0부터 시작한다는 것을 꼭 언급하기
     * array2[0] = 1;
     * array2[1] = 2;
     * array2[2] = 2;
     * 같은 값이 다른 위치에 할당할 수 있다고 보여주기
     * array2[3] = 4;
     * 인덱스 범위가 선언한 용량을 넘어가면 에러가 발생하는 것을 보여주기
     * 
     * 또한 배열의 자료를 미리 넣어서 할당 할 수 있다.
     * int[] array3 = { 1, 2, 3 };
     * 
     * 다양한 자료형을 담는 배열 보여주기
     * char[] arrayChar = new char[5];
     * double[] arrayDouble = new double[5];
     * string[] arrayString = new string[5];
     * 
     * 기존에 완성한 int 배열을 활용하여 인덱스로 값을 불러와 콘솔에 띄우기
     * int a = array2[0];
     * Console.WriteLine(array2[0]);
     * Console.WriteLine(a);
     * 
     */
    /* 2. 2차원 배열의 활용
     * 
     * 2차원 배열의 선언
     * int[,] example = new int[5, 5];
     * 인덱스를 활용한 2차원 배열의 값 저장
     * example[0, 0] = 1;
     * example[0, 3] = 4;
     * example[1, 3] = 3;
     * example[1, 3] = 2;
     * 
     * Console.WriteLine(example[0,3]); // 인덱스를 활용한 값 불러오기
     * 
     * 새롭게 할당하는 2차원 배열
     * bool[,] array
     *     = new bool[5, 5]
     *     {   { false,false,false,false,false},
     *         { false,false,false,false,false},
     *         { false,false,false,false,false},
     *         { false,false,false,false,false},
     *         { false,false,false,false,false}
     *     };
     * 
     * 2차원 배열로 맵을 표현하거나 좌표 관리를 할 수 있다는 것을 언급하고
     *  => 추가적으로 활용 요소를 그림으로 영상에 출력하며 설명이 조히을 듯
     * 다음에는 맵을 표현하는 실습으로 for문과 foreach문을 활용하는 것으로 넘어가기
     */
    /* 3. 반복문과 함께하는 배열의 활용
     * 배열이 인덱스로 관리되기 때문에 이를 활용한 반복을 사용할 수 있다는 것을 언급
     * 1차 배열과 foreach문
     * int[] countdown = { 5, 4, 3, 2, 1 };
     * foreach (int num in countdown)
     * {
     *     Console.WriteLine(num);
     * }
     * 2차 배열과 for문
     * 2차 배열로 할 수 있는 맵을 표현해볼까요?
     * bool[,] map = new bool[10, 10]
     * {
     *     { false, false, false, false, false, false, false, false, false, false},
     *     { false,  true,  true,  true,  true,  true,  true, false, false, false},
     *     { false,  true,  true, false,  true, false, false, false, false, false},
     *     { false, false,  true,  true, false, false, false, false, false, false},
     *     { false, false, false,  true, false, false, false, false, false, false},
     *     { false,  true,  true,  true, false,  true,  true, false,  true, false},
     *     { false,  true, false, false,  true, false,  true,  true,  true, false},
     *     { false,  true,  true,  true,  true, false,  true,  true,  true, false},
     *     { false, false,  true, false,  true,  true,  true,  true,  true, false},
     *     { false, false, false, false, false, false, false, false, false, false}
     * };
     * 
     * 배열은 y축이 먼저 계산된다는 것에 주의 하도록 설명하며 1차원 배열에서의 Length도 보여줄 것
     * int[] countdown = { 5, 4, 3, 2, 1 };
     * for(int i = 0; i<countdown.Length; i++)
     * {
     *     Console.WriteLine(countdown[i]);
     * }
     * 
     * GetLength(0) 세로 열 = y, GetLength(1) 가로 열 = x
     * for(int y = 0; y < map.GetLength(0); y++)
     * {
     *     for(int x = 0; x < map.GetLength(1); x++)
     *     {for문과 foreach문의 비교
     *         if (map[y,x] == false)
     *         {
     *             Console.Write("X");
     *         }
     *         else
     *         {
     *             Console.Write(" ");
     *         }
     *     }
     *     Console.Write("\n");
     */
    /* 4. 배열과 타입
     * 
     * var 형식은 추론 형식이라고 부릅니다.
     * 암시적으로 변환을 시켜주는 자료형입니다.
     * 선언된 변수에 저장되는 값은 추론해서 적당한 형식으로 변환합니다.
     * 
     * string[] example = new string[] { "abc", "def", "ghi" };
     * foreach (var s in example)
     * {
     *     Console.WriteLine(s);
     * }
     * 
     * 이렇게 사용하게 되는 이유는 많은 배열을 사용하다보니 형을 잘못 지정해서 에러가 나는 상황을 막기위해 사용할 수 있습니다.
     * 단, var형은 전역 변수로 선언할 수 없다는 점에 주의해야합니다.
     *      => 전역 변수 : 함수의 외부에서 선언되는 변수
     *      => 지역 변수 : 함수 속에 선언되어 해당 함수에서만 사용 가능한 변수
     * class Program
     * {
     *     var l = false;
     *     static void Main(string[] args)
     *     {
     * 
     *         var a;
     *         var b = 1;
     * 
     *     }
     * }
     * string 변수가 char로 이루어진 배열이라는 것을 확인하는 시간
     * string은 char 개체의 순차적 읽기 전용 컬렉선으로 저장
     * string test = "배열 정복 그 자체";
     * 문자열 test에 포함된 char 개체의 수를 표현함
     * 
     * Console.WriteLine(test.Length);
     * foreach(var s in test)
     * {
     *     Console.WriteLine(s);
     * }
     * 
     * foreach (char s in test)
     * {
     *     Console.WriteLine(s);
     * }
     * string 문자열은 불변성을 가집니다.
     */
}








