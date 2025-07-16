namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    /// <summary>
    /// 링크드리스트로 참조를 가지고 구현
    /// </summary>
    public class MakeGraphList<T>
    {
        private int nodeCount; // 정점의 개수
        private int edgeCount; // 간선의 개수
        public Dictionary<T, LinkedList<T>> Graph;
        // 기본 그래프 생성자
        public MakeGraphList(int nodeCount, int edgeCount)
        {
            this.nodeCount = nodeCount;
            this.edgeCount = edgeCount;
            this.Graph = new Dictionary<T, LinkedList<T>>(nodeCount); // 정점의 개수만큼 생성
        }

        /// 무방향 그래프
        /// 양방향으로 저장되어야 함
        public void GraphNonDirecInsert(T keyNode, T valueNode)
        {
            if (Graph.ContainsKey(keyNode)) // Key로 Node1의 값을 가진 경우
            {
                Graph[keyNode].AddLast(valueNode);
                // 무방향그래프이므로 valueNode를 key로 가지는 값도 설정
                if (Graph.ContainsKey(valueNode))
                {
                    Graph[valueNode].AddLast(keyNode);
                }
                else
                {
                    Graph.Add(valueNode, new LinkedList<T>()); // 딕셔너리에 추가
                    Graph[valueNode].AddLast(keyNode);
                }
            }
            else // key를 가지지 않은 경우
            {
                Graph.Add(keyNode, new LinkedList<T>());
                Graph[keyNode].AddLast(valueNode);
                // 무방향그래프이므로 valueNode를 key로 가지는 값도 설정
                if (Graph.ContainsKey(valueNode))
                {
                    Graph[valueNode].AddLast(keyNode);
                }
                else
                {
                    Graph.Add(valueNode, new LinkedList<T>()); // 딕셔너리에 추가
                    Graph[valueNode].AddLast(keyNode);
                }
            }
        }

        /// 방향 그래프
        /// 단방향으로 저장되어야 함
        public void GraphDirecInsert(T keyNode, T valueNode)
        {
            if (Graph.ContainsKey(keyNode)) // Key로 Node1의 값을 가진 경우
            {
                Graph[keyNode].AddLast(valueNode);
            }
            else // key를 가지지 않은 경우
            {
                Graph.Add(keyNode, new LinkedList<T>());
                Graph[keyNode].AddLast(valueNode);
            }
        }

        /// DFS탐색
        /// 시작 노드를 받아서 탐색
        public void DFS(T startNode)
        {

        }
        
        /// BFS탐색
    }

    /// <summary>
    /// 2차원 배열로 그래프를 구현
    /// - 2차원 배열로 구현하는 경우 index를 사용하여 연결 여부를 확인하게 됨
    ///   이 경우 int 외의 노드값을 가지게 된다면 배열을 사용하는 의미가 없을 것 같음
    ///   => 2차원 배열로 그래프를 구현하는 경우는 위치를 index를 활용하여 지정할 수 있는 경우로 한정해서 사용하는 편이 좋아보임
    /// </summary>
    public class MakeGraphArr
    {
        private int nodeCount; // 정점의 개수
        public bool[,] Graph;
        public MakeGraphArr(int nodeCount)
        {
            Graph = new bool[nodeCount, nodeCount];
        }

        /// 무방향 그래프
        /// 양방향으로 저장되어야 함
        public void GraphNonDirecInsert(int keyNode, int valueNode)
        {
            Graph[keyNode, valueNode] = true;
            Graph[valueNode, keyNode] = true;
        }

        /// 방향 그래프
        /// 단방향으로 저장되어야 함
        public void GraphDirecInsert(int keyNode, int valueNode)
        {
            Graph[keyNode, valueNode] = true;
        }

        /// DFS탐색
        
        
        /// BFS탐색
    }

}