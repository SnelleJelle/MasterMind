using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace MasterMind
{
    public partial class frmMasterMind : Form
	{
		
		/*=========================================================================*/
		//Toggle to show the secret code on the form
		bool ShowSecretCode = true;		 
		 /*========================================================================*/

		#region Public declarations

		MasterMindGame mmg;

		Label[] labelAvailableColors;
		Label[,] labelGenerated;
		Label[,] labelSolutions;
		Label[] lblSecret;

		ColorSequence cc = new ColorSequence((int)Properties.Settings.Default.NrOfAvailableColors);
		ComputerSpeler CS = new ComputerSpeler();
		GamestateSave gss = new GamestateSave();
		
		Randomiser rnd = new Randomiser();
		GroupBox grpSecretCode = new GroupBox();		

        int VolgendeKleur = 0;

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

		private void LoadNewGUI()
		{
			if (mmg == null)
			{
				bool computerplayer = Properties.Settings.Default.Computerguessing;
				int availablecolors = (int)Properties.Settings.Default.NrOfAvailableColors;
				int nrofcolorstoguess = (int)Properties.Settings.Default.NrOfColors;
				int nrofturns = (int)Properties.Settings.Default.NrOfTurns;
				mmg = new MasterMindGame(computerplayer, availablecolors, nrofcolorstoguess, nrofturns, ShowSecretCode);
			}

			cc.BeurtenNR = Properties.Settings.Default.NrOfAvailableColors;
            CS.AantalKleurenTeRaden = Properties.Settings.Default.NrOfAvailableColors;
			GenerateLabelAvailableColors();
			GenerateLabelColorGuess();			
			LabelShowSecretCode();
			if (mmg.UserPlays == true)
			{
				for (int kolom = mmg.NrOfColorsToGuess - 1; kolom >= 0; kolom--)
				{
					labelGenerated[0, kolom].BackColor = mmg.InputEnabled;
					labelGenerated[0, kolom].Enabled = true;
				}
			}
			else
			{
				for (int kolom = mmg.NrOfColorsToGuess - 1; kolom >= 0; kolom--)
				{
					labelSolutions[0, kolom].Enabled = true;
				}
			}

			ListSaveGames();

			//als laatste
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.AutoSize = true;

		}

		private void ListSaveGames()
		{
			loadToolStripMenuItem.DropDownItems.Clear();
			string[] SaveDates = gss.GetDates();
			for (int i = 0; i < SaveDates.Length; i++)
			{
				if (SaveDates[i] == null)
				{
					return;
				}
				ToolStripMenuItem ms = new ToolStripMenuItem();
				ms.Name = SaveDates[i];
				ms.Text = SaveDates[i];
				loadToolStripMenuItem.DropDownItems.Add(ms);
				ms.Click += new EventHandler(Date_Click);
			}
		}

		private void SettingsClosed(object sender, FormClosedEventArgs e)
		{
			mmg = null;
			LoadNewGUI();
		}

		#endregion

		private void ComputerAi()
		{
			int Aantal = mmg.NrOfColorsToGuess;
			ColorSequence ComputerAi = new ColorSequence(Aantal);
			CS.SpeelEenRonde();
			for (int i = 0; i < Aantal; i++)
			{
				labelGenerated[mmg.NrOfTurnsPlayed, i].BackColor = ComputerAi.GetColor((Kleur)CS.KleurenWaardes[i]);
			}
		}

		public frmMasterMind()
		{
			InitializeComponent();
		}

		private void frmMasterMind_Load(object sender, EventArgs e)
        {
			LoadNewGUI();//TODO: ipv dit moet de latest game geload worden
        }


		#region Label Arrays

		private void GenerateLabelAvailableColors()
		{
			grpAvailableColors.Controls.Clear();
			int Aantal = mmg.NrOfAvailableColors;
			labelAvailableColors = new Label[Aantal];

			for (int i = 0; i < labelAvailableColors.Length; i++)
			{
				labelAvailableColors[i] = new Label();
				labelAvailableColors[i].Left = 20 + 45 * i;
				labelAvailableColors[i].Top = 20;
				labelAvailableColors[i].Width = 30;
				labelAvailableColors[i].Height = 30;
				labelAvailableColors[i].BackColor = mmg.AvailableColors[i];
				labelAvailableColors[i].BorderStyle = BorderStyle.Fixed3D;

				//dragdrop
				labelAvailableColors[i].MouseDown += new MouseEventHandler(label_MouseDown);
                //left click event	
				grpAvailableColors.Controls.Add(labelAvailableColors[i]);
			}//end for
			grpAvailableColors.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			grpAvailableColors.AutoSize = true;
			grpAvailableColors.Show();
			this.AutoSize = true;

		}

		private void GenerateLabelColorGuess()//also moves btnTry
		{					
			int VerticalRows = mmg.NrOfTurns;
			int HorizontalRows = mmg.NrOfColorsToGuess;

			labelGenerated = new Label[VerticalRows, HorizontalRows];
			grpAantalRijen.Controls.Clear();

			for (int  rij = 0; rij < VerticalRows; rij++)
			{
				for (int kolom = 0; kolom < HorizontalRows; kolom++)
				{
					labelGenerated[rij, kolom] = new Label();
					labelGenerated[rij, kolom].Left = 20 + 45 * kolom;
					labelGenerated[rij, kolom].Top = 30 + rij * 38;
					labelGenerated[rij, kolom].Width = 30;
					labelGenerated[rij, kolom].Height = 30;
					labelGenerated[rij, kolom].BorderStyle = BorderStyle.Fixed3D;
					labelGenerated[rij, kolom].BackColor = mmg.InputDisabled;
					labelGenerated[rij, kolom].Enabled = false;

					//Groupbox
					grpAantalRijen.Controls.Add(labelGenerated[rij, kolom]);

					//Dragdrop

                    labelGenerated[rij, kolom].MouseClick += new MouseEventHandler(label_MouseClick);
					labelGenerated[rij, kolom].DragDrop += new DragEventHandler(label_DragDrop);
					labelGenerated[rij, kolom].DragEnter += new DragEventHandler(label_DragEnter);
					labelGenerated[rij, kolom].AllowDrop = true;

				}//end for			
			}//end for

			grpAantalRijen.AllowDrop = true;
			grpAantalRijen.Location = new Point(13, grpAvailableColors.Bottom + 5);

			GenerateLabelColorGuessCheck();
			grpAantalRijen.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			grpAantalRijen.AutoSize = true;

			//move btnTry
			int x = grpAantalRijen.Right + 5;
			int y = grpAantalRijen.Top + labelGenerated[0, 0].Location.Y;			
			btnTry.Location = new Point(x, y);

		}//GenerateLabelColorGuess

		private void GenerateLabelColorGuessCheck()
		{
			int VerticalRows = mmg.NrOfTurns;
			int HorizontalRows = mmg.NrOfColorsToGuess;

			labelSolutions = new Label[VerticalRows, HorizontalRows];			

			for (int rij = 0; rij < VerticalRows; rij++)
			{
				for (int kolom = 0; kolom < HorizontalRows; kolom++)
				{
					labelSolutions[rij, kolom] = new Label();
					labelSolutions[rij, kolom].Left = 50 * HorizontalRows + 20 * kolom;
					labelSolutions[rij, kolom].Top = 38 + rij * 38;
					labelSolutions[rij, kolom].Width = 10;
					labelSolutions[rij, kolom].Height = 10;
					labelSolutions[rij, kolom].BorderStyle = BorderStyle.Fixed3D;					
					labelSolutions[rij, kolom].BackColor = mmg.FeeddbackBlanc;
					labelSolutions[rij, kolom].Enabled = false;
					grpAantalRijen.Controls.Add(labelSolutions[rij, kolom]);
				}//end for
			}//end for

		}//GenerateLabelColorGuessCheck
		
		private void LabelShowSecretCode()
		{
			int Aantal = mmg.NrOfColorsToGuess;
			ColorSequence SecretColors = new ColorSequence(Aantal);
			lblSecret = new Label[Aantal];					
			grpSecretCode.Controls.Clear();
			grpSecretCode.Text = "The secret";

			for (int i = 0; i < lblSecret.Length; i++)
			{
				lblSecret[i] = new Label();
				lblSecret[i].Left = 20 + 45 * i;
				lblSecret[i].Top = 20;
				lblSecret[i].Width = 30;
				lblSecret[i].Height = 30;
				lblSecret[i].BackColor = mmg.SecretCode[i];
				lblSecret[i].BorderStyle = BorderStyle.Fixed3D;
				grpSecretCode.Controls.Add(lblSecret[i]);				
			}//end for				
			this.Controls.Add(grpSecretCode);
			grpSecretCode.Location = new Point(13, grpAantalRijen.Location.Y + grpAantalRijen.Height + 5);
			grpSecretCode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			grpSecretCode.AutoSize = true;
			grpSecretCode.Show();

		}//LabelShowSecretCode	

		#endregion

        #region Click
        //private void label_Click(object sender, EventArgs e)
        //{

        //    if (e.Button = Right)
        //    {
        //        if (VolgendeKleur > (int)Properties.Settings.Default.NrOfAvailableColors - 1)
        //        {
        //            VolgendeKleur = 0;
        //        }
        //        Label lbl = sender as Label;
        //        lbl.BackColor = cc.GetColor((Kleur)VolgendeKleur);
        //        VolgendeKleur++;
        //    }
        //}

        private void label_MouseClick(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (e.Button == MouseButtons.Left)
            {
                if (VolgendeKleur > (int)Properties.Settings.Default.NrOfAvailableColors - 1)
                {
                    VolgendeKleur = 0;
                }
                lbl.BackColor = cc.GetColor((Kleur)VolgendeKleur);
                VolgendeKleur++;
            }
            else
            {
                if (VolgendeKleur != 0)
                {
                    VolgendeKleur--;   
                }
                else
                {
                    VolgendeKleur = (int)Properties.Settings.Default.NrOfAvailableColors - 1;
                }

                lbl.BackColor = cc.GetColor((Kleur)VolgendeKleur);
            }
        }
        #endregion Click

        #region Drag&Drop

        private void label_MouseDown(object sender, MouseEventArgs e)
		{
			Label lbl = sender as Label;
			if (lbl != null)
				lbl.DoDragDrop(lbl.BackColor, DragDropEffects.Move);
		} 

		private void label_DragDrop(object sender, DragEventArgs e)
		{
			var data = e.Data.GetData(typeof(Color));

			if (data != null)
				((Label)sender).BackColor = (Color)data;
		}

		private void label_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		#endregion

		private void StartNewRound()
		{
			if (mmg.NrOfTurnsPlayed == mmg.NrOfTurns - 1)
			{
				btnTry.Enabled = false;
				MessageBox.Show("game over!");				
				return;
			}

			for (int kolom = 0; kolom < mmg.NrOfColorsToGuess; kolom++)
			{
				labelGenerated[mmg.NrOfTurnsPlayed, kolom].Enabled = false;				
				labelGenerated[mmg.NrOfTurnsPlayed + 1, kolom].BackColor = mmg.InputEnabled;
				labelGenerated[mmg.NrOfTurnsPlayed + 1, kolom].Enabled = true;
			}

			btnTry.Top += 38;
			mmg.NrOfTurnsPlayed++;
		}//StartNewRound

		private void btnTry_Click(object sender, EventArgs e)
		{
			Color[] BoxesFilled = new Color[mmg.NrOfColorsToGuess];
			for (int i = 0; i < BoxesFilled.Length; i++)
			{
				BoxesFilled[i] = labelGenerated[mmg.NrOfTurnsPlayed, i].BackColor;
			}//end for		

			if (mmg.ComputerPlays == true)
			{
				ComputerAi();
			}
			else
			{
				if (mmg.UserPlays == true)
				{
					bool GameWon = mmg.IsGameWon(BoxesFilled);
					if (GameWon == true)
					{
						MessageBox.Show("You've won!");
						for (int i = 0; i < BoxesFilled.Length; i++)
						{
							labelGenerated[mmg.NrOfTurnsPlayed, i].Enabled = false;
						}
						return;
					}
					else
					{
						bool AllBoxesFilled = mmg.CheckIfAllBoxesAreFilled(BoxesFilled);
						if (AllBoxesFilled == false)
						{
							MessageBox.Show("ColorSequence incomplete");
							return;
						}
						else
						{
							bool ContainsNoDupes = mmg.CheckIfSequenceContainsNoDupes(BoxesFilled);
							if (ContainsNoDupes == false)
							{
								MessageBox.Show("ColorSequence contains repetition");
								return;
							}//end if
						}//end if
					}//end if

					int labelSolutionsCounter = 0;

					int NrOfBlacks = mmg.NrOfPositionMatches(BoxesFilled);
					for (int i = 0; i < NrOfBlacks; i++)
					{
						labelSolutions[mmg.NrOfTurnsPlayed, labelSolutionsCounter].BackColor = mmg.PostionMatch;
						labelSolutionsCounter++;
					}

					int NrOfWhites = mmg.NrOfColorMatches(BoxesFilled);
					for (int i = 0; i < NrOfWhites; i++)
					{
						labelSolutions[mmg.NrOfTurnsPlayed, labelSolutionsCounter].BackColor = mmg.ColorMatch;
						labelSolutionsCounter++;
					}

				}//end UserPlays

				//in mm object steken
				for (int i = 0; i < mmg.NrOfColorsToGuess; i++)
				{
					mmg.UserInput[mmg.NrOfTurnsPlayed, i] = labelGenerated[mmg.NrOfTurnsPlayed, i].BackColor;
				}

				for (int i = 0; i < mmg.NrOfColorsToGuess; i++)
				{
					mmg.UserCheck[mmg.NrOfTurnsPlayed, i] = labelSolutions[mmg.NrOfTurnsPlayed, i].BackColor;
				}
			}
			StartNewRound();

		}//btnTry_Click

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			gss.SaveGame(mmg);
			MessageBox.Show("Game saved: " + mmg.Date);
			ListSaveGames();
		}

		private void Date_Click(object sender, EventArgs e)
		{
			MasterMindGame SavedGame = gss.LoadGame(sender.ToString());
			LoadSaveGame(SavedGame);
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool computerplayer = Properties.Settings.Default.Computerguessing;
			int availablecolors = (int)Properties.Settings.Default.NrOfAvailableColors;
			int nrofcolorstoguess = (int)Properties.Settings.Default.NrOfColors;
			int nrofturns = (int)Properties.Settings.Default.NrOfTurns;
			mmg = new MasterMindGame(computerplayer, availablecolors, nrofcolorstoguess, nrofturns, ShowSecretCode);
			LoadNewGUI();
		}

		private void LoadSaveGame(MasterMindGame SaveGame)
		{
			mmg = SaveGame;
			LoadNewGUI();

			for (int rij = 0; rij < mmg.NrOfTurns; rij++)
			{
				for (int kolom = 0; kolom < mmg.NrOfColorsToGuess; kolom++)
				{
					if (mmg.UserInput[rij, kolom] != null)
					{
						labelGenerated[rij, kolom].BackColor = mmg.UserInput[rij, kolom];
						labelSolutions[rij, kolom].BackColor = mmg.UserCheck[rij, kolom];
					}
				}//for
			}//for

			for (int kolom = 0; kolom < mmg.NrOfColorsToGuess; kolom++)
			{				
				labelGenerated[mmg.NrOfTurnsPlayed, kolom].BackColor = mmg.InputEnabled;
				labelGenerated[mmg.NrOfTurnsPlayed, kolom].Enabled = true;
			}//for

			foreach (Label lbl in grpAantalRijen.Controls)
			{				
				if (lbl.BackColor == Control.DefaultBackColor)
				{
					lbl.BackColor = mmg.InputDisabled;
				}
			}//end foreach

			btnTry.Top += 38 * mmg.NrOfTurnsPlayed;

		}//LoadSaveGame

	}//end frmMasterMind
}//end MasterMind
