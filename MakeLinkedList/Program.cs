using System;
using System.Collections.Generic;

namespace MakeLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeLinkedList<int> sample = new MakeLinkedList<int>();
            sample.AddLast(8);
            sample.AddFirst(1);
            sample.AddFirst(2);
            sample.AddFirst(3);
            Node<int> basisNode = sample.Find(1);
            sample.AddAfter(basisNode, 6);
            basisNode = sample.Find(6);
            sample.AddBefore(basisNode, 5);
        }
    }

    /// <summary>
    /// 노드 클래스
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public Node<T> preNode; // 현재 노드의 앞 데이터
        public T value; // 현재 노드의 원본 데이터
        public Node<T> nextNode; // 현재 노드의 다음 데이터
        // isLast isFirst를 걸어서 프로퍼티로 선언가능 - 재성강사님
        // bool변수를 가지고 있다면 MakeLinkedList<T>에서 변수를 활용하여 가독성 좋은 코드 제작 가능

        // 아무런 참조도 없는 1개의 노드 생성자
        public Node(T value)
        {
            this.value = value;
            this.preNode = null;
            this.nextNode = null;
        }

        // 데이터 저장과 동시에 노드 연결
        public Node(MakeLinkedList<T> list, Node<T> frontNode, T value, Node<T> backNode)
        {
            this.preNode = frontNode;
            this.nextNode = backNode;
            this.value = value;
        }
    }

    /// <summary>
    /// 연결 리스트 클래스
    /// </summary>
    public class MakeLinkedList<T>
    {
        public Node<T> first; // 맨 첫 노드
        public Node<T> last; // 마지막 노드
        public int count;

        public MakeLinkedList() // 기본 생성자
        {
            this.first = null;
            this.last = null;
            count = 0;
        }

        /// <summary>
        /// 노드를 맨 앞에 삽입
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value); // 기본으로 노드를 생성

            if (first != null) // 시작 값이 있으면
            {
                // 시작 값을 새 노드로 변경
                newNode.nextNode = first; // 현재 노드의 뒤에 지금 시작 값을 연결
                first.preNode = newNode; // 원래의 첫번째 노드의 front로 현재의 노드를 연결
                first = newNode; // 맨 앞 노드를 변경
                count++; // 용량 증가
            }
            else
            {
                // 빈 리스트에 리스트를 삽입
                first = newNode; // 현재 노드가 시작과
                last = newNode; // 끝
                count++; // 용량 증가
            }
        }

        /// <summary>
        /// 노드를 맨 뒤에 삽입
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value); // 기본으로 노드를 생성
            // 맨 끝에 노드를 삽입
            if(last != null) // 끝 값이 있으면
            {
                last.nextNode = newNode; // 마지막의 다음 노드에 삽입
                newNode.preNode = last; // 현재 노드의 앞 노드가 마지막 노드가 됨
                last = newNode; // 마지막이 현재 노드가 되고
                count++; // 삽입이므로 용량 증가
            }
            else // 끝 값이 없으면 = 첫 삽입
            {
                first = newNode;
                last = newNode;
                count++;
            }
        }

        /// <summary>
        /// AddAfter / AddBefore의 경우 순회로 Node값을 찾은 후에 그 노드 뒤에 새 노드를 삽입해야함
        /// 값으로 노드를 찾는 순회를 시작
        /// </summary>
        /// <param name="value"></param>
        public Node<T> Find(T value)
        {
            Node<T> nowNode = first; // 현재 탐색하는 노드
            if(value != null)
            {
                while(nowNode != null)
                {
                    if(value.Equals(nowNode.value)) // 현재 노드와 찾으려는 데이터가 같으면
                    {
                        // 현재노드 출력
                        return nowNode;
                    }
                    else // 다르면
                    {
                        // 현재 노드를 다음 노드로 이동
                        nowNode = nowNode.nextNode;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 기준 노드의 뒤에 새 노드를 삽입
        /// </summary>
        /// <param name="value"></param>
        /// <param name="basisNode"></param>
        public void AddAfter(Node<T> basisNode, T value)
        {
            // 새 노드 생성
            Node<T> newNode = new Node<T>(value);
            // 기준 노드의 다음 노드가 있으면
            if(basisNode.nextNode != null)
            {
                newNode.preNode = basisNode; // 새 노드의 앞은 기준 노드
                newNode.nextNode = basisNode.nextNode; // 새 노드의 다음 노드는 기준 노드의 다음 노드
                basisNode.nextNode.preNode = newNode; // 기준노드의 다음 노드의 앞 노드 = 현재 노드
                basisNode.nextNode = newNode; // 기준 노드의 다음 노드는 새 노드
            }
            else // 기준 노드의 다음이 없으면
            {
                newNode.preNode = basisNode; // 새 노드의 앞은 기준 노드
                basisNode.nextNode= newNode; // 기준 노드의 다음 노드는 새 노드
                last = newNode; // 다음이 없는 노드 = last 노드 이므로 last 노드 변경
            }
            // 새 노드가 삽입 = 용량 증가
            count++;
        }

        /// <summary>
        /// 기준 노드 앞에 새 노드를 삽입
        /// </summary>
        /// <param name="basisNode"></param>
        /// <param name="value"></param>
        public void AddBefore(Node<T> basisNode, T value)
        {
            // 새 노드 생성
            Node<T> newNode = new Node<T>(value);
            // 기준 노드의 앞 노드가 있으면
            if (basisNode.nextNode != null)
            {
                newNode.preNode = basisNode.preNode; // 현재 노드의 앞 = 기준 노드의 앞
                newNode.preNode.nextNode = newNode; // 현재 노드의 앞 노드의 다음노드 = 기준노드
                basisNode.preNode = newNode; // 기준노드의 앞에 새 노드
                newNode.nextNode = basisNode; // 새 노드의 다음은 기준 노드
            }
            else // 기준 노드의 앞 노드가 없으면
            {
                // 맨 앞에 노드 삽입
                basisNode.preNode = newNode;
                newNode.nextNode = basisNode;
                first = newNode;
            }
            // 새 노드가 삽입 = 용량 증가
            count++;
        }
    }

}
