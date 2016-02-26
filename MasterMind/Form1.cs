using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMind
{
    public class frmMasterMind : Form
    {
        private ColorClass cc;
		PictureBox[] pic;

        public frmMasterMind()
        {
            InitializeComponent();
           // cc = new ColorClass(Kleur.ROOD);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Settings = new frmSettings();
            Settings.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMasterMind_Load(object sender, EventArgs e)
        {
            PictureBoxesInladen(10);//jelle heeft 4 aangepast naar zes om autosize te testen, lijkt te werken
        }
       
        private void PictureBoxesInladen(int Aantal)
        {
            
            pic = new PictureBox[Aantal];
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i] = new PictureBox();
                pic[i].Left = 10 + 40 * i;
                pic[i].Top = 15;
                pic[i].Width = 30;
                pic[i].Height = 30;
                pic[i].Text = "test";
                pic[i].BackColor = Color.Blue;
                grpBeschikbareKleuren.Controls.Add(pic[i]);
				//jelle probeert even iets:
				grpBeschikbareKleuren.AutoSize = true;
				this.AutoSize = true; // zou afhankelijk moeten zijn van grpBeschikbareKleuren.AutoSize = true;   functietje?
                //grp moet nog auto sizen
                //kleuren moeten nog gegenereerd worden mbv functie
            }
        }

		private void btnTestJelle_Click(object sender, EventArgs e)//wa probeersels van jelle om op dit form rectangles dynamisch te laten genereren
		{
			Rectangle usrInput = new Rectangle();
			usrInput.Location = new Point(15, 120);
			usrInput.Width = 20;
			usrInput.Height = 20;
			//this.Controls.Add(this.);

			Button bt = new Button();
			//bt.Top = 20;
			//bt.Left = 20;
			bt.Location = new Point(50, 50);
			bt.Height = 15;
			bt.Text = "Button";
			//pnlMetRectangles.Controls.Add(bt);

			MessageBox.Show(Properties.Settings.Default.aantal.ToString());

		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			//Graphics g;
			//g = CreateGraphics();
			//Pen p;
			//Rectangle r;
			//p = new Pen(Brushes.Blue);
			//r = new Rectangle(100, 50, 75, 75);
			//g.DrawRectangle(p, r);

			/////////////////////////////

			int i = 1;
			pic[i] = new PictureBox();
			pic[i].Left = 10 + 40 * i;
			pic[i].Top = 15;
			pic[i].Width = 30;
			pic[i].Height = 30;
			pic[i].Text = "test";
			pic[i].BackColor = Color.Blue;
			panel1.Controls.Add(pic[i]);

			
			//grpBeschikbareKleuren.Controls.Add(pic[i]);

			MessageBox.Show(Properties.Settings.Default.aantal.ToString());
		
		}

    }
}
