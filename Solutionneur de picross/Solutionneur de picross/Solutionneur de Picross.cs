using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solutionneur_de_picross
{
    public partial class Form1 : Form //Phase 1
    {
        //Création des variables
        NumericUpDown horizontalSize = new NumericUpDown();
        NumericUpDown verticalSize = new NumericUpDown();
        Label sayHorizontalSize = new Label();
        Label sayVerticalSize = new Label();
        Button sizeSetted = new Button();

        public Form1()
        {
            InitializeComponent();
            //Assignation de la taille
            horizontalSize.Size = new Size(50, 20);
            verticalSize.Size = new Size(50, 20);
            sayHorizontalSize.Size = new Size(140, 20);
            sayVerticalSize.Size = new Size(140, 20);
            sizeSetted.Size = new Size(185, 20);

            //Assignation de la position
            horizontalSize.Location = new Point(135, 0);
            verticalSize.Location = new Point(135, 20);
            sayHorizontalSize.Location = new Point(0, 0);
            sayVerticalSize.Location = new Point(11, 20);
            sizeSetted.Location = new Point(0, 40);

            //Assignation du texte à afficher
            sayHorizontalSize.Text = "Taille horizontale de la grille";
            sayVerticalSize.Text = "Taille verticale de la grille";
            sizeSetted.Text = "Taille entrée";

            //Assignation d'une taille plus appropriée au programme dans son état initial
            Size = new Size(201, 100);

            //Assignation des intéractions spéciales
            sizeSetted.Click += SizeSetted_Click;

            //Assignation des valeurs maximales (Bug déclaré #1)
            horizontalSize.Maximum = 45;
            verticalSize.Maximum = 45;
            horizontalSize.Minimum = 1;
            verticalSize.Minimum = 1;


            //Création des composantes
            Controls.Add(horizontalSize);
            Controls.Add(verticalSize);
            Controls.Add(sayHorizontalSize);
            Controls.Add(sayVerticalSize);
            Controls.Add(sizeSetted);
        }

        private void SizeSetted_Click(object sender, EventArgs e) //Phase 2
        {
            //On cache les composantes pour entrer en phase 2
            Controls.Remove(horizontalSize);
            Controls.Remove(verticalSize);
            Controls.Remove(sayHorizontalSize);
            Controls.Remove(sayVerticalSize);
            Controls.Remove(sizeSetted);

            //On ajuste la taille de l'application
            Size = new Size(118 + (int)horizontalSize.Value * 22, 141 + (int)verticalSize.Value * 22);

            //On crée la grille
            Label[,] grille = new Label[(int)horizontalSize.Value, (int)verticalSize.Value];
            TextBox[] columns = new TextBox[(int)horizontalSize.Value];
            TextBox[] rows = new TextBox[(int)verticalSize.Value];
            Label bg = new Label();
            Button grilleEntree = new Button();
            for (int y = 0; y < (int)verticalSize.Value; y++)
            {
                for (int x = 0; x < (int)horizontalSize.Value; x++)
                {
                    grille[x, y] = new Label();
                    grille[x, y].BackColor = Color.White;
                    grille[x, y].Size = new Size(18, 18);
                    grille[x, y].Location = new Point(x * 20 + 102, y * 20 + 102);
                    Controls.Add(grille[x, y]);
                }
            }
            for (int x = 0; x < (int)horizontalSize.Value; x++)
            {
                columns[x] = new TextBox();
                columns[x].Multiline = true;
                columns[x].Size = new Size(20, 100);
                columns[x].Location = new Point(x * 20 + 101, 0);
                columns[x].TextAlign = HorizontalAlignment.Center;
                Controls.Add(columns[x]);
            }
            for (int y = 0; y < (int)verticalSize.Value; y++)
            {
                rows[y] = new TextBox();
                rows[y].Multiline = true;
                rows[y].Size = new Size(100, 20);
                rows[y].Location = new Point(0, y * 20 + 101);
                rows[y].TextAlign = HorizontalAlignment.Right;
                Controls.Add(rows[y]);
            }

            bg.Size = new Size((int)horizontalSize.Value * 20 + 2, (int)verticalSize.Value * 20 + 2);
            grilleEntree.Size = new Size(101, 101);

            bg.Location = new Point(100, 100);
            grilleEntree.Location = new Point(-1, -1);

            bg.BackColor = Color.Black;

            grilleEntree.Text = "Grille entrée";

            grilleEntree.Click += GrilleEntree_Click;

            Controls.Add(bg);
            Controls.Add(grilleEntree);

            void GrilleEntree_Click(object sender, EventArgs e) //Phase 3
            {
                /*
                 * Ordre de la résolution (N'est peut-être pas la meilleure / optimale, c'est juste pour la compréhension du code)
                 * (Certaines fonctions seront dans une boucle do while alors que d'autres ne le seront pas; les fonctions étant
                 *  hors de cette boucle vont ASSURÉMENT fonctionner qu'UNE SEULE FOIS car en aucun cas, la possibilité de
                 *  résolution en suivant la dite règle va se présenter plus tard dans l'exécution si cette possibilité n'était pas
                 *  présente dès le début)
                 * 1- Règle de la ligne pleine: Si une des valeurs est égale à la taille de sa rangée/colonne, remplir
                 *    automatiquement cette dernière
                 * 2- Règle de la ligne vide: Si une rangée/colonne a comme valeur seulement un '0', mettre les marqueurs
                 *    d'espaces sur toute la rangée
                 * 3- Règle de la moitié: Si une des valeurs est supérieure ou égale à la moitié de la taille de la rangée/colonne 
                 *    arrondi vers le haut / + 1 (donc à partir de 8 pour une taille de 14 ou 15), ajouter des cases au centre selon
                 *    la valeur (à chaque +1 par rapport à la moitié, ajouter une case de chaque côté en partant du centre
                 * 4- Règle du cumul: Lorsque l'addition des valeurs entrées pour la rangée/colonne ainsi que les espaces
                 *    nécessitent toute la rangée, elle peut être automatiquement résolue sans se poser de questions
                 * 5- Règle des cases obligatoires: Lorsque l'addition des valeurs entrées ainsi que les espaces laisse un nombre
                 *    de cases "amovibles" inférieure à une ou des valeurs entrées, il est possible de situer certaines de ces
                 *    cases en vérifiant quelles cases sont valides dans tous les cas (Tester si toutes les valeurs sont à une
                 *    extrémité puis à l'autre et voir quelles cases sont présentes dans les deux cas ?)
                 * 6- Règle des murs: Lorsqu'une zone rencontre un mur (par exemple, lorsqu'une zone de 2 commence collée contre
                 *    un espace), elle va obligatoirement dans une direction (vu que l'autre a été bouchée) donc on peut rentrer
                 *    les cases directement dans la grille
                 * 7- Règle de la portée individuelle: Quand il n'y a qu'une valeur dans la rangée/colonne et qu'au moins une case
                 *    a été trouvée pour cette rangée/colonne, on peut déterminer quelles cases seront obligatoirement des espaces
                 *    en prenant en compte les cases impossibles à atteindre dans la portée de la valeur (par exemple, si une
                 *    valeur 3 est située en plein milieu de sa rangée en position 4, il est impossible que les cases 1 et 7 soient
                 *    prises pour le 3 car elles sont hors de portées)
                 * 8- Règle des entrées trop grandes: Lorsque l'on a un espace trop petit pour une valeur (par exemple, un espace
                 *    de 1 pour une série de 2) et que cette valeur est obligatoirement à cette endroit dans la rangée/colonne
                 *    (première ou dernière valeur en sont de simples exemples), on peut automatiquement placer des espaces dans
                 *    ces zones trop petites
                 * 9- 
                 */
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
