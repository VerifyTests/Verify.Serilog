﻿public class Tests
{
    #region Usage

    [Fact]
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

    #endregion

    [Fact]
    public Task Empty()
    {
        Recording.Start();
        return Verify("Result");
    }

    [Fact]
    public Task ScalarValueGuid() =>
        Verify(new ScalarValue(Guid.NewGuid()));

    [Fact]
    public Task ForContext()
    {
        Recording.Start();

        var logger = Log.ForContext("key", "value");
        logger.Error("The Message");

        return Verify("Result");
    }
    [Fact]
    public Task LogContextPush()
    {
        Recording.Start();

        using (LogContext.Push(
                   new PropertyEnricher("Property1", new ScalarValue("Value1")),
                   new PropertyEnricher("Property2", new ScalarValue("Value2"))))
        {
            Log.Error("The Message");
        }

        return Verify("Result");
    }

    [Fact]
    public Task DictionaryValue() =>
        Verify(
            new DictionaryValue(
                [
                    new(new(Guid.NewGuid()), new ScalarValue("value"))
                ]));
}