using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MasterMind.Storage
{
    [Serializable]
    class Game
    {
        private decimal nrofturns;
        private decimal nrofcolors;
        private PictureBox[,] turns; //veranderen naar kleur enum array?
        private PictureBox[,] guesses;
        private string[] secret; //veranderen naar kleur enum array?
        private string datum;

        public Game(PictureBox[,] turns, PictureBox[,] guesses, string[] secret)
        {
            datum = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            nrofcolors = Properties.Settings.Default.NrOfColors;
            nrofturns = Properties.Settings.Default.NrOfTurns;

            this.turns = turns;
            this.secret = secret;
        }

        public decimal NrOfTurns
        {
            get { return nrofturns; }
            set { nrofturns = value; }
        }
        public decimal NrOfColors
        {
            get { return nrofcolors; }
            set { nrofcolors = value; }
        }
        public PictureBox[,] Turns
        {
            get { return turns; }
            set { turns = value; }
        }
        public string[] Secret
        {
            get { return secret; }
            set { secret = value; }
        }
        public string Datum
        {
            get { return datum; }
            set { datum = value; }
        }


    }
}