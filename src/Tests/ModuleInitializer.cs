public static class ModuleInitializer
{
    #region Enable

    [ModuleInitializer]
    public static void Initialize()
    {
        VerifySerilog.Enable();

        #endregion

        VerifyDiffPlex.Initialize();
    }
}