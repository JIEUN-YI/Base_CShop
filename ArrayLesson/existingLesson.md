# 배열

## 개요

![ArrayListInit](https://develrocket-bucket.s3.ap-northeast-2.amazonaws.com/learning/XRP-102/XRP-10202_ProgrammingLanguage/XRP-1020201_ProgrammingBasics/XRP-102020107_ArrayList/ArrayListInit.png)

- 서로 관련이 있고, 자료형이 같을 경우, 하나의 묶음으로 만들 수 있습니다. 학생들의 성적이나, 아파트의 세대주 명 등, 비슷한 계열의 자료를 묶을 때, 배열이라는 기능을 사용하면 편합니다. 이번 강의에서는 배열에 대하여 알아보도록 하겠습니다.

## 학습 목표

- 배열의 이해
- 배열의 사용법 숙지 및 실전 활용
- 참조형에 대한 이해

<br>

## 배열의 개념

  <video width="100%" height="100%" controls>
    <source src="https://develrocket-bucket.s3.ap-northeast-2.amazonaws.com/learning/XRP-102_Video/XRP-102020107_ArrayList/01.mp4">
  </video>

<br>

## 배열의 사용 방법

  <video width="100%" height="100%" controls>
    <source src="https://develrocket-bucket.s3.ap-northeast-2.amazonaws.com/learning/XRP-102_Video/XRP-102020107_ArrayList/02.mp4">
  </video>

<br>

## 배열과 반복문

  <video width="100%" height="100%" controls>
    <source src="https://develrocket-bucket.s3.ap-northeast-2.amazonaws.com/learning/XRP-102_Video/XRP-102020107_ArrayList/03.mp4">
  </video>

<br>

## 다차원 배열

 <video width="100%" height="100%" controls>
   <source src="https://develrocket-bucket.s3.ap-northeast-2.amazonaws.com/learning/XRP-102_Video/XRP-102020107_ArrayList/04.mp4">
 </video>

<br>

## Var 키워드

- C#에는 자료형을 추론해주는 기능인 var이라는 키워드가 존재합니다. 자료형을 직접 입력하는 대신, 그 자리에 var을 입력하면 우항서 대입되는 값의 자료형에 따라 자료형을 만들어주는 기능입니다. 항상 사용 가능하진 않고, 추후 배울 지역 변수나 스크립트라는 곳 속에서만 쓸 수 있습니다. <br><br> 코드를 예로 들어볼까요?

  <br>

  >```csharp
  >int intNum = 4;
  >var intNum2 = 12;
  >
  >float flNum = 2.24f;
  >var flNum2 = 5.25f;
  >```
  >
  >이와 같은 방식으로 대입연산자를 통해 들어오는 값에 따라 타입을 추론하여 var형은 int형이 되기도, float형이 되기도 합니다. <br> var varNum; 와 같이 단독으로 만드는 것은, 추론할 대상이 없기에 불가능합니다.

  <br>

  foreach문의 경우, 코드가 방대해지면 배열 같은 다량의 정보를 담고 있는 컨테이너에 어떤 요소가 들어있는지 매번 알아내기 번거로울 수 있는데, 이는 var 키워드를 쓰면 수월하게 코드 작성이 가능합니다.

  <br>

  >```csharp
  >foreach(var s in shortCuts) 
  >{
  >    Console.WriteLine(s);
  >}
  >```
  >
  >위 코드에서는 옆 배열에 어떤 자료형의 요소가 들어있었던 해당 요소의 형식에 맞추어 s의 자료형이 결정되고 값이 하나하나 담기게 됩니다.

<br>

## 다시 보는 string

  <video width="100%" height="100%" controls>
    <source src="https://develrocket-bucket.s3.ap-northeast-2.amazonaws.com/learning/XRP-102_Video/XRP-102020107_ArrayList/05.mp4">
  </video>

<br>

## 참고 자료

- [1차원 배열 - C# 프로그래밍 가이드](https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays)
- [배열에 foreach 사용 - C# 프로그래밍 가이드](https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/arrays/using-foreach-with-arrays)
- ‘이것이 C#이다’ 교재 375p ~ 393p

## 수업 녹화본

<br>

  <video width="100%" height="100%" controls>
    <source src="https://develrocket-bucket.s3.ap-northeast-2.amazonaws.com/learning/XRP-102_Record/XRP-102020107.mp4">
  </video>