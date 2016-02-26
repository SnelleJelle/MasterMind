using System;
using System.Drawing;

namespace MasterMind
{
	[Serializable]
	class ColorSequence
	{
		#region state
		private decimal beurtenNR;
		private Kleur huidigeKleur;
		#endregion state


		#region properties
		public decimal BeurtenNR
		{
			get { return beurtenNR; }
			set { beurtenNR = value; }
		}

		public Kleur HuidigeKleur
		{
			get { return huidigeKleur; }
			set { huidigeKleur = value; }
		}

		#endregion properties


		#region constructors

		public ColorSequence() : this(3, Kleur.ROOD) { }

		public ColorSequence(decimal beurten)
		{
			this.beurtenNR = beurten;
		}

		public ColorSequence(decimal beurten, Kleur iniKleur)
		{
			this.beurtenNR = beurten;
			this.huidigeKleur = iniKleur;
		}
		#endregion constructors


		#region behaviour

		public Color GetNextColor()
		{
			Color tmp = GenerateColor();
			ToggleNextColor();
			return tmp;
		}//GetNextColor

		public Color GetColor(Kleur keuze)
		{
			switch (keuze)
			{
				case Kleur.ROOD:
					return Color.Red;
				case Kleur.GROEN:
					return Color.Green;
				case Kleur.BRUIN:
					return Color.Brown;
				case Kleur.BLAUW:
					return Color.Blue;
				case Kleur.CYAAN:
					return Color.Cyan;
				case Kleur.GEEL:
					return Color.Yellow;
				case Kleur.GRIJS:
					return Color.Gray;
				case Kleur.PAARS:
					return Color.Purple;
				case Kleur.LIME:
					return Color.Lime;
				case Kleur.ZWART:
					return Color.Black;
				default:
					return Color.Red;
			}//end switch
		}//GetColor

		public Color[] GetColorSequence(int NrOfColors)
		{
			Color[] tmp = new Color[NrOfColors + 1];
			for (int i = 0; i <= NrOfColors; i++)
			{
				tmp[i] = GetColor((Kleur)i);
			}
			return tmp;

		}//GetColorSequence

		private void ToggleNextColor()
		{
			int kleurnummer = (int)HuidigeKleur;
			kleurnummer += 1;
			kleurnummer %= (int)BeurtenNR;
			HuidigeKleur = (Kleur)kleurnummer;
		}//ToggleNextColor

		private Color GenerateColor()
		{
			switch (HuidigeKleur)
			{
				case Kleur.ROOD:
					return Color.Red;
					
				case Kleur.GROEN:
					return Color.Green;
				case Kleur.BRUIN:
					return Color.Brown;
				case Kleur.BLAUW:
					return Color.Blue;
				case Kleur.CYAAN:
					return Color.Cyan;
				case Kleur.GEEL:
					return Color.Yellow;
				case Kleur.GRIJS:
					return Color.Gray;
				case Kleur.PAARS:
					return Color.Purple;
				case Kleur.LIME:
					return Color.Lime;
				case Kleur.ZWART:
					return Color.Black;
				default:
					return Color.Red;
			}//end switch
		}//GetNextcolor

		#endregion

	}//colorclass
}//mastermind

