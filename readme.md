# <img src="/src/icon.png" height="30px"> Verify.Serilog

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://img.shields.io/appveyor/build/SimonCropp/verify-serilog)](https://ci.appveyor.com/project/SimonCropp/verify-serilog)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Serilog.svg)](https://www.nuget.org/packages/Verify.Serilog/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [Serilog](https://serilog.net/) bits.<!-- singleLineInclude: intro. path: /docs/intro.include.md -->

**See [Milestones](../../milestones?state=closed) for release notes.**


## Sponsors


### Entity Framework Extensions<!-- include: zzz. path: /docs/zzz.include.md -->

[Entity Framework Extensions](https://entityframework-extensions.net/?utm_source=simoncropp&utm_medium=Verify.Serilog) is a major sponsor and is proud to contribute to the development this project.

[![Entity Framework Extensions](https://raw.githubusercontent.com/VerifyTests/Verify.Serilog/refs/heads/main/docs/zzz.png)](https://entityframework-extensions.net/?utm_source=simoncropp&utm_medium=Verify.Serilog)<!-- endInclude -->


## NuGet

 * https://nuget.org/packages/Verify.Serilog


## Usage

<!-- snippet: Enable -->
<a id='snippet-Enable'></a>
```cs
[ModuleInitializer]
public static void Initialize() =>
    VerifySerilog.Initialize();
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L6-L12' title='Snippet source file'>snippet source</a> | <a href='#snippet-Enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Usage -->
<a id='snippet-Usage'></a>
```cs
[Test]
public Task Usage()
{
    Recording.Start();

    var result = Method();

    return Verify(result);
}

static string Method()
{
    Log.Error("The Message");
    return "Result";
}
```
<sup><a href='/src/Tests/Tests.cs#L4-L22' title='Snippet source file'>snippet source</a> | <a href='#snippet-Usage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Tests.Usage.verified.txt -->
<a id='snippet-Tests.Usage.verified.txt'></a>
```txt
{
  target: Result,
  log: {
    Error: The Message
  }
}
```
<sup><a href='/src/Tests/Tests.Usage.verified.txt#L1-L6' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.Usage.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
