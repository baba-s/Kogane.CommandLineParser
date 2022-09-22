using System;

namespace Kogane.Internal
{
    /// <summary>
    /// PropertyType 型に関する関数を管理するクラス
    /// </summary>
    internal static class PropertyTypeExtensionMethods
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// 指定された文字列を PropertyType 型に変換して返します
        /// </summary>
        public static PropertyType FromString( string str )
        {
            return str switch
            {
                "Byte"    => PropertyType.BYTE,
                "Int16"   => PropertyType.SHORT,
                "Int32"   => PropertyType.INT,
                "Int64"   => PropertyType.LONG,
                "UInt16"  => PropertyType.USHORT,
                "UInt32"  => PropertyType.UINT,
                "UInt64"  => PropertyType.ULONG,
                "Single"  => PropertyType.FLOAT,
                "Double"  => PropertyType.DOUBLE,
                "String"  => PropertyType.STRING,
                "Boolean" => PropertyType.BOOL,
                _         => throw new ArgumentOutOfRangeException()
            };
        }

        /// <summary>
        /// 指定された文字列を PropertyType 型に紐づくデータ型に変換して返します
        /// </summary>
        public static object Parse( this PropertyType type, string s )
        {
            return type switch
            {
                PropertyType.BYTE   => byte.Parse( s ),
                PropertyType.SHORT  => short.Parse( s ),
                PropertyType.INT    => int.Parse( s ),
                PropertyType.LONG   => long.Parse( s ),
                PropertyType.USHORT => ushort.Parse( s ),
                PropertyType.UINT   => uint.Parse( s ),
                PropertyType.ULONG  => ulong.Parse( s ),
                PropertyType.FLOAT  => float.Parse( s ),
                PropertyType.DOUBLE => double.Parse( s ),
                PropertyType.STRING => s,
                _                   => throw new ArgumentOutOfRangeException()
            };
        }
    }
}