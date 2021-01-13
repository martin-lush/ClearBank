using ClearBank.DeveloperTest.Config;
using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Helpers
{
    public static class AccountDataStoreHelper
    {
        public static IAccountDataStore GetAccountDataStore(IAccountDataStoreConfig dataStoreConfig)
        {
            var dataStoreType = dataStoreConfig.DataStoreType;

            switch (dataStoreType)
            {
                // TECH DEBT: Consider using Enums for this
                case "Backup":
                    return new BackupAccountDataStore();
                default:
                    return new AccountDataStore();
            }
        }
    }
}
