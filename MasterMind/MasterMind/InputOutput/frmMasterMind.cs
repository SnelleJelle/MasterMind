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
    public partial class frmMasterMind : Form
	{
		
		/*=========================================================================*/
		//Toggle to show the secret code on the form
		bool ShowSecretCode = true;		 
		 /*========================================================================*/

		#region Public declarations

		PictureBox[] pictureBoxAvailableColors;
		PictureBox[,] pictureBoxGenerated;
		PictureBox[,] pictureBoxSolutions;
		PictureBox[] pbSecret;

		ColorClass cc = new ColorClass((int)Properties.Settings.Default.NrOfAvailableColors);

		ComputerSpeler CS = new ComputerSpeler();
		
		Randomiser rnd = new Randomiser();
		GroupBox grpSecretCode = new GroupBox();
		int[] SecretCode;


		#endregion


		#region Small handlers

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Settings = new frmSettings();
			Settings.FormClosed += new FormClosedEventHandler(SettingsClosed);
			Settings.ShowDialog();
		}

		private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			AboutOkBtn abt = new AboutOkBtn();
			abt.ShowDialog();
		}

		private void usageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Usage usg = new Usage();
			usg.ShowDialog();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion


		#region Refresh / Clear gui functions

		private void LoadOrReloadGUI()
		{
			cc.BeurtenNR = Properties.Settings.Default.NrOfAvailableColors;
            CS.AantalKleurenTeRaden = Properties.Settings.Default.NrOfAvailableColors;
			GeneratePicBoxAvailableColors();
			GeneratePicBoxColorGuess();
			SecretCode = rnd.GetRandomSequence(0, (int)Properties.Settings.Default.NrOfColors - 1, (int)Properties.Settings.Default.NrOfColors - 1);
			PictureBoxShowSecretCode();
			for (int kolom = (int)Properties.Settings.Default.NrOfColors - 1; kolom >= 0; kolom--)
			{
				pictureBoxGenerated[0, kolom].Enabled = true;
				pictureBoxGenerated[0, kolom].BackColor = Color.White;
			}
            if (Properties.Settings.Default.Computerguessing == true)
            {
              ComputerAi();  
            }

			//als laatste
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.AutoSize = true;

		}

		private void SettingsClosed(object sender, FormClosedEventArgs e)
		{
			LoadOrReloadGUI();
		}

		#endregion

		private void ComputerAi()
		{
			int Aantal = (int)Properties.Settings.Default.NrOfColors;
			ColorClass ComputerAi = new ColorClass(Aantal);
			CS.SpeelEenRonde();
			for (int i = 0; i < Aantal; i++)
			{
				pictureBoxGenerated[i, 0].BackColor = ComputerAi.GetColor((Kleur)CS.KleurenWaardes[i]);
			}
		}

		public frmMasterMind()
		{
			InitializeComponent();
		}

		private void frmMasterMind_Load(object sender, EventArgs e)
        {
			LoadOrReloadGUI();
        }


		#region PictureBox Arrays

		private void GeneratePicBoxAvailableColors()
		{
			grpAvailableColors.Controls.Clear();
			int Aantal = (int)Properties.Settings.Default.NrOfAvailableColors;
			pictureBoxAvailableColors = new PictureBox[Aantal];

			for (int i = 0; i < pictureBoxAvailableColors.Length; i++)
			{
				pictureBoxAvailableColors[i] = new PictureBox();
				pictureBoxAvailableColors[i].Left = 20 + 45 * i;
				pictureBoxAvailableColors[i].Top = 20;
				pictureBoxAvailableColors[i].Width = 30;
				pictureBoxAvailableColors[i].Height = 30;
				pictureBoxAvailableColors[i].BackColor = cc.GetNextColor();
				pictureBoxAvailableColors[i].BorderStyle = BorderStyle.Fixed3D;

				//dragdrop
				pictureBoxAvailableColors[i].MouseDown += new MouseEventHandler(picBox_MouseDown);
			
				grpAvailableColors.Controls.Add(pictureBoxAvailableColors[i]);

			}//end for
			grpAvailableColors.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			grpAvailableColors.AutoSize = true;
			grpAvailableColors.Show();
			this.AutoSize = true;

		}//GeneratePicBoxAvailableColors

		private void GeneratePicBoxColorGuess()//also moves btnTry
		{					
			int VerticalRows = ((int)Properties.Settings.Default.NrOfTurns);
			int HorizontalRows = ((int)Properties.Settings.Default.NrOfColors);

			pictureBoxGenerated = new PictureBox[VerticalRows, HorizontalRows];
			grpAantalRijen.Controls.Clear();

			for (int  rij = 0; rij < VerticalRows; rij++)
			{
				for (int kolom = 0; kolom < HorizontalRows; kolom++)
				{
					pictureBoxGenerated[rij, kolom] = new PictureBox();
					pictureBoxGenerated[rij, kolom].Left = 20 + 45 * kolom;
					pictureBoxGenerated[rij, kolom].Top = 30 + rij * 38;
					pictureBoxGenerated[rij, kolom].Width = 30;
					pictureBoxGenerated[rij, kolom].Height = 30;
					pictureBoxGenerated[rij, kolom].BackColor = Color.DarkGray;
					pictureBoxGenerated[rij, kolom].BorderStyle = BorderStyle.Fixed3D;
					pictureBoxGenerated[rij, kolom].Enabled = false;
					pictureBoxGenerated[rij, kolom].BackColor = Color.LightGray;

					//Groupbox
					grpAantalRijen.Controls.Add(pictureBoxGenerated[rij, kolom]);
					//MessageBox.Show("t");

					//Dragdrop
					pictureBoxGenerated[rij, kolom].DragDrop += new DragEventHandler(picBox_DragDrop);
					pictureBoxGenerated[rij, kolom].DragEnter += new DragEventHandler(picBox_DragEnter);
					pictureBoxGenerated[rij, kolom].AllowDrop = true;

				}//end for			
			}//end for

			grpAantalRijen.AllowDrop = true;
			grpAantalRijen.Location = new Point(13, grpAvailableColors.Bottom + 5);

			GeneratePicBoxColorGuessCheck();
			grpAantalRijen.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			grpAantalRijen.AutoSize = true;

			//move btnTry
			int x = grpAantalRijen.Right + 5;
			int y = grpAantalRijen.Top + pictureBoxGenerated[0, 0].Location.Y;			
			btnTry.Location = new Point(x, y);

		}//GeneratePicBoxColorGuess

		private void GeneratePicBoxColorGuessCheck()
		{
			int VerticalRows = ((int)Properties.Settings.Default.NrOfTurns);
			int HorizontalRows = ((int)Properties.Settings.Default.NrOfColors);

			pictureBoxSolutions = new PictureBox[VerticalRows, HorizontalRows];
			

			for (int rij = 0; rij < VerticalRows; rij++)
			{
				for (int kolom = 0; kolom < HorizontalRows; kolom++)
				{
					pictureBoxSolutions[rij, kolom] = new PictureBox();
					pictureBoxSolutions[rij, kolom].Left = 50 * HorizontalRows + 20 * kolom;
					pictureBoxSolutions[rij, kolom].Top = 38 + rij * 38;
					pictureBoxSolutions[rij, kolom].Width = 10;
					pictureBoxSolutions[rij, kolom].Height = 10;
					pictureBoxSolutions[rij, kolom].BackColor = Color.Transparent;
					pictureBoxSolutions[rij, kolom].BorderStyle = BorderStyle.Fixed3D;
					pictureBoxSolutions[rij, kolom].Enabled = false;
					pictureBoxSolutions[rij, kolom].BackColor = Color.LightGray;
					grpAantalRijen.Controls.Add(pictureBoxSolutions[rij, kolom]);
				}//end for
			}//end for

		}//GeneratePicBoxColorGuessCheck
		
		private void PictureBoxShowSecretCode()//TODO: meer kleuren genereren
		{
			int Aantal = (int)Properties.Settings.Default.NrOfColors;
			ColorClass SecretColors = new ColorClass(Aantal);
			pbSecret = new PictureBox[Aantal];					
			grpSecretCode.Controls.Clear();
			grpSecretCode.Text = "The secret";

			for (int i = 0; i < pbSecret.Length; i++)
			{
				pbSecret[i] = new PictureBox();
				pbSecret[i].Left = 20 + 45 * i;
				pbSecret[i].Top = 20;
				pbSecret[i].Width = 30;
				pbSecret[i].Height = 30;
				if (ShowSecretCode == true)
				{
					pbSecret[i].BackColor = SecretColors.GetColor((Kleur)SecretCode[i]);
				}
				else
				{
					pbSecret[i].BackColor = Color.Black;
				}
				pbSecret[i].BorderStyle = BorderStyle.Fixed3D;
				grpSecretCode.Controls.Add(pbSecret[i]);				
			}//end for				
			this.Controls.Add(grpSecretCode);
			grpSecretCode.Location = new Point(13, grpAantalRijen.Location.Y + grpAantalRijen.Height + 5);
			grpSecretCode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			grpSecretCode.AutoSize = true;
			grpSecretCode.Show();

		}//PictureBoxShowSecretCode	

		#endregion


		#region Drag&Drop

		private void picBox_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pb = sender as PictureBox;
			if (pb != null)
				pb.DoDragDrop(pb.BackColor, DragDropEffects.Move);
		} 

		private void picBox_DragDrop(object sender, DragEventArgs e)
		{
			var data = e.Data.GetData(typeof(Color));

			if (data != null)
				((PictureBox)sender).BackColor = (Color)data;
		}

		private void picBox_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		#endregion


		#region Comparing Secret

		private void CompareExactPosition() //nailed it
		{

			int kolom = 0;
            int rij = 0;
			int indexGeheim = 0;
			int aantalMatches = 0;

			int HorizontalRows = ((int)Properties.Settings.Default.NrOfColors);

			for (int i = 0; i < HorizontalRows; i++)
			
			{		
				if (pictureBoxGenerated[rij, kolom].BackColor.Equals(pbSecret[indexGeheim].BackColor))
				{
					aantalMatches++;
				}

				kolom++;
				indexGeheim++;
			}

			int naarRechts=0;
			int naarOnder=0;

			for (int i = 0; i < aantalMatches; i++)
			{
				pictureBoxSolutions[naarOnder, naarRechts].BackColor = Color.Black;
				naarRechts++;
			}

		}

        private void CompareExactColor() //done
		{

            int VerticalRows = ((int)Properties.Settings.Default.NrOfColors);
            int[] kleurAanwezig = new int[VerticalRows + 1];
            int AantalJuisteKleuren = 0;
			int rij = 0;

            for (int i = 0; i < VerticalRows; i++)
            {
                kleurAanwezig[i] = 0;
            }

            for (int kolom = 0; kolom < VerticalRows; kolom++)
            {
                for (int indexGeheim = 0; indexGeheim < VerticalRows; indexGeheim++)
                {
                    if (pictureBoxGenerated[rij, kolom].BackColor.Equals(pbSecret[indexGeheim].BackColor))//TODO: rij en kolom switchen @2Ddarray-fix
                    {
                        kleurAanwezig[kolom] = +1;
                    }//end if      

                }//end for indexGeheim
            }//end for kolom

            for (int i = 0; i < VerticalRows; i++)
            {
                if (kleurAanwezig[i] > 0)
                {
                    AantalJuisteKleuren++;
                }
            }

			int naarRechts = 0;
			int naarOnder = 0;

			for (int i = 0; i < AantalJuisteKleuren; i++)
			{
				pictureBoxSolutions[naarOnder, naarRechts].BackColor = Color.White;
				naarRechts++;
			}


        }//CompareExactColor

		#endregion


		

		//private void NewRound()
		//{

		//	int naarOnder = 0;
		//	naarOnder++;

				

		//		for (int naarRechts = 0; naarRechts < 3; naarRechts++)
		//		{
		//			pictureBoxGenerated[naarOnder, naarRechts].Enabled = true;
		//			pictureBoxGenerated[naarOnder, naarRechts].BackColor = Color.White;
		//		}
				

		//}

        private void CheckIfAllBoxesAreFilled()
        {

            bool error = false;

			int kolom = 0;
			

                for (int i = 0; i < (int)Properties.Settings.Default.NrOfColors; i++)
                {
                    
                    if (error == false)
                    {

                    if (pictureBoxGenerated[kolom, i].BackColor != Color.White)
					{
                        CompareExactColor();
                        CompareExactPosition();
						//NewRound();
                    }
                    else
                    {
                        for (int j = 0; j < (int)Properties.Settings.Default.NrOfColors; j++)
						{
                            pictureBoxSolutions[j, 0].BackColor = Color.LightGray;
                        }

                        error = true;
                        MessageBox.Show("Please fill all the boxes!");
                    }
						}
			}
		}

        private void GameWon()
        {

            int j = 0;
            int AantalCorrecte = 0;
            bool Won = false;

            {
                for (int i = 0; i < (int)Properties.Settings.Default.NrOfColors; i++)
                {
                    if (Won == false)
                    {

                        if (pictureBoxSolutions[j, i].BackColor == Color.Black)
                        {

                            AantalCorrecte++;

                                if (AantalCorrecte == ((int)Properties.Settings.Default.NrOfColors))
                                {
                                MessageBox.Show("Congratulations, you're a mastermind!");
                                Won = true;
                                }
                        }
                    }
                }
            }
        }

		private void btnTry_Click(object sender, EventArgs e)
		{
			CheckIfAllBoxesAreFilled();
			CompareExactColor();
			CompareExactPosition();
			GameWon();
		}

	}//end frmMasterMind
}//end MasterMind
