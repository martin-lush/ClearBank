using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using NUnit.Framework;
using System;

namespace ClearBank.DeveloperTest.Tests.Unit.Validators
{
    public class ChapsPaymentSchemeValidatorTests
    {
        private readonly ChapsPaymentSchemeValidator _validator = new ChapsPaymentSchemeValidator();

        private Account _account;
        private MakePaymentRequest _request;

        [SetUp]
        public void Setup()
        {
            _account = new Account();
            _request = new MakePaymentRequest();
        }

        [Test]
        public void ChapsPaymentSchemeValidator_Throws_Exeption_When_Account_is_null()
        {
            _account = null;

            Assert.Throws<ArgumentNullException>(() => _validator.Validate(_account, _request));
        }

        [Test]
        public void ChapsPaymentSchemeValidator_Throws_Exeption_When_MakePaymentRequest_is_null()
        {
            _request = null;

            Assert.Throws<ArgumentNullException>(() => _validator.Validate(_account, _request));
        }

        [Test]
        public void BacsPaymentSchemeValidator_Is_Valid_When_Account_Has_ChapsPaymentScheme_And_Is_Live()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
            _account.Status = AccountStatus.Live;

            var result = _validator.Validate(_account, _request);

            Assert.IsTrue(result);
        }

        [Test]
        public void BacsPaymentSchemeValidator_Is_Not_Valid_When_Account_Is_Missing_ChapsPaymentScheme()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs;
            _account.Status = AccountStatus.Live;

            var result = _validator.Validate(_account, _request);

            Assert.IsFalse(result);
        }

        [Test]
        public void BacsPaymentSchemeValidator_Is_Not_Valid_When_Account_Is_Not_Live()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
            _account.Status = AccountStatus.Disabled;

            var result = _validator.Validate(_account, _request);

            Assert.IsFalse(result);
        }
    }
}
