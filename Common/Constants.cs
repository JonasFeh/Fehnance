namespace Common
{
    public static class Constants
    {
        public static class Data
        {
            public static string DefaultPath => Environment.ExpandEnvironmentVariables("%APPDATA%/Fehnance/");

            public static string FileNameBankActivities => "BankActivities";
            public static string FileNameBalance => "Balance";
        }
    }
}
