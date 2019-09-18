using System;

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
            return grille;
        }
    }
}