public static class ModuleInitializer
{
    #region Enable

    [ModuleInitializer]
    public static void Initialize() =>
        VerifySerilog.Enable();

    #endregion

    [ModuleInitializer]
    public static void InitializeOther() =>
        VerifySerilog.Enable();
}