using System;

namespace Solutionneur_de_sudoku.Sous_fonctions
{
    public partial class Grille
    {
        internal Case[,] casesDeSudoku = new Case[9, 9];
        internal bool modification = false;
        internal bool grilleResolue = false;
        internal void valeursEntrees(object sender, EventArgs e)
        {
            CasesInitiales(this);
            while (modification || !grilleResolue)
            {
                modification = false;
                for (int j = 0; j <= 8; j++)
                {
                    for (int i = 0; i <= 8; i++)
                    {
                        if (!casesDeSudoku[i, j].isSolved)
                        {
                            casesDeSudoku[i, j].Detection(this, i, j);
                        }
                    }
                }
                for (int j = 0; j <= 8; j++)
                {
                    for (int i = 0; i <= 8; i++)
                    {
                        if (!casesDeSudoku[i, j].isSolved)
                        {
                            casesDeSudoku[i, j].Resolution(this, i, j);
                        }
                    }
                }
                grilleResolue = true;
                for (int j = 0; j <= 8; j++)
                {
                    for (int i = 0; i <= 0; i++)
                    {
                        if (!casesDeSudoku[i, j].isSolved)
                        {
                            grilleResolue = false;
                        }
                    }
                }
            }
        }

    }
}
