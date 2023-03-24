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
                    }
                    else if (cellValue == "T")
                    {
                        dataGridView1[col, row].Style.BackColor = Color.Green;
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

        }
    }
}
