using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace MasterMind
{
	class GamestateSave
	{
		const string strFileName = "Games.dat";

		public GamestateSave()
		{
			if (!File.Exists(strFileName))
			{
				FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write, FileShare.Write);//read?
				fs.Close();
			}
		}

		public void SaveGame(MasterMindGame Game)
		{
			FileStream stream = null;
			if (LoadGame(Game.Date) == null)
			{				
				try
				{
					stream = new FileStream(strFileName, FileMode.Append, FileAccess.Write, FileShare.None);
					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(stream, Game);
				}
				catch (Exception error)
				{
					throw new Exception(error.Message);
				}
				stream.Close();
			}
			else
			{
				throw new Exception("Game not saved (Game already exists)...");
			}
		}

		public MasterMindGame LoadGame(string Datum)
		{
			MasterMindGame G = null;
			bool Found = false;
			FileStream stream = new FileStream(strFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			BinaryFormatter formatter = new BinaryFormatter();
			while ((stream.Position < stream.Length) && (!Found))
			{
				G = (MasterMindGame)formatter.Deserialize(stream);
				Found = G.Date == Datum;
			}
			stream.Close();
			if (!Found)
			{
				return null;
			}
			else
			{
				return G;
			}
		}

		public string[] GetDates()
		{
			string[] Dates;

			MasterMindGame G = null;
			int length = 0;
			FileStream stream = new FileStream(strFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			BinaryFormatter formatter = new BinaryFormatter();
			Dates = new string[stream.Length];
			while ((stream.Position < stream.Length))
			{
				G = (MasterMindGame)formatter.Deserialize(stream);
				if (G != null)
					Dates[length] = G.Date;
				length++;
			}
			stream.Close();

			return Dates;
		}//GetDates
	}
}

