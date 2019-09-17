using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Solutionneur_de_sudoku
{
    public partial class Form1 : Form
    {
        Sous_fonctions.Case[,] casesDeSudoku = new Sous_fonctions.Case[9, 9];
        public Form1()
        {
            int hPos = 3;
            int vPos = 3;
            InitializeComponent();
            for (int j = 0; j <= 8; j++)
            {
                hPos = 3;
                for (int i = 0; i <= 8; i++)
                {
                    casesDeSudoku[i, j] = new Sous_fonctions.Case();
                    casesDeSudoku[i, j].Size = new Size(30, 30);
                    casesDeSudoku[i, j].Location = new Point(hPos, vPos);
                    casesDeSudoku[i, j].FlatAppearance.BorderColor = Color.White;
                    casesDeSudoku[i, j].Click += casesDeSudoku[i, j].addValue;

                    /*
                     * À mettre pour les cases dont la valeur a été définie dès le début
                     * casesDeSudoku[i, j].Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point,(0));
                    */

                    Controls.Add(casesDeSudoku[i, j]);
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
}
