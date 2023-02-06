public static class ModuleInitializer
{
    #region Enable

    [ModuleInitializer]
    public static void Initialize() =>
        VerifySerilog.Initialize();

    #endregion

    [ModuleInitializer]
    public static void InitializeOther() =>
        VerifierSettings.InitializePlugins();
}