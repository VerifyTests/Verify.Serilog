namespace VerifyTests;

public static class VerifySerilog
{
    public static bool Initialized { get; private set; }

    internal static HashSet<string> IgnoredSourceContexts { get; } = [];

    public static void IgnoreSourceContext<T>() =>
        IgnoreSourceContext(typeof(T).FullName!);

    public static void IgnoreSourceContext(string sourceContext)
    {
        InnerVerifier.ThrowIfVerifyHasBeenRun();
        IgnoredSourceContexts.Add(sourceContext);
    }

    public static void Initialize(Action<LoggerConfiguration>? custom = null)
    {
        if (Initialized)
        {
            throw new("Already Initialized");
        }

        Initialized = true;

        InnerVerifier.ThrowIfVerifyHasBeenRun();
        VerifierSettings.AddExtraSettings(_ =>
        {
            _.Converters.Add(new LogEventPropertyConverter());
            _.Converters.Add(new LogEventConverter());
            _.Converters.Add(new ScalarValueConverter());
            _.Converters.Add(new PropertyEnricherConverter());
            _.Converters.Add(new DictionaryValueConverter());
            _.Converters.Add(new StructureValueConverter());
        });

        var configuration = new LoggerConfiguration();
        configuration.MinimumLevel.Verbose();
        var enrich = configuration.Enrich;
        enrich.FromLogContext();
        configuration.WriteTo.Sink<VerifySink>();
        custom?.Invoke(configuration);
        Log.Logger = configuration.CreateLogger();
    }
}
