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
        public Form1()
        {
            InitializeComponent();
            //Assignation d'une taille plus appropriée au programme dans son état initial
            Size = new Size(201, 100);

            //Création des variables
            NumericUpDown horizontalSize = new NumericUpDown();
            NumericUpDown verticalSize = new NumericUpDown();
            Label sayHorizontalSize = new Label();
            Label sayVerticalSize = new Label();
            Button sizeSetted = new Button();

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

            //Création des composantes
            Controls.Add(horizontalSize);
            Controls.Add(verticalSize);
            Controls.Add(sayHorizontalSize);
            Controls.Add(sayVerticalSize);
            Controls.Add(sizeSetted);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
