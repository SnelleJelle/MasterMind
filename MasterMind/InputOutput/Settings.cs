using System;
using System.Windows.Forms;

namespace MasterMind
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();			
        }

		private void nudAvailableColors_ValueChanged(object sender, EventArgs e)
        {
            nudColorGuess.Maximum = nudAvailableColors.Value;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           ColorSequence aantal = new ColorSequence(nudAvailableColors.Value);
		
		   Properties.Settings.Default.NrOfTurns = nudTurns.Value;
		   Properties.Settings.Default.NrOfColors = nudColorGuess.Value;
		   Properties.Settings.Default.NrOfAvailableColors = nudAvailableColors.Value;
		   Properties.Settings.Default.Userguessing = rdbUser.Checked;
		   Properties.Settings.Default.Computerguessing = rdbComputer.Checked;

		   this.Close();
		}

		private void frmSettings_Load(object sender, EventArgs e)
		{
			nudTurns.Value = Properties.Settings.Default.NrOfTurns;
			nudAvailableColors.Value = Properties.Settings.Default.NrOfAvailableColors;
			nudColorGuess.Value = Properties.Settings.Default.NrOfColors;	
			rdbUser.Checked = Properties.Settings.Default.Userguessing;
			rdbComputer.Checked = Properties.Settings.Default.Computerguessing;
		}

    }
}
