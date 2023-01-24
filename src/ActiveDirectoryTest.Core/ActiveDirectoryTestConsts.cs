using ActiveDirectoryTest.Debugging;

namespace ActiveDirectoryTest
{
    public class ActiveDirectoryTestConsts
    {
        public const string LocalizationSourceName = "ActiveDirectoryTest";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "04fa99823f82484cad2da6a60932a294";
    }
}
