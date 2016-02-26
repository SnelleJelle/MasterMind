using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MasterMind
{
	[Serializable]
	class ColorComparison
	{
		#region state
		

		#endregion


		#region Constructors

		public ColorComparison()
		{
			
		}

		#endregion


		#region Behavior

		public bool CheckIfAllBoxesAreFilled(Color[] Haystack)
		{
			Color Needle = Color.White;
			for (int i = 0; i < Haystack.Length; i++)
			{
				if (Haystack[i] == Needle)
				{
					return false;
				}
			}
			return true;
		}//CheckIfAllBoxesAreFilled

		public bool CheckIfSequenceContainsNoDupes(Color[] Sequence)
		{
			Color[] Buffer = new Color[Sequence.Length];
			for (int i = 0; i < Sequence.Length; i++)
			{
				if (ContainsDupe(Buffer, Sequence[i]) == false)
				{
					Buffer[i] = Sequence[i];
				}
				else
				{
					return false;
				}								
			}
			return true;
		}//CheckIfSequenceContainsDupes

		private bool ContainsDupe(Color[] Haystack, Color Needle)
		{
			for (int i = 0; i < Haystack.Length; i++)
			{
				if (Haystack[i] == Needle)
				{
					return true;
				}
			}
			return false;

		}//ContainsDupe

		public int NrOfPositionMatches(Color[] querry, Color[] secret)
		{
			int counter = 0;
			for (int i = 0; i < secret.Length; i++)
			{
				if (querry[i] == secret[i])
				{
					counter++;
				}				
			}
			return counter;
		}

		public int NrOfColorMatches(Color[] querry, Color[] secret)
		{
			int counter = 0;
			for (int i = 0; i < querry.Length; i++)
			{
				for (int j = 0; j < secret.Length; j++)
				{
					if (querry[i] == secret[j])
					{
						counter++;
					}//end if
				}//end for
			}//end for

			return counter - NrOfPositionMatches(querry,secret);

		}//NrOfColorMatches

		#endregion

	}//ColorComparison
}//MasterMind
