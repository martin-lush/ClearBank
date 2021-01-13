using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using NUnit.Framework;
using System;

namespace ClearBank.DeveloperTest.Tests.Unit.Validators
{
    public class FasterPaymentsPaymentSchemeValidatorTests
    {
        private readonly FasterPaymentsPaymentSchemeValidator _validator = new FasterPaymentsPaymentSchemeValidator();

        private Account _account;
        private MakePaymentRequest _request;

        [SetUp]
        public void Setup()
        {
            _account = new Account();
            _request = new MakePaymentRequest();
        }

        [Test]
        public void FasterPaymentsPaymentSchemeValidator_Throws_Exeption_When_Account_is_null()
        {
            _account = null;

            Assert.Throws<ArgumentNullException>(() => _validator.Validate(_account, _request));
        }

        [Test]
        public void FasterPaymentsPaymentSchemeValidator_Throws_Exeption_When_MakePaymentRequest_is_null()
        {
            _request = null;

            Assert.Throws<ArgumentNullException>(() => _validator.Validate(_account, _request));
        }

        [Test]
        public void FasterPaymentsPaymentSchemeValidator_Is_Valid_When_Account_Has_FasterPaymentsPaymentScheme_And_Has_Suffient_Funds()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;
            _account.Balance = int.MaxValue;

            var result = _validator.Validate(_account, _request);

            Assert.IsTrue(result);
        }

        [Test]
        public void FasterPaymentsPaymentSchemeValidator_Is_Not_Valid_When_Account_Is_Missing_FasterPaymentsPaymentScheme()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs;
            _account.Balance = int.MaxValue;

            var result = _validator.Validate(_account, _request);

            Assert.IsFalse(result);
        }

        [Test]
        public void FasterPaymentsPaymentSchemeValidator_Is_Not_Valid_When_Account_Does_Not_Have_Suffient_Funds()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;
            _account.Balance = int.MinValue;

            var result = _validator.Validate(_account, _request);

            Assert.IsFalse(result);
        }
    }
}
