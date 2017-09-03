using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main()
    {
        var line = Console.ReadLine().Split();
        int n = int.Parse(line[0]);
        int m = int.Parse(line[1]);


        int[] arr = Enumerable.Range(0, n).Select(_ => -1).ToArray();
        for (int i = 0; i < m; i++)
        {
            line = Console.ReadLine().Split(' ');
            var x = int.Parse(line[0]);
            int y = int.Parse(line[1]);

            Union(arr, x, y);

        }

        int[] companies = new int[n];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != -1)
            {
                arr[i] = Find(arr, i);
                companies[arr[i]]++;
            }
            else
            {
                companies[i]++;
            }
        }

        var result = 0;
        for (int i = 0; i < companies.Length; i++)
        {
            if (companies[i] > 0)
            {
                n -= companies[i];
                result += companies[i] * n;
            }
        }

        Console.WriteLine(result);
    }

    public static int Find(int[] arr, int index)
    {
        if (arr[index] == -1)
        {
            return index;
        }

        arr[index] = Find(arr, arr[index]);
        return arr[index];
    }

    public static bool Union(int[] arr, int x, int y)
    {
        x = Find(arr, x);
        y = Find(arr, y);

        if (x == y)
        {
            return false;
        }

        arr[x] = y;
        return true;
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _07.Conference
//{
//    public class Program
//    {
//        public static void Main()
//        {
//            var line = Console.ReadLine().Split(' ');
//            int developersCount = int.Parse(line[0]);
//            int pairsCount = int.Parse(line[1]);

//            var graph = new HashSet<int>[developersCount];

//            for (int i = 0; i < pairsCount; i++)
//            {
//                line = Console.ReadLine().Split(' ');

//                int from = int.Parse(line[0]);
//                int to = int.Parse(line[1]);

//                if (graph[from] == null)
//                {
//                    graph[from] = new HashSet<int>();
//                }

//                if (graph[to] == null)
//                {
//                    graph[to] = new HashSet<int>();
//                }

//                graph[from].Add(to);
//                graph[to].Add(from);
//            }

//            var visited = new bool[developersCount];
//            var developersByCompanies = new List<int>();

//            for (int i = 0; i < graph.Length; i++)
//            {
//                var currentNodeColleagues = GetCompanyMembers_DFS(i, graph, visited);

//                if (currentNodeColleagues > 0)
//                {
//                    developersByCompanies.Add(currentNodeColleagues);
//                }
//            }

//            var result = 0;
//            for (int i = 0; i < developersByCompanies.Count; i++)
//            {
//                for (int j = i + 1; j < developersByCompanies.Count; j++)
//                {
//                    result += developersByCompanies[i] * developersByCompanies[j];
//                }
//            }

//            Console.WriteLine(result);
//        }

//        public static int GetCompanyMembers_DFS(int index, HashSet<int>[] graph, bool[] visited)
//        {
//            if (graph[index] == null)
//            {
//                return 1;
//            }

//            if (visited[index])
//            {
//                return 0;
//            }

//            var result = 1;
//            visited[index] = true;

//            foreach (var node in graph[index])
//            {
//                if (!visited[node])
//                {
//                    result += GetCompanyMembers_DFS(node, graph, visited);
//                }
//            }

//            return result;
//        }
//    }
//}