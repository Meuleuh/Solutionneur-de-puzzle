using System;
using System.Collections.Generic;

namespace Solutionneur_de_sudoku.Sous_fonctions
{
    public partial class Case
    {
        internal Grille Detection(Grille grille, int i, int j)
        {
            rowDetection(grille, i, j);
            columnDetection(grille, i, j);
            houseDetection(grille, i, j);
            return grille;
        }

        internal Grille rowDetection(Grille grille, int i, int j)
        {
            for (int k = 0; k <= 8; k++)
            {
                if (grille.casesDeSudoku[k, j].isSolved && (k != i) && possibleValues.Contains(grille.casesDeSudoku[k, j].value))
                {
                    possibleValues.Remove(grille.casesDeSudoku[k, j].value);
                    grille.modification = true;
                }
            }
            return grille;
        }

        internal Grille columnDetection(Grille grille, int i, int j)
        {
            for (int k = 0; k <= 8; k++)
            {
                if (grille.casesDeSudoku[i, k].isSolved && (k != j) && possibleValues.Contains(grille.casesDeSudoku[i, k].value))
                {
                    possibleValues.Remove(grille.casesDeSudoku[i, k].value);
                    grille.modification = true;
                }
            }
            return grille;
        }

        internal Grille houseDetection(Grille grille, int i, int j)
        {
            int[] house = new int[]
            {
                3*(i/3),       // MinH 0 ~ 1 ~ 2 = 0 | 3 ~ 4 ~ 5 = 3 | 6 ~ 7 ~ 8 = 6
                3*(1+(i/3))-1, // MaxH 0 ~ 1 ~ 2 = 2 | 3 ~ 4 ~ 5 = 5 | 6 ~ 7 ~ 8 = 8
                3*(j/3),       // MinV 0 ~ 1 ~ 2 = 0 | 3 ~ 4 ~ 5 = 3 | 6 ~ 7 ~ 8 = 6
                3*(1+(j/3))-1  // MaxV 0 ~ 1 ~ 2 = 2 | 3 ~ 4 ~ 5 = 5 | 6 ~ 7 ~ 8 = 8
            };

            for (int l = house[0]; l <= house[1]; l++)
            {
                for (int k = house[2]; k <= house[3]; k++)
                {
                    if (grille.casesDeSudoku[k, l].isSolved && ((k != i) || (l != j)) && possibleValues.Contains(grille.casesDeSudoku[k, l].value))
                    {
                        possibleValues.Remove(grille.casesDeSudoku[k, l].value);
                        grille.modification = true;
                    }
                }
            }
            return grille;
        }
    }
}