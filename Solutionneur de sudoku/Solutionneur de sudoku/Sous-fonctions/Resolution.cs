namespace Solutionneur_de_sudoku.Sous_fonctions
{
    public partial class Case
    {
        internal Grille Resolution(Grille grille, int i, int j)
        {
            autoResolution(grille, i, j);
            if (!grille.modification)
            {
                rowResolution(grille, i, j);
                if (!grille.modification)
                {
                    columnResolution(grille, i, j);
                    if (!grille.modification)
                    {
                        houseResolution(grille, i, j);
                    }
                }
            }
            return grille;
        }

        internal Grille autoResolution(Grille grille, int i, int j)
        {
            grille.modification = false;
            if (possibleValues.Count == 1)
            {
                valueFound(possibleValues[0]);
                grille.modification = true;
            }
            return grille;
        }

        internal Grille rowResolution(Grille grille, int i, int j)
        {
            bool notTheAnswer = false;
            for (int valueI = 1; valueI <= 9; valueI++)
            {
                for (int k = 0; k <= 8; k++)
                {
                    if (k != i)
                    {
                        notTheAnswer = !(possibleValues.Contains(valueI) && !grille.casesDeSudoku[k, j].possibleValues.Contains(valueI));
                    }
                }
                if (!notTheAnswer)
                {
                    valueFound(valueI);
                    grille.modification = true;
                    break;
                }
            }
            return grille;
        }

        internal Grille columnResolution(Grille grille, int i, int j)
        {
            bool notTheAnswer = false;
            for (int valueI = 1; valueI <= 9; valueI++)
            {
                for (int k = 0; k <= 8; k++)
                {
                    if (k != j)
                    {
                        notTheAnswer = !(possibleValues.Contains(valueI) && !grille.casesDeSudoku[i, k].possibleValues.Contains(valueI));
                    }
                }
                if (!notTheAnswer)
                {
                    valueFound(valueI);
                    grille.modification = true;
                    break;
                }
            }
            return grille;
        }

        internal Grille houseResolution(Grille grille, int i, int j)
        {
            bool notTheAnswer = false;
            int[] house = new int[]
            {
                3*(i/3),       // MinH 0 ~ 1 ~ 2 = 0 | 3 ~ 4 ~ 5 = 3 | 6 ~ 7 ~ 8 = 6
                3*(1+(i/3))-1, // MaxH 0 ~ 1 ~ 2 = 2 | 3 ~ 4 ~ 5 = 5 | 6 ~ 7 ~ 8 = 8
                3*(j/3),       // MinV 0 ~ 1 ~ 2 = 0 | 3 ~ 4 ~ 5 = 3 | 6 ~ 7 ~ 8 = 6
                3*(1+(j/3))-1  // MaxV 0 ~ 1 ~ 2 = 2 | 3 ~ 4 ~ 5 = 5 | 6 ~ 7 ~ 8 = 8
            };

            for (int valueI = 1; valueI <= 9; valueI++)
            {
                for (int l = house[0]; l <= house[1]; l++)
                {
                    for (int k = house[2]; k <= house[3]; k++)
                    {
                        if (k != i && l != j)
                        {
                            notTheAnswer = !(possibleValues.Contains(valueI) && !grille.casesDeSudoku[k, l].possibleValues.Contains(valueI));
                        }
                    }
                    if (!notTheAnswer)
                    {
                        valueFound(valueI);
                        grille.modification = true;
                        break;
                    }
                }
            }

            return grille;
        }
    }
}