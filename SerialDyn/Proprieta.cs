using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;

//	using System.Linq;
//	using System.Text;
//	using System.Threading.Tasks;
//	using System.Reflection;
using System.Text.Json.Serialization;
using static System.Windows.Forms.Design.AxImporter;

namespace SerialDyn
	{

	public enum Unita		// Il carattere / è sostituito dal carattere _ ?
		{
		scalare = 0,
		m,
		mm,
		kg_m3,
		N,
		cP,					// centiPoise
		Pa,
		bar,
		A,
		Ohm,
		V,
		m_s,				// m/s
		kg_s
		}

	/// <summary>
	/// Tipi di dati trattati
	/// </summary>
	public enum TypeVar
		{
		INT,
		STR,
		BOOL,
		FLOAT,
		DOUBLE,
		DATE,
		//COLOR,			// ARGB
		None				// Ultimo 
		}



	/// <summary>
	/// Classe P: oggetto generico con associato il tipo di dato.
	/// La classe non è generica, per poter esser contenuta in un unico raccoglitore
	/// </summary>
	public class P
		{
				
		TypeVar _t;			// Tipo di dato
		object _obj;		// Oggetto (non è readonly)	


		#region PROPRIETA (per serializzazione)
		
		//[JsonPropertyOrder(0)]			// Per primo	
		public TypeVar T
			{
			get {return _t;}
			set {_t = value;}
			}

		[JsonInclude]		
		/// <summary>
		/// Dato (dynamic)
		/// </summary>
		public dynamic Obj
			{
			get {return _obj;}
			set {_obj = value;}
			}
		#endregion

		public static Type GetEqType(dynamic x)
			{
			return x.GetType();		
			}

		/// <summary>
		/// Ctor vuoto
		/// </summary>
		public P()
			{
			_t = TypeVar.None;
			_obj = new Object();
			}
		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="t"></param>
		/// <param name="_d"></param>
		public P(int _d)
			{
			_t = TypeVar.INT;
			_obj = _d;
			}
		public P(string _d)
			{
			_t = TypeVar.STR;
			_obj = _d;
			}
		public P(bool _d)
			{
			_t = TypeVar.BOOL;
			_obj = _d;
			}
		public P(float _d)
			{
			_t = TypeVar.FLOAT;
			_obj = _d;
			}
		public P(double _d)
			{
			_t = TypeVar.DOUBLE;
			_obj = _d;
			}
		public P(DateTime _d)
			{
			_t = TypeVar.DATE;
			_obj = _d;
			}

		
		/// <summary>
		/// Costruttore di copia
		/// </summary>
		/// <param name="tpl"></param>
		public P(P tpl)
			{
			_t = tpl._t;
			_obj = tpl._obj;
			}

		/// <summary>
		/// Restituisce l'oggetto, riconvertito al tipo di dato originario.
		/// La dichiarazione è dynamic, per avere un'unica funzione Get
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public dynamic Get()
			{
			switch(_t)
				{
				case TypeVar.INT:
					{
					return (int)_obj;
					}
					//break;
				case TypeVar.STR:
					{
					return (string)_obj;
					}
					//break;
				case TypeVar.BOOL:
					{
					return (bool)_obj;
					}
					//break;
				case TypeVar.FLOAT:
					{
					return (float)_obj;
					}
					//break;
				case TypeVar.DOUBLE:
					{	
					return (double)_obj;
					}
					//break;
				case TypeVar.DATE:
					{
					return (DateTime)_obj;
					}
					//break;
				
				default:
					throw new NotImplementedException("Tipo dato non definito");
				}
			}
		
		/// <summary>
		/// ToString() override
		/// </summary>
		/// <returns></returns>
		public override string ToString()
			{
			StringBuilder sb = new StringBuilder();
			try
				{
				sb.Append(this._t.ToString() + "=" + this.Get().ToString());
				}
			catch
				{
				MessageBox.Show($"Errore in ToString()");
				}
			return sb.ToString();
			} 

		public void Set(int _d)
			{
			if(_t == TypeVar.INT)
				_obj = _d;
			else
				throw new ArgumentException();
			}
		public void Set(string _d)
			{
			if((_t == TypeVar.STR))
				_obj = _d;
			else
				throw new ArgumentException();
			}
		public void Set(bool _d)
			{
			if((_t == TypeVar.BOOL))
				_obj = _d;
			else
				throw new ArgumentException();
			}
		public void Set(float _d)
			{
			if(_t == TypeVar.FLOAT)
				_obj = _d;
			else
				throw new ArgumentException();
			}
		public void Set(double _d)
			{
			if(_t == TypeVar.DOUBLE)
				_obj = _d;
			else
				throw new ArgumentException();
			}
		public void Set(DateTime _d)
			{
			if(_t == TypeVar.DATE)
				_obj = _d;
			else
				throw new ArgumentException();
			}	

		//	ALTERNATIVA (non funzionante)
		//	public static P Parse(string s)
		//		{
		//		var instance = new P();
		//		instance.Set(100d);					// Prova
		//		return instance;
		//		}
		}

	//	-----------
	//	LEGGERE:
	//	https://docs.microsoft.com/it-it/dotnet/standard/serialization/system-text-json-converters-how-to?pivots=dotnet-6-0#registration-sample---converters-collection
	//
	//	Meglio eseguire override dei convertitori JSON (versione per tipi base)
	//	Il formato di salvataggio è personalizzato (qui: TIPO_DATO = valore_in_stringa)
	//
	//	-----------

	/// <summary>
	/// Override del convertitore JSON (versione per tipi base)
	/// </summary>
	public class PJsonConverter : JsonConverter<P>
		{
		public override P Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options) =>
				ReadProp(ref reader,typeToConvert)!;

		P? ReadProp(ref Utf8JsonReader reader, Type typeToConvert)
			{
			P? p = null;
			string s = reader.GetString()!;		// Può essere nullo
			MessageBox.Show(s);
			string[] ps = s.Split('=',2);

			switch(ps[0])
				{
				case nameof(TypeVar.DOUBLE):
					{
					double x;
					if(double.TryParse(ps[1],out x))
						p = new P(x);
					}
					break;
				case nameof(TypeVar.INT):
					{
					int x;
					if(int.TryParse(ps[1],out x))
						p = new P(x);	
					}
					break;
				case nameof(TypeVar.FLOAT):
					{
					float x;
					if(float.TryParse(ps[1],out x))
						p = new P(x);	
					}
					break;
				case nameof(TypeVar.BOOL):
					{
					bool x;
					if(bool.TryParse(ps[1],out x))
						p = new P(x);	
					}
					break;
				case nameof(TypeVar.STR):
					{
					string x = ps[1];
					p = new P(x);	
					}
					break;
				case nameof(TypeVar.DATE):
					{
					DateTime x;
					if(DateTime.TryParse(ps[1],out x))
						p = new P(x);	
					}
					break;
				default:
					throw new JsonException("Tipo dati non gestito");

				}
			return p;
			}

		public override void Write(
            Utf8JsonWriter writer,
            P pValue,
            JsonSerializerOptions options) =>
                WriteProp(writer, pValue);

		 void WriteProp(Utf8JsonWriter writer,  P pValue)
			{
			writer.WriteStringValue(pValue.ToString().AsSpan());
			}
		}
	

	/// <summary>
	/// Proprietà completa
	/// Si ingloba la classe P all'interno di proprietà, usando il convertitore base.
	/// Per i dati si usa List<Proprietà>.
	/// Proprietà (che contiene P) viene serializzato con la funzione di base
	/// List<P> richiederebbe invece un convertitore più complesso.
	/// </summary>
	public class Proprieta
		{	
		P _p;

		[JsonConverter(typeof(PJsonConverter))]
		public P P
			{
			get {return _p;}
			set {_p = value;}
			}

		/// <summary>
		/// Ctor vuoto
		/// </summary>
		public Proprieta()
			{
			_p = new P();
			}
		/// <summary>
		/// Ctor con proprietà P
		/// </summary>
		/// <param name="p"></param>
		public Proprieta(P p)
			{
			_p = p;
			}

		public Proprieta(int v)
			{
			_p = new P(v);
			}
		public Proprieta(bool v)
			{
			_p = new P(v);
			}
		public Proprieta(float v)
			{
			_p = new P(v);
			}
		public Proprieta(double v)
			{
			_p = new P(v);
			}
		public Proprieta(string v)
			{
			_p = new P(v);
			}
		public Proprieta(DateTime v)
			{
			_p = new P(v);
			}


		public override string ToString()
			{
			StringBuilder sb = new StringBuilder();
			try
				{
				sb.Append(this._p.ToString());
				}
			catch
				{
				MessageBox.Show($"Errore in ToString()");
				}
			return sb.ToString();
			} 
		}
	}
