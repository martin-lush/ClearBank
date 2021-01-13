using System.Configuration;

namespace ClearBank.DeveloperTest.Config
{
    public interface IAccountDataStoreConfig
    {
        string DataStoreType { get; }
    }

    public class AccountDataStoreConfig : IAccountDataStoreConfig
    {
        public string DataStoreType => ConfigurationManager.AppSettings["DataStoreType"];
    }
}
