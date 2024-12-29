namespace Infrastructure
{
    public static class Constants
    {
        public static string aWorkDir =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "EOS", "Tests");

        public static string dtbaseFile = Path.Combine(aWorkDir, "workFolder\\KBData.db");
        public static string lockedFile = Path.Combine(aWorkDir, "Tests.aaa");
        public static string packedFile = Path.Combine(aWorkDir, "Tests.pax");
        public static string workFolder = Path.Combine(aWorkDir, "workFolder\\");
    }
}
