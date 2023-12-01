using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Astar
    {
        private class Node
        {
            public Position pos;
            public Position parent;

            public int f;
            public int g;
            public int h;

            public Node(Position pos, Position parent, int g, int h)
            {
                this.pos = pos;
                this.parent = parent;
                this.g = g;
                this.h = h;

                f = g + h;
            }
        }

        const int Cost = 10; // 맨해튼으로 휴리스틱 계산할거기 때문에 대각선거리는 따로 설정 x

        static Position[] Direction =
        {
            new Position(1,  0),  // 상
            new Position(-1, 0),  // 하
            new Position(0,  1),  // 좌
            new Position(0, -1)   // 우
        };
        public static bool PathFinding(Position start, Position destPos, List<Position> path)
        {
            char[,] map = Data.Instance.map;
            Position end = Data.Instance.player.pos;

            // 만약 플레이어가 이동하지 않았다면
            // 경로를 다시 탐색 하지 않고 리턴해서
            // 그 전의 값으로 이동할 수 있도록
            if (end.x == destPos.x && end.y == destPos.y)
                return false;

            int ySize = map.GetLength(0);
            int xSize = map.GetLength(1);

            // 초기화
            Node[,] nodes = new Node[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize];
            PriorityQueue<Node, int> nextPositionPQ = new PriorityQueue<Node, int>();

            // 시작 정점을 생성하여 추가
            Node startNode = new Node(start, new Position(0, 0), 0, Heuristic(start, end));
            nodes[startNode.pos.y, startNode.pos.x] = startNode;
            nextPositionPQ.Enqueue(startNode, startNode.f);


            while (nextPositionPQ.Count > 0)
            {
                // 다음으로 탐색할 정점 꺼내서 방문했다 표시
                Node nextNode = nextPositionPQ.Dequeue();
                visited[nextNode.pos.y, nextNode.pos.x] = true;

                // 도착이면 지금까지의 경로 반환
                if (nextNode.pos.x == end.x && nextNode.pos.y == end.y)
                {

                    Position position = end;
                    // 마지막 정점부터 여기까지 온 경로를 path 리스트에 추가
                    // parent == 내가 여기 오기 전의 정점
                    while (!(position.x == start.x && position.y == start.y))
                    {
                        path.Add(position);
                        position = nodes[position.y, position.x].parent;
                    }

                    // 마지막에 내가 어디서 출발했는지를 path 리스트에 추가
                    // path.Add(start);
                    // -> 이미 몬스터의 위치가 start에 있고
                    // 그 다음 위치를 어디로 할지가 중요하기 때문에 start는 제외


                    path.Reverse();
                    return true;
                }

                // 도착이 아니면 방향 탐색 (Astar)
                for (int i = 0; i < Direction.Length; i++)
                {
                    // Direction에 있는 경우(상,하,좌,우) 를 지금 좌표에서 더하며 
                    // 주변 노드들 f값 갱신
                    int x = nextNode.pos.x + Direction[i].x;
                    int y = nextNode.pos.y + Direction[i].y;

                    // 맵 벗어남
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // X 구역으로는 탐색 안함
                    else if ('X' == map[y, x])
                        continue;
                    // 이미 방문한 정점이면 건너뜀
                    else if (visited[y, x])
                        continue;

                    // 이제는 탐색하는 정점
                    int g = nextNode.g + Cost;
                    // 현재 정점에서 end까지의 새로운 휴리스틱 계산
                    int h = Heuristic(new Position(x, y), end);
                    // nextNode == newNode를 찾은 정점 -> newNode의 부모 정점
                    Node newNode = new Node(new Position(x, y), nextNode.pos, g, h);

                    // 처음 발견한 정점이거나 || 새로운 노드의 가중치(f)가 더 작은 경우
                    if (nodes[y, x] == null || nodes[y, x].f > newNode.f)
                    {
                        nodes[y, x] = newNode;
                        nextPositionPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }

            // 여기까지 온거면 이상한거임;
            path = null;
            return false;
        }
        private static int Heuristic(Position start, Position end)
        {
            int xSize = Math.Abs(start.x - end.x); // 가로로 가야하는 거리
            int ySize = Math.Abs(start.y - end.y); // 세로로 가야하는 거리

            return Cost * (xSize + ySize);
        }
    }
}
