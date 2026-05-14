[assembly: Parallelizable(ParallelScope.All)]
[assembly: LevelOfParallelism(48)]

public static class ModuleInitializer
{
    #region Enable

    [ModuleInitializer]
    public static void Initialize() =>
        VerifySerilog.Initialize(
            _ => _.Destructure.ByTransforming<Customer>(
                customer => new
                {
                    customer.Name
                }));

    #endregion

    [ModuleInitializer]
    public static void InitializeOther() =>
        VerifierSettings.InitializePlugins();
}
