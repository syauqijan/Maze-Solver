using System;
using System.Collections.Generic;
using System.Linq;
using static Map.Maze;
namespace MazeWithDFS
{
    class DFS
    {
        public static Stack<Tuple<int, int>> nodeDFS = new Stack<Tuple<int, int>>();

        static IDictionary<Tuple<int, int>, Tuple<int, int>> DFSMaze(char[,] Matrix, Tuple<int, int> start)
        {
            IDictionary<Tuple<int, int>, Tuple<int, int>> tempPath = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            Tuple<int, int> neighbor = Tuple.Create(0, 0);

            stack.Push(start);
            tempPath.Add(start, (Tuple.Create(-1, -1)));
            while (stack.Count > 0)
            {
                Tuple<int, int> current = stack.Pop();
                if (!nodeDFS.Contains(current))
                {
                    nodeDFS.Push(current);
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
                            stack.Push(neighbor);
                            tempPath.Add(neighbor, current);
                        }
                    }
                    else if (item == 'D')
                    {
                        neighbor = Tuple.Create(current.Item1 + 1, current.Item2);
                        if (!tempPath.ContainsKey(neighbor))
                        {
                            stack.Push(neighbor);
                            tempPath.Add(neighbor, current);
                        }
                    }
                    else if (item == 'U')
                    {
                        neighbor = Tuple.Create(current.Item1 - 1, current.Item2);
                        if (!tempPath.ContainsKey(neighbor))
                        {
                            stack.Push(neighbor);
                            tempPath.Add(neighbor, current);
                        }
                    }
                    else if (item == 'L')
                    {
                        neighbor = Tuple.Create(current.Item1, current.Item2 - 1);
                        if (!tempPath.ContainsKey(neighbor))
                        {
                            stack.Push(neighbor);
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
        }

        public static List<Tuple<int, int>> GetAllTrasureDFS(char[,] Matrix, int treasure, Tuple<int, int> start)
        {
            List<IDictionary<Tuple<int, int>, Tuple<int, int>>> path = new List<IDictionary<Tuple<int, int>, Tuple<int, int>>>();
            List<Tuple<int, int>> FinalPath = new List<Tuple<int, int>>();
            IDictionary<Tuple<int, int>, Tuple<int, int>> tempPath = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            Tuple<int, int> tempStart = Tuple.Create(0, 0);
            Tuple<int, int> tempNextStart = Tuple.Create(0, 0);

            if (treasure == 1)
            {
                tempPath = DFSMaze(Matrix, start);
                path.Add(tempPath);
            }
            else
            {
                for (int i = 0; i < treasure; i++)
                {
                    tempPath = DFSMaze(Matrix, start);
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

        public static void mainDFS()
        {   
            
            char[,] Map = readtxt("C:\\Users\\Acer\\Downloads\\tubes2 stima\\test\\Map1.txt");

            Console.WriteLine("Treasure Hunt With DFS");
            Console.WriteLine();
            char[,] MazeDFS = mazeWithBorder(Map);  // maze dengan border untuk perhitungan
            int nTreasure = CountTreasure(MazeDFS); //jumlah treasure
            Tuple<int, int> StartDFS = findStart(MazeDFS);  //posisi start
            List<Tuple<int, int>> PathDFS = GetAllTrasureDFS(MazeDFS, nTreasure, StartDFS); //path
            int nNodeDFS = nodeDFS.Count;   //banyak node yang pernah dikunjungi
            int nStepsDFS = PathDFS.Count;  //banyak steps
            string directionDFS = Direction(PathDFS);   //arah R-D-U-L
            char[,] newMazeDFS = printPathMaze(Map, PathDFS, StartDFS, treasure);    //print maze

            Console.WriteLine(" ");
            Console.WriteLine("Banyak Node yang pernah dikunjungi : " + nNodeDFS);
            foreach (var item in nodeDFS)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Banyak steps : " + nStepsDFS);
            foreach (var item in PathDFS)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Direction : " + directionDFS);
            Console.WriteLine(" ");
        }
    }
}