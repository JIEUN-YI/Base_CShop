using System.Text;

namespace AStarAlgorism;

public struct Node
{
    public int y;
    public int x;
    public Node(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int.TryParse(sr.ReadLine(), out int y);
        int.TryParse(sr.ReadLine(), out int x);
        Map map = new Map(y, x);

        map.AStar(y - 1, x - 1);
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
    public bool[,] checkList; // 확인한 길 여부
    public PriorityQueue<Node, int> priorityQueue;
    public Map(int y, int x)
    {
        this.y = y;
        this.x = x;
        this.roadCount = (int)((x * y) * 0.7f); // 길을 만들 갯수
        priorityQueue = new PriorityQueue<Node, int>(roadCount);

        MapData = new bool[y, x];
        checkList = new bool[y, x];

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
                        if (trueCount == roadCount)
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
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (MapData[i, j] == false) // 벽이면
                {
                    sb.Append("■");
                }
                else // 길이고
                {
                    if (checkList[i, j] == false) // 방문한 전이면
                    {
                        sb.Append("□");
                    }
                    else // 방문한 길이면
                    {
                        sb.Append("○");
                    }
                }
            }
            sb.Append('\n'); // 줄바꿈
        }
        Console.WriteLine(sb.ToString());
    }

    /// <summary>
    /// 상하좌우 대각선의 길을 찾는 알고리즘
    /// </summary>
    /// <param name="endY"></param>
    /// <param name="endX"></param>
    public void AStar(int endY, int endX)
    {
        int priority = 0;
        Node startNode = new Node(0, 0);
        Node nowNode = startNode;

        priorityQueue.Enqueue(startNode, priority); // 시작 노드를 우선순위 큐에 삽입

        // 벽이 아닌 MapData가 true인 경우에
        // [y, x]의 상하좌우 대각선의 f = g + h값 구하기
        while (checkList[endY,endX] == false)
        {
            nowNode = priorityQueue.Dequeue(); // 가장 우선순위가 높은 값
            checkList[nowNode.y, nowNode.x] = true; // 현재 위치를 방문으로 표시

            DrawMap();
            Thread.Sleep(1000);

            for (int i = Math.Max(0, nowNode.y - 1); i <= Math.Min(endY, nowNode.y + 1); i++)
            {
                for (int j = Math.Max(0, nowNode.y - 1); j <= Math.Min(endX, nowNode.x + 1); j++)
                {
                    if (MapData[i, j] == true && checkList[i, j] == false) // 길이고 방문 안한 노드
                    {
                        // g는 상하좌우 10, 대각선 14로 고정 h는 맨해튼거리공식 사용
                        if (nowNode.y != i && nowNode.y != j) // 대각선 선택지
                        {
                            priority = 14 + Manhattan(nowNode.y, nowNode.y, endY, endX);
                            Node nextNode = new Node(i, j);
                            priorityQueue.Enqueue(nextNode, priority); // 노드를 우선순위 큐에 삽입
                        }
                        else
                        {
                            priority = 10 + Manhattan(nowNode.y, nowNode.y, endY, endX);
                            Node nextNode = new Node(i, j);
                            priorityQueue.Enqueue(nextNode, priority); // 노드를 우선순위 큐에 삽입
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            if(priorityQueue.Count <= 0)
            {
                DrawMap();
                Console.WriteLine("길을 찾을 수 없습니다.");
                return;
            }
        }
        DrawMap();
        Console.WriteLine("길찾기를 완료했습니다.");

        // Map의 범위 내에서 구해진 f값을 비교 - 우선순위 f값으로 큐에 적재
        // 큐에서 위치와 f값의 합을 구하고 최솟값인 경우를 찾아서 이어가기?
    }

    /*
    public int Euclidean(Vector2 startNode, Vector2 endNode)
    {
        // 직선거리를 구하는 유클리디안
        int h = (int)Math.Sqrt((int)Math.Pow(endNode.X - startNode.X, 2) + (int)Math.Pow(endNode.Y - startNode.Y, 2));
        return h;
    }
    */
    public int Manhattan(int startNodeX, int startNodeY, int endNodeX, int endNodeY)
    {
        // 절대값을 이용하여 대각선 이동을 제한하는 맨해튼 거리 공식
        int h = Math.Abs(startNodeX - endNodeX) + Math.Abs(startNodeY - endNodeY);

        return h;
    }

}



