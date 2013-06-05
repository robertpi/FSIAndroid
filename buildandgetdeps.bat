msbuild ..\fsharp\src\fsharp-library-build.proj /p:TargetFramework=mono21 /p:Configuration=Debug
msbuild ..\fsharp\src\fsharp-compiler-build.proj /p:TargetFramework=mono21 /p:Configuration=Debug
copy /y ..\fsharp\lib\debug\2.1\FSharp.C* .
"C:\Program Files (x86)\Mono-2.10.9\bin\pdb2mdb.bat" FSharp.Core.dll
"C:\Program Files (x86)\Mono-2.10.9\bin\pdb2mdb.bat" FSharp.Compiler.Mono.Android.dll

