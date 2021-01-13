using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using NUnit.Framework;
using System;

namespace ClearBank.DeveloperTest.Tests.Unit.Services
{
    public class PaymentServiceTests
    {
        private Mock<IAccountDataStore> _accountDataStore;
        private PaymentService _paymentService;

        [SetUp]
        public void SetUp()
        {
            _accountDataStore = new Mock<IAccountDataStore>();
            _paymentService = new PaymentService(_accountDataStore.Object);
        }

        [Test]
        public void MakePayment_When_Request_Is_Null_Throws_Exception()
        {
            var request = default(MakePaymentRequest);

            Assert.Throws<ArgumentNullException>(() => _paymentService.MakePayment(request));
        }

        [Test]
        public void MakePayment_When_Request_Is_Valid_Returns_Success()
        {
            var account = new Account
            {
                AccountNumber = Guid.NewGuid().ToString("n"),
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };

            _accountDataStore.Setup(x => x.GetAccount(account.AccountNumber)).Returns(account);
            _accountDataStore.Setup(x => x.UpdateAccount(account)).Returns(true);

            var request = new MakePaymentRequest 
            { 
                DebtorAccountNumber = account.AccountNumber,
                PaymentScheme = PaymentScheme.Bacs
            };

            var result = _paymentService.MakePayment(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);

            _accountDataStore.Verify(m => m.UpdateAccount(account), Times.Once);
        }

        [Test]
        public void MakePayment_When_Account_Not_Found_Returns_Failure()
        {
            var accountNumber = Guid.NewGuid().ToString("n");

            _accountDataStore.Setup(x => x.GetAccount(accountNumber)).Returns(default(Account));

            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = accountNumber,
                PaymentScheme = PaymentScheme.Bacs
            };

            var result = _paymentService.MakePayment(request);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);

            _accountDataStore.Verify(m => m.UpdateAccount(It.IsAny<Account>()), Times.Never);
        }

        [Test]
        public void MakePayment_When_Unable_To_Update_Account_Returns_Failure()
        {
            var account = new Account
            {
                AccountNumber = Guid.NewGuid().ToString("n"),
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };

            _accountDataStore.Setup(x => x.GetAccount(account.AccountNumber)).Returns(account);
            _accountDataStore.Setup(x => x.UpdateAccount(account)).Returns(false);

            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = account.AccountNumber,
                PaymentScheme = PaymentScheme.Bacs
            };

            var result = _paymentService.MakePayment(request);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);

            _accountDataStore.Verify(m => m.UpdateAccount(account), Times.Once);
        }
    }
}
