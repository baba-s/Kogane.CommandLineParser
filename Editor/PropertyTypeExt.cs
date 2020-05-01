using System;

namespace UniCommandLineParser.Internal
{
	/// <summary>
	/// PropertyType 型に関する関数を管理するクラス
	/// </summary>
	internal static class PropertyTypeExt
	{
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// 指定された文字列を PropertyType 型に変換して返します
		/// </summary>
		public static PropertyType FromString( string str )
		{
			switch ( str )
			{
				case "Byte":    return PropertyType.BYTE;
				case "Int16":   return PropertyType.SHORT;
				case "Int32":   return PropertyType.INT;
				case "Int64":   return PropertyType.LONG;
				case "UInt16":  return PropertyType.USHORT;
				case "UInt32":  return PropertyType.UINT;
				case "UInt64":  return PropertyType.ULONG;
				case "Single":  return PropertyType.FLOAT;
				case "Double":  return PropertyType.DOUBLE;
				case "String":  return PropertyType.STRING;
				case "Boolean": return PropertyType.BOOL;
			}

			throw new ArgumentOutOfRangeException();
		}
		
		/// <summary>
		/// 指定された文字列を PropertyType 型に紐づくデータ型に変換して返します
		/// </summary>
		public static object Parse( this PropertyType type, string s )
		{
			switch ( type )
			{
				case PropertyType.BYTE:   return byte.Parse( s );
				case PropertyType.SHORT:  return short.Parse( s );
				case PropertyType.INT:    return int.Parse( s );
				case PropertyType.LONG:   return long.Parse( s );
				case PropertyType.USHORT: return ushort.Parse( s );
				case PropertyType.UINT:   return uint.Parse( s );
				case PropertyType.ULONG:  return ulong.Parse( s );
				case PropertyType.FLOAT:  return float.Parse( s );
				case PropertyType.DOUBLE: return double.Parse( s );
				case PropertyType.STRING: return s;
			}

			throw new ArgumentOutOfRangeException();
		}
	}
}
