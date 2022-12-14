# <img src="/src/icon.png" height="30px"> Verify.Serilog

[![Build status](https://ci.appveyor.com/api/projects/status/bgvkfjn26l5b4kba?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-serilog)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Serilog.svg)](https://www.nuget.org/packages/Verify.Serilog/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [Serilog](https://serilog.net/) bits.



## NuGet package

https://nuget.org/packages/Verify.Serilog/


## Usage

<!-- snippet: Enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Initialize() =>
    VerifySerilog.Enable();
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L3-L9' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Usage -->
<a id='snippet-usage'></a>
```cs
[Fact]
public Task Usage()
{
    RecordingLogger.Start();

    var result = Method();

    return Verify(result);
}

static string Method()
{
    Log.Error("The Message");
    return "Result";
}
```
<sup><a href='/src/Tests/Tests.cs#L7-L23' title='Snippet source file'>snippet source</a> | <a href='#snippet-usage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Tests.Usage.verified.txt -->
<a id='snippet-Tests.Usage.verified.txt'></a>
```txt
{
  target: Result,
  logs: [
    {
      Error: The Message
    }
  ]
}
```
<sup><a href='/src/Tests/Tests.Usage.verified.txt#L1-L8' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.Usage.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
