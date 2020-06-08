using System.Reflection;

namespace Kogane.Internal
{
	/// <summary>
	/// オプションを受け取るプロパティの情報を管理するクラス
	/// </summary>
	internal sealed class OptionPropertyData
	{
		//================================================================================
		// プロパティ
		//================================================================================
		public PropertyInfo    PropertyInfo    { get; } // リフレクションで取得したプロパティの情報
		public OptionAttribute OptionAttribute { get; } // プロパティに設定されている Option 属性
		public PropertyType    PropertyType    { get; } // プロパティの型の種類

		public bool IsBool => PropertyType == PropertyType.BOOL; // bool 型の場合 true

		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public OptionPropertyData( PropertyInfo propertyInfo )
		{
			PropertyInfo    = propertyInfo;
			OptionAttribute = propertyInfo.GetCustomAttribute<OptionAttribute>();
			PropertyType    = PropertyTypeExt.FromString( PropertyInfo.PropertyType.Name );
		}
	}
}