# <img src="/src/icon.png" height="30px"> Verify.MicrosoftLogging

[![Build status](https://ci.appveyor.com/api/projects/status/nrbwjnwp2id3k7f8?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-serilog)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Serilog.svg)](https://www.nuget.org/packages/Verify.Serilog/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [Serilog](https://serilog.net/) bits.



## NuGet package

https://nuget.org/packages/Verify.Serilog/


## Usage

<!-- snippet: Enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Initialize()
{
    VerifySerilog.Enable();
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L3-L10' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

## Icon

[Log](https://thenounproject.com/term/log/324064/) designed by [Ben Davis](https://thenounproject.com/smashicons/) from [The Noun Project](https://thenounproject.com).
