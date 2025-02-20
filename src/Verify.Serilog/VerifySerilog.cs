namespace VerifyTests;

public static class VerifySerilog
{
    public static bool Initialized { get; private set; }

    public static void Initialize()
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
        });

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .WriteTo.Sink<VerifySink>()
            .CreateLogger();
    }
}