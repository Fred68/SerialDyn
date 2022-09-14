using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Text.Json.Serialization;	// JsonIgnore o altro

namespace SerialDyn
	{


	/// <summary>
	/// DAti (da serializzare)
	/// </summary>
	public class Dat
		{
		string _desc;
	
		List<Proprieta> _lpr;		// Lista delle proprietà
		
		#region PROPRIETA' PUBBLICHE (Per serializzazione)

		public string Descrizione
			{
			get {return _desc;}
			set {_desc = value;}
			}

		public List<Proprieta> Lpr
			{
			get {return _lpr;}
			set {_lpr = value;}
			}
		#endregion

		public override string ToString()
			{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Descrizione);
			foreach(Proprieta p in _lpr)
				sb.AppendLine(p.ToString());
			return sb.ToString();
			}
		public void CreaDati()
			{
			_lpr.Add(new Proprieta(true));
			_lpr.Add(new Proprieta(DateTime.Now));
			_lpr.Add(new Proprieta(1.234d));
			_lpr.Add(new Proprieta(-3.45f));
			_lpr.Add(new Proprieta((int)10));
			_lpr.Add(new Proprieta("Prova"));
			}

		public Dat()
			{
			_desc = "-";
			_lpr = new List<Proprieta>();
			}
		
		}
	}
