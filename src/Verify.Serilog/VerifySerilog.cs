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
        VerifierSettings.RegisterJsonAppender(_ =>
        {
            if (!LoggerRecording.TryFinishRecording(out var entries))
            {
                return null;
            }

            return new("logs", entries!);
        });
    }
}