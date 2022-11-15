namespace VerifyTests;

public static class VerifySerilog
{
    public static void Enable()
    {
        VerifierSettings.AddExtraSettings(_ =>
        {
            _.Converters.Add(new LogEventPropertyConverter());
            _.Converters.Add(new LogEventConverter());
            _.Converters.Add(new ScalarValueConverter());
            _.Converters.Add(new PropertyEnricherConverter());
        });
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