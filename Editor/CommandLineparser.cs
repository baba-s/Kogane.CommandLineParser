using System;
using System.Linq;
using System.Reflection;
using Kogane.Internal;

namespace Kogane
{
	/// <summary>
	/// コマンドライン引数を解析して指定されたクラスのインスタンスに変換するクラス
	/// </summary>
	public static class CommandLineParser
	{
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// Environment.GetCommandLineArgs() を解析して指定されたクラスのインスタンスに変換します
		/// </summary>
		public static T ParseFromCommandLineArgs<T>()
		{
			return Parse<T>( Environment.GetCommandLineArgs() );
		}

		/// <summary>
		/// 指定されたコマンドライン引数の文字列を解析して指定されたクラスのインスタンスに変換します
		/// </summary>
		public static T Parse<T>( params string[] args )
		{
			var targetType = typeof( T );

			// 指定されたクラスのインスタンスを作成する
			var target = Activator.CreateInstance<T>();

			// 指定されたクラスのすべてのプロパティの情報を取得する
			var propertyInfoList = targetType.GetProperties( BindingFlags.Instance | BindingFlags.Public );

			// Option 属性が付いているすべてのプロパティの情報を取得する
			var propertyList = propertyInfoList
					.Select( x => new OptionPropertyData( x ) )
					.Where( x => x.OptionAttribute != null )
				;

			// コマンドライン引数を順番に見ていく
			for ( var i = 0; i < args.Length; i++ )
			{
				var argument = args[ i ];

				// ハイフンで始まっていない引数は無視する
				if ( !argument.StartsWith( "-" ) ) continue;

				// ハイフンを外した名前をオプション名として扱う
				var optionName = argument.Remove( 0, 1 );

				// 指定されたオプションが設定されているプロパティを検索する
				var data = propertyList.FirstOrDefault( x => x.OptionAttribute.Name == optionName );

				// 該当するプロパティが存在しない場合は次の引数に進む
				if ( data == null ) continue;

				// オプションが付いているプロパティが bool 型の場合
				if ( data.IsBool )
				{
					// true にする
					data.PropertyInfo.SetValue( target, true );
				}
				// bool 型以外の場合
				else
				{
					// 次の引数をオプションの値としてプロパティに設定する
					var nextArgument = args[ i + 1 ];
					var value        = data.PropertyType.Parse( nextArgument );
					data.PropertyInfo.SetValue( target, value );
				}
			}

			return target;
		}
	}
}