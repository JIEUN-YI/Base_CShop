namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeGraphList<int> graph = new MakeGraphList<int>(5, 5);
            graph.GraphNonDirecInsert(0, 2);
            graph.GraphNonDirecInsert(1, 2);
            graph.GraphNonDirecInsert(1, 4);
            graph.GraphNonDirecInsert(2, 3);
            graph.GraphNonDirecInsert(3, 4);

            graph.BFS(0);

            Console.WriteLine("done");
        }
    }

    /// <summary>
    /// 링크드리스트로 참조를 가지고 구현
    /// </summary>
    public class MakeGraphList<T>
    {
        private int nodeCount; // 정점의 개수
        private int edgeCount; // 간선의 개수
        public Dictionary<T, List<T>> Graph; // 그래프를 완성

        public List<T> result; // 탐색 결과 저장
        private Dictionary<T, bool> visited; // 방문한 노드 확인

        private Stack<T> stack; // 스택에 노드를 담아서 DFS 확인
        private Queue<T> queue; // 큐에 노드를 담아서 BFS 확인

        // 기본 그래프 생성자
        public MakeGraphList(int nodeCount, int edgeCount)
        {
            this.nodeCount = nodeCount;
            this.edgeCount = edgeCount;
            this.Graph = new Dictionary<T, List<T>>(nodeCount); // 정점의 개수만큼 생성
            // 탐색에 필요한 항목
            this.stack = new Stack<T>(nodeCount);
            this.queue = new Queue<T>(nodeCount);
            this.result = new List<T>(nodeCount);
            this.visited = new Dictionary<T, bool>(nodeCount);
        }

        /// 무방향 그래프
        /// 양방향으로 저장되어야 함
        public void GraphNonDirecInsert(T keyNode, T valueNode)
        {
            if (!visited.ContainsKey(keyNode)) // 방문 확인용 딕셔너리에 설정
            {
                visited.Add(keyNode, false);
            }
            if (!visited.ContainsKey(valueNode))
            {
                visited.Add(valueNode, false);
            }
            if (Graph.ContainsKey(keyNode)) // Key로 keyNode의 값을 가진 경우
            {
                Graph[keyNode].Add(valueNode);
                // 무방향그래프이므로 valueNode를 key로 가지는 값도 설정
                if (Graph.ContainsKey(valueNode))
                {
                    Graph[valueNode].Add(keyNode);
                }
                else
                {
                    Graph.Add(valueNode, new List<T>()); // 딕셔너리에 추가
                    Graph[valueNode].Add(keyNode);
                }

            }
            else // key를 가지지 않은 경우
            {
                Graph.Add(keyNode, new List<T>());
                Graph[keyNode].Add(valueNode);

                // 무방향그래프이므로 valueNode를 key로 가지는 값도 설정
                if (Graph.ContainsKey(valueNode))
                {
                    Graph[valueNode].Add(keyNode);
                }
                else
                {
                    Graph.Add(valueNode, new List<T>()); // 딕셔너리에 추가
                    Graph[valueNode].Add(keyNode);
                }
            }
        }

        /// 방향 그래프
        /// 단방향으로 저장되어야 함
        public void GraphDirecInsert(T keyNode, T valueNode)
        {
            if (!visited.ContainsKey(keyNode)) // 방문 확인용 딕셔너리에 설정
            {
                visited.Add(keyNode, false);
            }
            if (!visited.ContainsKey(valueNode))
            {
                visited.Add(valueNode, false);
            }
            if (Graph.ContainsKey(keyNode)) // Key로 Node1의 값을 가진 경우
            {
                Graph[keyNode].Add(valueNode);
            }
            else // key를 가지지 않은 경우
            {
                Graph.Add(keyNode, new List<T>());
                Graph[keyNode].Add(valueNode);
            }
        }

        /// DFS탐색
        /// 시작 노드를 받아서 스택으로 탐색
        public void DFS(T startNode)
        {
            stack.Push(startNode); // 노드를 스택에 넣기
            while (this.stack.Count > 0)
            {
                T nowNode = stack.Pop(); // 본인을 스택에서 제거
                result.Add(nowNode);
                if (Graph.ContainsKey(nowNode)) // 딕셔너리에 key로 가지고 있다면
                {
                    if (Graph[nowNode].Count > 0) // 연결된 노드가 있으면
                    {
                        visited[nowNode] = true; // 딕셔너리에서 방문으로 변경
                        List<T> nowList = Graph[nowNode];
                        // 자식노드를 전부 스택에 넣기
                        for (int i = 0; i < nowList.Count; i++)
                        {
                            if (!visited[nowList[i]])
                            {
                                if (!stack.Contains(nowList[i]))
                                {
                                    stack.Push(nowList[i]);
                                }
                            }
                        }
                    }
                    else // 연결된 노드가 없다면
                    {
                        // result.Add(nowNode); // 결과에 저장 후
                        visited[nowNode] = true; // 딕셔너리에서 방문으로 변경
                    }
                }
                else
                {
                    visited[nowNode] = true; // 딕셔너리에서 방문으로 변경
                }
            }
        }

        /// BFS탐색
        /// 시작 노드를 받아서 큐로 탐색
        public void BFS(T startNode)
        {
            queue.Enqueue(startNode); // 노드를 큐에 넣기

            while (this.queue.Count > 0)
            {
                T nowNode = queue.Dequeue(); // 본인 제거
                result.Add(nowNode); // 결과에 현재 노드 저장
                if (Graph.ContainsKey(nowNode)) // 딕셔너리에 key로 가지고 있다면
                {
                    if (Graph[nowNode].Count > 0) // 연결된 노드가 있으면
                    {
                        visited[nowNode] = true; // 딕셔너리에서 현재 노드 방문으로 변경
                        List<T> nowList = Graph[nowNode];
                        // 방문전인 자식노드를 전부 큐에 넣기
                        for (int i = 0; i < nowList.Count; i++)
                        {
                            if (!visited[nowList[i]])
                            {
                                if (!queue.Contains(nowList[i]))
                                {
                                    queue.Enqueue(nowList[i]);
                                }
                            }
                        }
                    }
                    else // 연결된 노드가 없다면
                    {
                        visited[nowNode] = true; // 딕셔너리에서 방문으로 변경
                    }
                }
                else
                {
                    visited[nowNode] = true; // 딕셔너리에서 방문으로 변경
                }
            }
        }
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