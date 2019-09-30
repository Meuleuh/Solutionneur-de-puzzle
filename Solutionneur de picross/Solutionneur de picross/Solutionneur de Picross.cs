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
    public partial class Form1 : Form
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

        private void SizeSetted_Click(object sender, EventArgs e)
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
            bg.Size = new Size((int)horizontalSize.Value * 20+2, (int)verticalSize.Value * 20+2);
            bg.Location = new Point(100, 100);
            bg.BackColor = Color.Black;
            Controls.Add(bg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
