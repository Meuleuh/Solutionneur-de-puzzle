using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Solutionneur_de_sudoku.Sous_fonctions
{
    public partial class Case : Button
    {
        internal bool isSolved = false;
        List<int> possibleValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        internal int value = 0;
        internal bool gridEntered = false;
        internal void addValue(object sender, EventArgs e)
        {
            if (!gridEntered)
            {
                if (value < 9)
                {
                    value += 1;
                }
                else
                {
                    value = 0;
                }
                Text = value.ToString();
            }

        }
        internal void valueFound(int value)
        {
            this.value = value;
            for (int valueI = 1; valueI <= 9; valueI++)
            {
                if (value != valueI && possibleValues.Contains(valueI))
                {
                    possibleValues.Remove(valueI);
                }
            }
            isSolved = true;
            Text = value.ToString();
        }
        internal Case()
        {
            ForeColor = Color.Black;
            BackColor = Color.White;
            FlatStyle = new FlatStyle();
            Text = value.ToString();
            FlatAppearance.BorderColor = Color.White;
        }
    }
}
