[TestFixture]
public class Tests
{
    #region Usage

    [Test]
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

    [Test]
    public Task Empty()
    {
        Recording.Start();
        return Verify("Result");
    }

    [Test]
    public Task ScalarValueGuid() =>
        Verify(new ScalarValue(Guid.NewGuid()));

    [Test]
    public Task ForContext()
    {
        Recording.Start();

        var logger = Log.ForContext("key", "value");
        logger.Error("The Message");

        return Verify("Result");
    }

    [Test]
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

    [Test]
    public Task DictionaryValue() =>
        Verify(
            new DictionaryValue(
            [
                new(new(Guid.NewGuid()), new ScalarValue("value"))
            ]));
}