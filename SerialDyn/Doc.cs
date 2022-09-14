using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerialDyn
	{
	class Doc
		{
		string _filename;			// Nome file completo
		bool _isModified;			// flag, se ci sono modifiche da salvare

		Dat _dati;                  // Dati (da serializzare)


		#region PROPRIETA PUBBLICHE

		public string Filename
			{
			get {return _filename;}
			set {_filename = value;}
			}

		public Dat Dati				// Sola lettura
			{
			get {return _dati;}
			}

		public string Descrizione
			{
			get {return _dati.Descrizione;}
			set {
				string ndes = value;
				if(_dati.Descrizione != ndes)
					{
					_dati.Descrizione = ndes;
					_isModified = true;
					}
				}
			}

		#endregion


		public Doc()
			{
			_dati = new Dat();
			_filename = string.Empty;

			_dati.CreaDati();

			_isModified = false;
			}


		public void AggiornaDescrizione(string desc)
			{
			_dati.Descrizione = desc;
			}

		public void Chiudi()
			{}

		public bool Save(Stream stream,string fileName)
			{
			bool ok = true;
			this._filename = fileName;
			try
				{
				Path.GetFileName(this._filename);
				}
			catch(Exception e)
				{
				ok = false;
				MessageBox.Show($"Errore nel nome file: {_filename} ");
				}
			if(ok)
				{
				try
					{
					using(StreamWriter sw = new StreamWriter(stream))
						{
						var options = new JsonSerializerOptions { WriteIndented = true };
						string jsonString = JsonSerializer.Serialize(_dati, options);
						sw.Write(jsonString);
						}
					}
				catch(Exception e)
					{
					ok = false;
					MessageBox.Show($"Errore nel salvataggio: {e.ToString()} ");
					}
				}
			if(ok)
				{
				_isModified = false;
				}
			return ok;
			}

		public bool Open(Stream stream,string fileName)
			{
			bool ok = true;
			this._filename = fileName;
			try
				{
				using(StreamReader sr = new StreamReader(stream))
					{
					string jsonString = sr.ReadToEnd();
					_dati = JsonSerializer.Deserialize<Dat>(jsonString);
					}
				}
			catch(Exception e)
				{
				ok = false;
				MessageBox.Show($"Errore nel caricamento: {e.ToString()} ");
				}
			if(ok)
				{
				_isModified = false;
				}
			return ok;
			}

		}
	}
