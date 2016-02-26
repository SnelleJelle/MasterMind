using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;

namespace MasterMind
{
	[Serializable]
	class MasterMindGame
	{

		#region state

		private Randomiser rnd;
		private ColorComparison cc = new ColorComparison();

		private bool userPlays;
		private bool computerPlays;
		private int nrOfAvailableColors;
		private int nrOfColorsToGuess;
		private int nrOfTurns;
		
		private Color[] availableColors;
		private Color[,] userInput;
		private Color[,] userCheck;
		private Color[] secretCode;

		private Color feeddbackBlanc = Color.LightGray;
		private Color inputEnabled = Color.White;
		private Color inputDisabled = Color.LightGray;		
		private Color postionMatch = Color.Black;		
		private Color colorMatch = Color.White;

		private bool gameIsWon;
		private bool showSecretCode;
		private Color[] dontShowSecret;
		private int nrOfTurnsPlayed;
		private string date;

		#endregion


		#region properties

		public Color[] SecretCode
		{
			get {
					if (showSecretCode == true)
					{
						return secretCode;
					}
					else
					{
						return dontShowSecret;
					}//end if
				}//end get
			set { SecretCode = value; }
					
		}//SecretCode

		public Color[,] UserInput
		{
			get { return userInput; }
			set { userInput = value; }
		}

		public Color[,] UserCheck
		{
			get { return userCheck; }
			set { userCheck = value; }
		}

		public Color[] AvailableColors
		{
			get { return availableColors; }
		}


		public int NrOfAvailableColors
		{
			get { return nrOfAvailableColors; }
			set { nrOfAvailableColors = value; }
		}

		public int NrOfColorsToGuess
		{
			get { return nrOfColorsToGuess; }
			set { nrOfColorsToGuess = value; }
		}

		public int NrOfTurns
		{
			get { return nrOfTurns; }
			set { nrOfTurns = value; }
		}

		//BackColors
		public Color FeeddbackBlanc
		{
			get { return feeddbackBlanc; }
		}

		public Color PostionMatch
		{
			get { return postionMatch; }
		}

		public Color ColorMatch
		{
			get { return colorMatch; }
		}

		public Color InputEnabled
		{
			get { return inputEnabled; }
		}

		public Color InputDisabled
		{
			get { return inputDisabled; }
		}		
		//

		public bool GameIsWon
		{
			get { return gameIsWon; }
		}

		public int NrOfTurnsPlayed
		{
			get { return nrOfTurnsPlayed; }
			set { nrOfTurnsPlayed = value; }
		}

		public bool UserPlays
		{
			get { return userPlays; }
		}

		public bool ComputerPlays
		{
			get { return computerPlays; }
		}

		public string Date
		{
			get { return date; }
			set { date = value; }
		}

		#endregion


		#region constructors

		public MasterMindGame(bool computerPlayer, int nrOfAvailableColors, int nrofColorsToGuess, int nrOfTurns, bool showSecret)
		{
			if (computerPlayer == true)
			{
				this.userPlays = false;
				this.computerPlays = true;
			}
			else
			{
				this.computerPlays = false;
				this.userPlays = true;
			}//end if
			this.nrOfAvailableColors = nrOfAvailableColors;
			this.nrOfColorsToGuess = nrofColorsToGuess;
			this.nrOfTurns = nrOfTurns;
			this.showSecretCode = showSecret;

			rnd = new Randomiser();			
			int[] SecretCodeInt = rnd.GetRandomSequence(0, nrOfAvailableColors - 1, nrOfColorsToGuess);
			secretCode = new Color[nrOfColorsToGuess];

			ColorSequence cs = new ColorSequence();
			for (int i = 0; i <  nrOfColorsToGuess; i++)
			{
				this.secretCode[i] = cs.GetColor((Kleur)SecretCodeInt[i]);
			}

			cs.BeurtenNR = nrOfAvailableColors;
			this.availableColors = new Color[nrOfAvailableColors + 1];
			for (int i = 0; i < nrOfAvailableColors; i++)
			{
				this.availableColors[i] = cs.GetNextColor();
			}

			dontShowSecret = new Color[nrOfColorsToGuess + 1];
			for (int i = 0; i < dontShowSecret.Length; i++)
			{
				dontShowSecret[i] = Color.Black;
			}

			UserInput = new Color[nrOfTurns,nrOfColorsToGuess];
			userCheck = new Color[nrOfTurns, nrOfColorsToGuess];
			date = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

		}//MasterMindGame

		#endregion constructors


		#region behaviour

		public bool IsGameWon(Color[] input)
		{
			bool isWon = true;
			for (int i = 0; i < input.Length; i++)
			{
				if (secretCode[i] != input[i])
				{
					isWon = false;
				}//end if
			}//end for
			if (isWon == true)
			{
				this.gameIsWon = true;
			}			
			return isWon;

		}//IsGameWon

		//ColorComparison
		public bool CheckIfAllBoxesAreFilled(Color[] Haystack)
		{
			return cc.CheckIfAllBoxesAreFilled(Haystack);
		}//CheckIfAllBoxesAreFilled

		public bool CheckIfSequenceContainsNoDupes(Color[] Sequence)
		{
			return cc.CheckIfSequenceContainsNoDupes(Sequence);
		}//CheckIfSequenceContainsDupes		

		public int NrOfPositionMatches(Color[] querry)
		{
			return cc.NrOfPositionMatches(querry, secretCode);
		}

		public int NrOfColorMatches(Color[] querry)
		{
			return cc.NrOfColorMatches(querry, secretCode);

		}//NrOfColorMatches
		//

		#endregion

	}//MasterMindGame
}//MasterMind
