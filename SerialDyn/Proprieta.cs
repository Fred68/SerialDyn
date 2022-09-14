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
		COLOR,				// ARGB
		None				// Ultimo 
		}



	/// <summary>
	/// Classe Dat: oggetto generico con associato il tipo di dato.
	/// La classe non è generica, per poter esser contenuta in un unico raccoglitore
	/// </summary>
	public class Proprieta
		{
				
		TypeVar _t;					// Tipo di dato
		object? _obj;				// Oggetto (non è readonly)	


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

		public Proprieta()
			{
			_t = TypeVar.None;
			_obj = null;
			}
		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="t"></param>
		/// <param name="_d"></param>
		public Proprieta(int _d)
			{
			_t = TypeVar.INT;
			_obj = _d;
			}
		public Proprieta(string _d)
			{
			_t = TypeVar.STR;
			_obj = _d;
			}
		public Proprieta(bool _d)
			{
			_t = TypeVar.BOOL;
			_obj = _d;
			}

		public Proprieta(float _d)
			{
			_t = TypeVar.FLOAT;
			_obj = _d;
			}

		public Proprieta(double _d)
			{
			_t = TypeVar.DOUBLE;
			_obj = _d;
			}

		public Proprieta(DateTime _d)
			{
			_t = TypeVar.DATE;
			_obj = _d;
			}

		
		/// <summary>
		/// Costruttore di copia
		/// </summary>
		/// <param name="tpl"></param>
		public Proprieta(Proprieta tpl)
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
			sb.Append(this._t.ToString() + "=" + this.Get().ToString());
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
		
#if false
		public static Proprieta Parse(string s)
			{
			return new Proprieta(s);
			}
#endif
		}

public static class EstensioneX
	{
	
	}
	
	//public static class ExtensionParse
	//	{
	//	public static Proprieta Parse(this string s)
	//		{
	//		return new Proprieta(s);
	//		}
	//	}

#if false
	public class ObjJsonConverter : JsonConverter<Proprieta>
		{
        public override Proprieta Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
                Proprieta.Parse(reader.GetString()!);

        public override void Write(
            Utf8JsonWriter writer,
            Proprieta pValue,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(pValue.ToString());
		}
#endif


	//var options = new JsonReaderOptions
	//{
	//    AllowTrailingCommas = true,
	//    CommentHandling = JsonCommentHandling.Skip
	//};
	//var reader = new Utf8JsonReader(jsonUtf8Bytes, options);

	//while (reader.Read())
	//{
	//    Console.Write(reader.TokenType);

	//    switch (reader.TokenType)
	//    {
	//        case JsonTokenType.PropertyName:
	//        case JsonTokenType.String:
	//            {
	//                string? text = reader.GetString();
	//                Console.Write(" ");
	//                Console.Write(text);
	//                break;
	//            }

	//        case JsonTokenType.Number:
	//            {
	//                int intValue = reader.GetInt32();
	//                Console.Write(" ");
	//                Console.Write(intValue);
	//                break;
	//            }

	//            // Other token types elided for brevity
	//    }
	//    Console.WriteLine();
	//}

	}
