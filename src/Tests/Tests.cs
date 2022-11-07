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

    static string Method()
    {
        Log.Error("The Message");
        return "Result";
    }
}