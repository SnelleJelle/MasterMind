using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MasterMind
{
	class ColorClass//Jelle heeft ze opgekuisd om alles ivm met colorprocessing in dezelfde klasse te behouden
	{//+ jelle hefet gerenamed om engelse taalconsequentie te behouden, ik weet het....autisme
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

		public ColorClass() : this(3, Kleur.ROOD) { }

		public ColorClass(decimal beurten)
		{
			this.beurtenNR = beurten;
		}

		public ColorClass(decimal beurten, Kleur iniKleur)
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
				case Kleur.WIT:
					return Color.White;
				case Kleur.ZWART:
					return Color.Black;
				default:
					return Color.Red;
			}//end switch
		}//GetColor

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
				case Kleur.WIT:
					return Color.White;
				case Kleur.ZWART:
					return Color.Black;
				default:
					return Color.Red;
			}//end switch
		}//GetNextcolor

		#endregion

	}//colorclass
}//mastermind

