using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static MazeWithBFS.BFS;
using static MazeWithDFS.DFS;
using static Map.Maze;
using MazeWithBFS;

namespace TESTING
{
    public partial class Form1 : Form
    {
        public string filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = "Input";
            label.Location = new Point(10, 10);
            label.AutoSize = true;
            this.Controls.Add(label);


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void DisplayMaze(string filePath)
        {
            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] cells = line.Split(' ');
                    rows.Add(cells);
                }
            }

            int numRows = rows.Count;
            int numCols = rows[0].Length;

            dataGridView1.ClearSelection();
            dataGridView1.ColumnCount = numCols;
            dataGridView1.RowCount = numRows;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            int lebarSel = dataGridView1.Width / dataGridView1.Columns.Count;
            int tinggiSel = dataGridView1.Height / dataGridView1.Rows.Count;
            for(int i= 0; i<dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Height = tinggiSel;
            }

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    string cellValue = rows[row][col];
                    if (cellValue == "K")
                    {
                        dataGridView1[col, row].Style.BackColor = Color.Yellow;
                        dataGridView1[col, row].Value = "Start";
                    }
                    else if (cellValue == "T")
                    {
                        dataGridView1[col, row].Style.BackColor = Color.Green;
                        dataGridView1[col, row].Value = "Treasure";
                    }
                    else if (cellValue == "R")
                    {
                        dataGridView1[col, row].Style.BackColor = Color.White;
                    }
                    else if (cellValue == "X")
                    {
                        dataGridView1[col, row].Style.BackColor = Color.Black;
                    }

                }
            }
            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.Title = "Select a Text File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                textBox1.Text = fileName;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                DisplayMaze(filePath);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
     

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   
            if (radioButton1.Checked)
            {
                char[,] Map = readtxt(filePath);

                Console.WriteLine("Treasure Hunt With BFS");
                Console.WriteLine();
                char[,] MazeBFS = mazeWithBorder(Map);  // maze dengan border untuk perhitungan
                int nTreasure = CountTreasure(MazeBFS);
                Tuple<int, int> StartBFS = findStart(MazeBFS);
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                List<Tuple<int, int>> PathBFS = GetAllTrasureBFS(MazeBFS, nTreasure, StartBFS);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                int nNodeBFS = nodeBFS.Count;
                int nStepsBFS = PathBFS.Count;
                string directionDFS = Direction(PathBFS);
                char[,] newMazeBFS = printPathMaze(Map, PathBFS, StartBFS, treasure);    //print maze

                textBox2.Text = nNodeBFS.ToString();
                textBox3.Text = directionDFS;
                textBox4.Text = nStepsBFS.ToString();
                textBox5.Text = elapsedMs.ToString() + "ms";


                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                dataGridView1.ReadOnly = true;

                dataGridView1.ColumnCount = Map.GetLength(1);
                dataGridView1.RowCount = Map.GetLength(0);

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (newMazeBFS[i, j] == 'X')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        }
                        else if (newMazeBFS[i, j] == 'L')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                        }

                        else if (newMazeBFS[i, j] == 'T')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                            dataGridView1.Rows[i].Cells[j].Value = "Treasure";

                        }

                        else if (newMazeBFS[i, j] == 'K')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                            dataGridView1.Rows[i].Cells[j].Value = "Start";

                        }
                        else if (newMazeBFS[i, j] == 'R')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        }
                    }
                }
                dataGridView1.ClearSelection();
            }
            else if (radioButton2.Checked)
            {
                char[,] Map = readtxt(filePath);

                Console.WriteLine("Treasure Hunt With DFS");
                Console.WriteLine();
                char[,] MazeDFS = mazeWithBorder(Map);  // maze dengan border untuk perhitungan
                int nTreasure = CountTreasure(MazeDFS); //jumlah treasure
                Tuple<int, int> StartDFS = findStart(MazeDFS);  //posisi start
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                List<Tuple<int, int>> PathDFS = GetAllTrasureDFS(MazeDFS, nTreasure, StartDFS); //path
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                int nNodeDFS = nodeDFS.Count;   //banyak node yang pernah dikunjungi
                int nStepsDFS = PathDFS.Count;  //banyak steps
                string directionDFS = Direction(PathDFS);   //arah R-D-U-L
                char[,] newMazeDFS = printPathMaze(Map, PathDFS, StartDFS, treasure);    //print maze

                textBox2.Text = nNodeDFS.ToString();
                textBox3.Text = directionDFS;
                textBox4.Text = nStepsDFS.ToString();
                textBox5.Text = elapsedMs.ToString() + "ms";

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                dataGridView1.ReadOnly = true;


                dataGridView1.ColumnCount = Map.GetLength(1);
                dataGridView1.RowCount = Map.GetLength(0);

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (newMazeDFS[i, j] == 'X')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        }
                        else if (newMazeDFS[i, j] == 'L')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                        }

                        else if (newMazeDFS[i, j] == 'T')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                            dataGridView1.Rows[i].Cells[j].Value = "Treasure";

                        }

                        else if (newMazeDFS[i, j] == 'K')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                            dataGridView1.Rows[i].Cells[j].Value = "Start";

                        }
                        else if (newMazeDFS[i, j] == 'R')
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        }
                    }
                }
                dataGridView1.ClearSelection();





            }
            
        }
    }
}
