using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solutionneur_de_sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            int hPos = 3;
            int vPos = 3;
            InitializeComponent();
            Case[,] casesDeSudoku = new Case[9, 9];
            for (int j = 0; j <= 8; j++)
            {
                hPos = 3;
                for (int i = 0; i <= 8; i++)
                {
                    casesDeSudoku[i, j] = new Case();
                    casesDeSudoku[i, j].Size = new Size(30, 30);
                    casesDeSudoku[i, j].Location = new Point(hPos, vPos);
                    casesDeSudoku[i, j].ForeColor = Color.White;
                    casesDeSudoku[i, j].BackColor = Color.White;
                    casesDeSudoku[i, j].FlatStyle = new FlatStyle();
                    this.Controls.Add(casesDeSudoku[i, j]);
                    if (i == 2 || i == 5)
                    {
                        hPos += 33;
                    }
                    else
                    {
                        hPos += 31;
                    }
                }
                if (j == 2 || j == 5)
                {
                    vPos += 33;
                }
                else
                {
                    vPos += 31;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    class Case : Button
    {
        bool isSolved = false;
        int[] possibleValues = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int value = 0;
    }
}
