﻿using System.Drawing;

namespace Solutionneur_de_sudoku.Sous_fonctions
{

    public partial class Grille
    {
        internal Grille CasesInitiales(Grille grille)
        {
            for (int j = 0; j <= 8; j++)
            {
                for (int i = 0; i <= 8; i++)
                {
                    if (grille.casesDeSudoku[i, j].value != 0)
                    {
                        casesDeSudoku[i, j].valueFound(casesDeSudoku[i, j].value);
                        grille.casesDeSudoku[i, j].gridEntered = true;
                        casesDeSudoku[i, j].Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (0));
                    }
                }
            }
            return grille;
        }
    }

}