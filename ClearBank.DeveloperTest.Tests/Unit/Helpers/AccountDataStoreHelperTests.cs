using ClearBank.DeveloperTest.Config;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Helpers;
using Moq;
using NUnit.Framework;
using System;

namespace ClearBank.DeveloperTest.Tests.Unit.Helpers
{
    public class AccountDataStoreHelperTests
    {
        [TestCase("Backup", typeof(BackupAccountDataStore))]
        [TestCase("", typeof(AccountDataStore))]
        [TestCase(null, typeof(AccountDataStore))]
        public void GetAccountDataStore_Returns_Expected_AccountDataStore(string dataStoreType, Type expectedType)
        {
            // Arrange
            var dataStoreConfig = new Mock<IAccountDataStoreConfig>();
            dataStoreConfig.SetupGet(a => a.DataStoreType).Returns(dataStoreType);

            // Act
            var accountDataStore = AccountDataStoreHelper.GetAccountDataStore(dataStoreConfig.Object);

            // Assert
            Assert.IsAssignableFrom(expectedType, accountDataStore);
        }
    }
}
