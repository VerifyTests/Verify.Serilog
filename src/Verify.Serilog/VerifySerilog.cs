using Argon;

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
        var converters = DefaultContractResolver.Converters;
        converters.Add(new LogEventPropertyConverter());
        converters.Add(new LogEventConverter());
        converters.Add(new ScalarValueConverter());
        converters.Add(new PropertyEnricherConverter());
        converters.Add(new DictionaryValueConverter());
        VerifierSettings.RegisterJsonAppender(
            _ =>
            {
                if (!RecordingLogger.TryFinishRecording(out var entries))
                {
                    return null;
                }

                if (!entries.Any())
                {
                    return null;
                }

                return new("logs", entries);
            });

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Sink<VerifySink>()
            .CreateLogger();
    }
}