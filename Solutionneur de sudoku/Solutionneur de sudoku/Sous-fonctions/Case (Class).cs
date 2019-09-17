using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Solutionneur_de_sudoku.Sous_fonctions
{
    public class Case : Button
    {
        bool isSolved = false;
        List<int> possibleValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        internal int value = 0;
        internal void addValue(object sender, EventArgs e)
        {
            value += 1;
            Text = value.ToString();
        }
        internal void valueFound(int value)
        {
            for(int valueI = 1; valueI < 10; valueI++)
            {
                if (value != valueI && possibleValues.Contains(valueI))
                {
                    possibleValues.Remove(valueI);
                }
            }
            isSolved = true;
        }
        internal Case()
        {
            ForeColor = Color.Black;
            BackColor = Color.White;
            FlatStyle = new FlatStyle();
            Text = value.ToString();
        }
    }
}
