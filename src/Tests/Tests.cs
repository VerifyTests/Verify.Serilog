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

    [Test]
    public Task IgnoreMemberInDictionaryValue()
    {
        Recording.Start();
        Log.Information(
            "{@Data}",
            new Dictionary<string, object>
            {
                ["Visible"] = "ok",
                ["Secret"] = "hideme"
            });
        return Verify("Result")
            .IgnoreMember("Secret");
    }

    [Test]
    public Task IgnoreMemberInStructure()
    {
        Recording.Start();
        Log.Information(
            "{@Data}",
            new
            {
                Visible = "ok",
                Secret = "hideme"
            });
        return Verify("Result")
            .IgnoreMember("Secret");
    }

    [Test]
    public Task ScrubMemberInDictionaryValue()
    {
        Recording.Start();
        Log.Information(
            "{@Data}",
            new Dictionary<string, object>
            {
                ["Visible"] = "ok",
                ["Secret"] = "hideme"
            });
        return Verify("Result")
            .ScrubMember("Secret");
    }

    [Test]
    public Task ScrubMemberInStructure()
    {
        Recording.Start();
        Log.Information(
            "{@Data}",
            new
            {
                Visible = "ok",
                Secret = "hideme"
            });
        return Verify("Result")
            .ScrubMember("Secret");
    }

    #region CustomUsage

    [Test]
    public Task Custom()
    {
        Recording.Start();
        Log.Information(
            "Saw customer {@Customer}",
            new Customer("Bob", "secret"));
        return Verify("Result");
    }

    #endregion

    [Test]
    public Task IgnoreMemberInPropertyEnricher() =>
        Verify(new PropertyEnricher("Secret", "hideme"))
            .IgnoreMember("Secret");

    [Test]
    public Task ScrubMemberInPropertyEnricher() =>
        Verify(new PropertyEnricher("Secret", "hideme"))
            .ScrubMember("Secret");
}