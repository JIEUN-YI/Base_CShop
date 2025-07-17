using System;
using System.Text;

namespace AStarAlgorism;

class Program
{
    static void Main(string[] args)
    {
        Map map = new Map(8, 5);
        map.DrawMap();
    }
}

/// <summary>
/// 가로세로를 입력받아 기본 맵을 제작하는 클래스
/// - 기본 맵은 bool[,]
/// - 벽은 false로 표현할 것
/// -      벽은 전체의 30%
/// - 배열의 [0,0]은 시작지점
/// -        [y-1, x-1]은 끝 지점으로 무조건 true
/// -        추후 추가 : 가능하다면 배열의 사이드 [0, 0 ~ x-1], [y-1, 0 ~ y-1], [0 ~ y-1 , 0], [0 ~ y-1, x-1] 은 false로 표시하면 좋음
/// - 맵 생성이 완료되면
///          벽은 X로 표시할 것
/// - 시작 점은 하얀 원 / 끝 점은 빨간 원으로 그릴 것
/// </summary>
public class Map
{
    private int x; // 가로
    private int y; // 세로

    private int roadCount;
    private int trueCount = 2; // 길의 갯수 = 기본 시작과 끝 2개
    public bool[,] MapData;
    public Map(int y, int x)
    {
        this.y = y;
        this.x = x;
        this.roadCount = (int)((x * y) * 0.7f); // 길을 만들 갯수
        MapData = new bool[y, x];

        // 시작과 끝점
        MapData[0, 0] = true;
        MapData[y - 1, x - 1] = true;

        Random random = new Random();

        // 랜덤으로 길을 생성
        while (trueCount < roadCount) // 길을 만든 갯수를 다 표현 할때까지
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (MapData[i, j] == false) // 벽이면
                    {
                        int num = random.Next(0, 2); // 0과 1중 하나 택 1
                        if (trueCount != roadCount && num == 0) // 길의 갯수가 남고 num == 0 이면
                        {
                            MapData[i, j] = true; // 길을 생성
                            trueCount++;
                        }
                        if(trueCount == roadCount)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 지도를 콘솔에 표현
    /// </summary>
    public void DrawMap()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (MapData[i, j] == false) // 벽이면
                {
                    sb.Append("■");
                }
                else
                {
                    sb.Append("□");
                    continue;
                }
            }
            sb.Append('\n'); // 줄바꿈
        }

        Console.WriteLine(sb.ToString());
    }
}



