# <img src="/src/icon.png" height="30px"> Verify.Serilog

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://img.shields.io/appveyor/build/SimonCropp/verify-serilog)](https://ci.appveyor.com/project/SimonCropp/verify-serilog)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Serilog.svg)](https://www.nuget.org/packages/Verify.Serilog/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [Serilog](https://serilog.net/) bits.<!-- singleLineInclude: intro. path: /docs/intro.include.md -->

**See [Milestones](../../milestones?state=closed) for release notes.**


## Sponsors


### Entity Framework Extensions<!-- include: sponsors. path: /docs/sponsors.include.md -->

[Entity Framework Extensions](https://entityframework-extensions.net/?utm_source=simoncropp&utm_medium=Verify.Serilog) is a major sponsor and is proud to contribute to the development this project.

[![Entity Framework Extensions](https://raw.githubusercontent.com/VerifyTests/Verify.Serilog/refs/heads/main/docs/zzz.png)](https://entityframework-extensions.net/?utm_source=simoncropp&utm_medium=Verify.Serilog)

### Developed using JetBrains IDEs

[![JetBrains logo.](https://raw.githubusercontent.com/VerifyTests/Verify.Serilog/main/docs/jetbrains.png)](https://jb.gg/OpenSourceSupport)<!-- endInclude -->


## NuGet

 * https://nuget.org/packages/Verify.Serilog


## Usage


### Setup

Use `VerifySerilog.Initialize()`

```cs
[ModuleInitializer]
public static void Initialize() =>
    VerifySerilog.Initialize();
```

Or omit the above is `VerifierSettings.InitializePlugins();` is called:


```cs
[ModuleInitializer]
public static void Initialize() =>
    VerifierSettings.InitializePlugins();
```


### LoggerConfiguration callback

`VerifySerilog.Initialize` accepts an optional `Action<LoggerConfiguration>` callback for customising the underlying Serilog `LoggerConfiguration` — for example to register destructuring policies, enrichers, or filters. The callback runs after `MinimumLevel.Verbose`, `Enrich.FromLogContext`, and the `VerifySink` have been wired up, so it can layer on top of those defaults.

<!-- snippet: Enable -->
<a id='snippet-Enable'></a>
```cs
[ModuleInitializer]
public static void Initialize() =>
    VerifySerilog.Initialize(
        _ => _.Destructure.ByTransforming<Customer>(
            customer => new
            {
                customer.Name
            }));
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L6-L17' title='Snippet source file'>snippet source</a> | <a href='#snippet-Enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Ignoring messages by SourceContext

`VerifySerilog.IgnoreSourceContext` filters out log events whose `SourceContext` property matches a known type or string. Generic and string overloads are provided. Typically called from the module initializer alongside `Initialize`.

```cs
VerifySerilog.IgnoreSourceContext<MyNoisyType>();
VerifySerilog.IgnoreSourceContext("Some.Namespace.Logger");
```

Events emitted via `Log.ForContext<T>()` or `Log.ForContext("SourceContext", "...")` whose source context matches are dropped before being recorded.


### Recording and writing logs

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
