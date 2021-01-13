using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using NUnit.Framework;
using System;

namespace ClearBank.DeveloperTest.Tests.Unit.Validators
{
    public class BacsPaymentSchemeValidatorTests
    {
        private readonly BacsPaymentSchemeValidator _validator = new BacsPaymentSchemeValidator();

        private Account _account;
        private MakePaymentRequest _request;

        [SetUp]
        public void Setup()
        {
            _account = new Account();
            _request = new MakePaymentRequest();
        }

        [Test]
        public void BacsPaymentSchemeValidator_Throws_Exeption_When_Account_is_null()
        {
            _account = null;

            Assert.Throws<ArgumentNullException>(() => _validator.Validate(_account, _request));
        }

        [Test]
        public void BacsPaymentSchemeValidator_Throws_Exeption_When_MakePaymentRequest_is_null()
        {
            _request = null;

            Assert.Throws<ArgumentNullException>(() => _validator.Validate(_account, _request));
        }

        [Test]
        public void BacsPaymentSchemeValidator_Is_Valid_When_Account_Has_BacsPaymentScheme()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs;

            var result = _validator.Validate(_account, _request);

            Assert.IsTrue(result);
        }

        [Test]
        public void BacsPaymentSchemeValidator_Is_Not_Valid_When_Account_Is_Missing_BacsPaymentScheme()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;

            var result = _validator.Validate(_account, _request);

            Assert.IsFalse(result);
        }
    }
}
