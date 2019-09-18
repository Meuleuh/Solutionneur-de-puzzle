using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutionneur_de_sudoku.Sous_fonctions
{
    public partial class Grille
    {
        internal Case[,] casesDeSudoku = new Case[9, 9];
        bool caseResolue = true;
        bool grilleResolue = false;
        internal void valeursEntrees(object sender, EventArgs e)
        {
            CasesInitiales(this);

            while (caseResolue || !grilleResolue)
            {
                 
            }
        }

    }
}
