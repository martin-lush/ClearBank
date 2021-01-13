using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
    public interface IAccountDataStore
    {
        Account GetAccount(string accountNumber);
        bool UpdateAccount(Account account); // NOTE: I change this from void to bool as we should be checking the update has persisted correctly
    }
}