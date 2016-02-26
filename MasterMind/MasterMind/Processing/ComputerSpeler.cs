using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class ComputerSpeler
    {
        #region state
        private decimal aantalKleurenTeRaden;
        Randomiser rnd = new Randomiser();
        private int[] kleurenWaardes;
        ColorClass CCSuperClass = new ColorClass();

        #endregion

        #region properties
        public decimal AantalKleurenTeRaden
        {
            get { return aantalKleurenTeRaden; }
            set { aantalKleurenTeRaden = value; }
        }

        

        public int[] KleurenWaardes
        {
            get { return kleurenWaardes; }
            set { kleurenWaardes = value; }
        }

        #endregion properties




        #region constructors

        public ComputerSpeler() : this(3) { }

        public ComputerSpeler(decimal AantalTeGokken)
        {
            this.AantalKleurenTeRaden = AantalTeGokken;
        }
        #endregion




        #region behaviour

        public void SpeelEenRonde()
        {
            #region commentedShit
            //int temp;
            //bool IsUniek = false;
            //kleurenWaardes = new int[(int)AantalKleurenTeRaden];

            //for (int t = 0; t < AantalKleurenTeRaden; t++)
            //{
            //    kleurenWaardes[t] = 15;
            //    IsUniek = false;

            //for (int i = 0; i < AantalKleurenTeRaden; i++)
            //    {
            //        do
            //        {
            //            temp = random.Next(0, (int)AantalKleurenTeRaden);

            //            if (kleurenWaardes[i] != temp)
            //            {
            //                kleurenWaardes[i] = temp;
            //                IsUniek = true;
            //            }
            //        } while (IsUniek == false);
            //    }//for


            //}//for
            #endregion

            kleurenWaardes = new int[(int)AantalKleurenTeRaden];
			kleurenWaardes = rnd.GetRandomSequence(0, (int)AantalKleurenTeRaden - 1, (int)AantalKleurenTeRaden);          
        }
        #endregion

    }
}
