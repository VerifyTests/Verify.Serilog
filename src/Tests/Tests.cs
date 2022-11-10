using Serilog;
using VerifyTests.Serilog;

[UsesVerify]
public class Tests
{
    #region usage
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
    #endregion

    [Fact]
    public Task ForContext()
    {
        RecordingLogger.Start();

        var logger = Log.ForContext("key", "value");
        logger.Error("The Message");

        return Verify("Result");
    }
}