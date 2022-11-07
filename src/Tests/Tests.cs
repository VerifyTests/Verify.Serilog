using Serilog;
using VerifyTests.Serilog;

[UsesVerify]
public class Tests
{
    [Fact]
    public Task LoggingTyped()
    {
        var provider = LoggerRecording.Start();
        
        Log.ForContext()
        Log.Debug(); = 
        ClassThatUsesTypedLogging target = new(logger);

        var result = target.Method();

        return Verify(result);
    }
}