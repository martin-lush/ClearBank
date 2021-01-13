using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using NUnit.Framework;
using System;

namespace ClearBank.DeveloperTest.Tests.Unit.Data
{
    public class BackupAccountDataStoreTests
    {
        private readonly BackupAccountDataStore _accountDataStore = new BackupAccountDataStore();

        [Test]
        public void GetAccount_Returns_Expected_Account()
        {
            var accountNumber = Guid.NewGuid().ToString("n");

            var account = _accountDataStore.GetAccount(accountNumber);

            Assert.NotNull(account);
            Assert.AreEqual(accountNumber, account.AccountNumber);
        }

        [Test]
        public void UpdateAccount_Persists_Changes_Successfully()
        {
            var account = new Account();
            
            var success = _accountDataStore.UpdateAccount(account);

            Assert.IsTrue(success);
        }
    }
}
