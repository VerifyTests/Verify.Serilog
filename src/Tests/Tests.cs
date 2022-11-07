using Serilog;
using VerifyTests.Serilog;

[UsesVerify]
public class Tests
{
    [Fact]
    public Task Simple()
    {
        RecordingLogger.Start();

        var result = Method();

        return Verify(result);
    }

    [Fact]
    public Task ForContext()
    {
        RecordingLogger.Start();

        var logger = Log.ForContext("key", "value");
        logger.Error("The Message");

        return Verify("Result");
    }

    static string Method()
    {
        Log.Error("The Message");
        return "Result";
    }
}