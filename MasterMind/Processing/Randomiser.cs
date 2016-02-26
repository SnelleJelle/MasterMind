using System;
using System.Linq;

namespace MasterMind
{
	[Serializable]
	class Randomiser
	{
		#region state

		private int startRange;
		private int endRange;
		private int ignore;

		#endregion


		#region Constructors

		public Randomiser() : this(0, 0) { }

		public Randomiser(int start, int end)
		{
			this.startRange = start;
			this.endRange = end;
		}

		#endregion


		#region behavior

		public int[] GetRandomSequence()
		{
			return GetRandomSequence(startRange, endRange, 0);
		}

		public int[] GetRandomSequence(int start, int end, int keep)
		{
			int[] sequence = new int[end + 1];

			for (int i = 0; i <= end; i++)
			{
				sequence[i] = i;
			}//end for

			//shuffler
			Random rnd = new Random();
			for (int i = sequence.Length; i > 0; i--)
			{
				int j = rnd.Next(i);
				int k = sequence[j];
				sequence[j] = sequence[i - 1];
				sequence[i - 1] = k;
			}//end for

			//remove some
			ignore = end - keep;
			for (int i = ignore; i > 0; i--)
			{
				sequence = sequence.Where(val => val != rnd.Next()).ToArray();
			}				

			return sequence;

		}//GetRandomSequence

		#endregion		

	}
}
