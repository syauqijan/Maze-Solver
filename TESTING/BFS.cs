using System;
using System.Collections.Generic;
using System.Linq;
using static Map.Maze;
namespace MazeWithBFS
{
    class BFS
    {
        public static Queue<Tuple<int, int>> nodeBFS = new Queue<Tuple<int, int>>();

        static IDictionary<Tuple<int, int>, Tuple<int, int>> BFSMaze(char[,] Matrix, Tuple<int, int> start)
        {
            IDictionary<Tuple<int, int>, Tuple<int, int>> tempPath = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            Queue<int> index = new Queue<int>();
            Tuple<int, int> neighbor = Tuple.Create(0, 0);

            queue.Enqueue(start);
            tempPath.Add(start, Tuple.Create(-1, -1));
            while (queue.Count != 0)
            {
                Tuple<int, int> current = queue.Dequeue();
                if (!nodeBFS.Contains(current))
                {
                    nodeBFS.Enqueue(current);
                }
                if (Matrix[current.Item1, current.Item2] == 'T')
                {
                    break;
                }
                List<char> RDUL = findNeighbor(current, Matrix);
                foreach (var item in RDUL)
                {
                    if (item == 'R')
                    {
                        neighbor = Tuple.Create(current.Item1, current.Item2 + 1);
                        if (!tempPath.ContainsKey(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            tempPath.Add(neighbor, current);
                        }
                    }
                    else if (item == 'D')
                    {
                        neighbor = Tuple.Create(current.Item1 + 1, current.Item2);
                        if (!tempPath.ContainsKey(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            tempPath.Add(neighbor, current);
                        }
                    }
                    else if (item == 'U')
                    {
                        neighbor = Tuple.Create(current.Item1 - 1, current.Item2);
                        if (!tempPath.ContainsKey(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            tempPath.Add(neighbor, current);
                        }
                    }
                    else if (item == 'L')
                    {
                        neighbor = Tuple.Create(current.Item1, current.Item2 - 1);
                        if (!tempPath.ContainsKey(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            tempPath.Add(neighbor, current);
                        }
                    }
                }
            }
            int k = tempPath.Count - 1;
            while (Matrix[tempPath.ElementAt(k).Key.Item1, tempPath.ElementAt(k).Key.Item2] != 'T')
            {
                tempPath.Remove(tempPath.ElementAt(k).Key);
                k--;
            }
            return deleteBacktrack(tempPath, Matrix);
            // return tempPath;
        }

        public static List<Tuple<int, int>> GetAllTrasureBFS(char[,] Matrix, int treasure, Tuple<int, int> start)
        {
            List<IDictionary<Tuple<int, int>, Tuple<int, int>>> path = new List<IDictionary<Tuple<int, int>, Tuple<int, int>>>();
            List<Tuple<int, int>> FinalPath = new List<Tuple<int, int>>();
            IDictionary<Tuple<int, int>, Tuple<int, int>> tempPath = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            Tuple<int, int> tempStart = Tuple.Create(0, 0);
            Tuple<int, int> tempNextStart = Tuple.Create(0, 0);

            if (treasure == 1)
            {
                tempPath = BFSMaze(Matrix, start);
                path.Add(tempPath);
            }
            else
            {
                for (int i = 0; i < treasure; i++)
                {
                    tempPath = BFSMaze(Matrix, start);
                    Tuple<int, int> origin = tempPath.ElementAt(0).Key;
                    Matrix[origin.Item1, origin.Item2] = 'R';
                    start = tempPath.ElementAt(tempPath.Count - 1).Key;
                    Matrix[start.Item1, start.Item2] = 'R';
                    if (i > 0)
                    {
                        tempPath.Remove(tempPath.ElementAt(0).Key);
                    }
                    path.Add(tempPath);
                }
            }
            foreach (var item in path)
            {
                foreach (var item2 in item)
                {
                    FinalPath.Add(item2.Key);
                }
            }
            return FinalPath;
        }

        public static void mainBFS()
        {
            char[,] Map = readtxt("C:\\Users\\Acer\\Downloads\\tubes2 stima\\test\\Map1.txt");

            Console.WriteLine("Treasure Hunt With BFS");
            Console.WriteLine();
            char[,] MazeBFS = mazeWithBorder(Map);  // maze dengan border untuk perhitungan
            int nTreasure = CountTreasure(MazeBFS);
            Tuple<int, int> StartBFS = findStart(MazeBFS);
            List<Tuple<int, int>> PathBFS = GetAllTrasureBFS(MazeBFS, nTreasure, StartBFS);
            int nNodeBFS = nodeBFS.Count;
            int nStepsBFS = PathBFS.Count;
            string directionDFS = Direction(PathBFS);
            char[,] newMazeBFS = printPathMaze(Map, PathBFS, StartBFS, treasure);    //print maze

            Console.WriteLine(" ");
            Console.WriteLine("Banyak Node yang pernah dikunjungi : " + nNodeBFS);
            foreach (var item in nodeBFS)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Banyak steps : " + nStepsBFS);
            foreach (var item in PathBFS)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Direction : " + directionDFS);
            Console.WriteLine(" ");
        }
    }
}