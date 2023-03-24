using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Map
{
    class Maze
    {
        public static List<Tuple<int, int>> treasure = new List<Tuple<int, int>>();
        public static char[,] readtxt(string path)
        {
            string filename = path;
            string[] data = File.ReadAllLines(filename);
            int baris = data.Length;
            int kolom = data[0].Split(' ').Length;

            char[,] hasil = new char[data.Length, kolom];

            for (int w = 0; w < data.Length; w++)
            {
                for (int x = 0; x < kolom; x++)
                {
                    hasil[w, x] = data[w][x * 2];
                }
            }
            return hasil;
        }

        public static char[,] mazeWithBorder(char[,] Matrix)
        {
            char[,] temp = new char[Matrix.GetLength(0) + 2, Matrix.GetLength(1) + 2];
            for (int i = 1; i <= Matrix.GetLength(0); i++)
            {
                for (int j = 1; j <= Matrix.GetLength(1); j++)
                {
                    temp[i, j] = Matrix[i - 1, j - 1];
                }
            }
            int nRow = Matrix.GetLength(0);
            int nCol = Matrix.GetLength(1);
            for (int i = 0; i <= nRow + 1; i++)
            {
                temp[i, 0] = 'X';
                temp[i, nCol + 1] = 'X';
            }
            for (int i = 0; i <= nCol + 1; i++)
            {
                temp[0, i] = 'X';
                temp[nRow + 1, i] = 'X';
            }
            return temp;
        }

        public static int CountTreasure(char[,] Matrix)
        {
            int nRow = Matrix.GetLength(0);
            int nCol = Matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    if (Matrix[i, j] == 'T')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static Tuple<int, int> findStart(char[,] Matrix)
        {
            Tuple<int, int> start = Tuple.Create(0, 0);
            int nRow = Matrix.GetLength(0);
            int nCol = Matrix.GetLength(1);
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    if (Matrix[i, j] == 'K')
                    {
                        start = Tuple.Create(i, j);
                        return start;
                    }
                }
            }
            return start;
        }


        public static List<char> findNeighbor(Tuple<int, int> current, char[,] Matrix)
        {
            List<char> neighbor = new List<char>();
            if (Matrix[current.Item1, current.Item2 + 1] == 'R' || Matrix[current.Item1, current.Item2 + 1] == 'T')
            {
                neighbor.Add('R');
            }
            else
            {
                neighbor.Add(' ');
            }
            if (Matrix[current.Item1 + 1, current.Item2] == 'R' || Matrix[current.Item1 + 1, current.Item2] == 'T')
            {
                neighbor.Add('D');
            }
            else
            {
                neighbor.Add(' ');
            }
            if (Matrix[current.Item1 - 1, current.Item2] == 'R' || Matrix[current.Item1 - 1, current.Item2] == 'T')
            {
                neighbor.Add('U');
            }
            else
            {
                neighbor.Add(' ');
            }
            if (Matrix[current.Item1, current.Item2 - 1] == 'R' || Matrix[current.Item1, current.Item2 - 1] == 'T')
            {
                neighbor.Add('L');
            }
            else
            {
                neighbor.Add(' ');
            }
            return neighbor;
        }

        public static IDictionary<Tuple<int, int>, Tuple<int, int>> deleteBacktrack(IDictionary<Tuple<int, int>, Tuple<int, int>> path, char[,] Matrix)
        {
            IDictionary<Tuple<int, int>, Tuple<int, int>> newPath = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            Tuple<int, int> current = path.ElementAt(path.Count - 1).Value;
            newPath.Add(path.ElementAt(path.Count - 1).Key, path.ElementAt(path.Count - 1).Value);
            int i = path.Count - 1;
            while (current != path.ElementAt(0).Value)
            {
                if (current == path.ElementAt(i - 1).Key)
                {
                    current = path.ElementAt(i - 1).Value;
                    newPath.Add(path.ElementAt(i - 1).Key, path.ElementAt(i - 1).Value);
                }
                i--;
            }
            IDictionary<Tuple<int, int>, Tuple<int, int>> realPath = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            for (int j = newPath.Count - 1; j >= 0; j--)
            {
                realPath.Add(newPath.ElementAt(j).Key, newPath.ElementAt(j).Value);
            }
            return realPath;
        }

        public static string Direction(List<Tuple<int, int>> path)
        {
            // R - D - U - L
            string direction = "";
            int str = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                if (path[i].Item1 == path[i + 1].Item1)
                {
                    if (path[i].Item2 < path[i + 1].Item2)
                    {
                        direction += "R";
                    }
                    else
                    {
                        direction += "L";
                    }
                }
                else
                {
                    if (path[i].Item1 < path[i + 1].Item1)
                    {
                        direction += "D";
                    }
                    else
                    {
                        direction += "U";
                    }
                }
                if (str < path.Count - 2)
                {
                    direction += " - ";
                }
                else
                {
                    direction += "";
                }
                str++;
            }
            return direction;
        }

        public static char[,] printPathMaze(char[,] Matrix, List<Tuple<int, int>> PathDFS, Tuple<int, int> Start, List<Tuple<int, int>> treasure)
        {
            int nRow = Matrix.GetLength(0);
            int nCol = Matrix.GetLength(1);
            char[,] temp = new char[nRow, nCol];
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    temp[i, j] = Matrix[i, j];
                }
            }
            for (int i = 0; i < PathDFS.Count; i++)
            {
                temp[(PathDFS[i].Item1 - 1), (PathDFS[i].Item2 - 1)] = 'L';
            }
            for (int i = 0; i < treasure.Count; i++)
            {
                temp[(treasure[i].Item1 - 1), (treasure[i].Item2 - 1)] = 'T';
            }
            temp[(Start.Item1 - 1), (Start.Item2 - 1)] = 'K';
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    Console.Write(" " + temp[i, j] + " ");
                }
                Console.WriteLine();
            }
            return temp;
        }
    }
}