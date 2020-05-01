# Uni Command Line Parser

コマンドライン引数を解析して指定されたクラスのインスタンスに変換するパッケージ

## 使用例

```bat
Unity.exe ^
    -batchMode ^
    -quit ^
    -executeMethod Example.Run ^
    -myOptionInt 25 ^
    -myOptionFloat 2.5 ^
    -myOptionString "ピカチュウ" ^
    -myOptionBool
```

```cs
using System;
using UniCommandLineParser;
using UnityEngine;

public static class Example
{
    private sealed class Options
    {
        // コマンドライン引数から値を受け取るプロパティには setter が必要
        [Option( "batchMode" )]
        public bool IsBatchMode { get; private set; }

        [Option( "quit" )]
        public bool IsQuit { get; private set; }

        [Option( "executeMethod" )]
        public string ExecuteMethod { get; private set; }

        [Option( "myOptionInt" )]
        public int MyOptionInt { get; private set; }

        [Option( "myOptionFloat" )]
        public float MyOptionFloat { get; private set; }

        [Option( "myOptionString" )]
        public string MyOptionString { get; private set; }

        [Option( "myOptionBool" )]
        public bool MyOptionBool { get; private set; }
    }

    private static void Run()
    {
        var options = CommandLineParser.ParseFromCommandLineArgs<Options>();
        // 下記の記述でも可
        //var options = CommandLineParser.Parse<Options>( Environment.GetCommandLineArgs() );

        Debug.Log( options.IsBatchMode );    // True
        Debug.Log( options.IsQuit );         // True
        Debug.Log( options.ExecuteMethod );  // Example.Run
        Debug.Log( options.MyOptionInt );    // 25
        Debug.Log( options.MyOptionFloat );  // 2.5
        Debug.Log( options.MyOptionString ); // ピカチュウ
        Debug.Log( options.MyOptionBool );   // True
    }
}
```