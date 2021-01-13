using ClearBank.DeveloperTest.Helpers;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using NUnit.Framework;
using System;

namespace ClearBank.DeveloperTest.Tests.Unit.Helpers
{
    public class PaymentSchemeValidatorHelperTests
    {
        [TestCase(PaymentScheme.Bacs, typeof(BacsPaymentSchemeValidator))]
        [TestCase(PaymentScheme.Chaps, typeof(ChapsPaymentSchemeValidator))]
        [TestCase(PaymentScheme.FasterPayments, typeof(FasterPaymentsPaymentSchemeValidator))]
        public void GetGetValidatorForPaymentScheme_Returns_Expected_Validator(PaymentScheme paymentScheme, Type expectedType)
        {
            // Act
            var validator = PaymentSchemeValidatorHelper.GetValidatorForPaymentScheme(paymentScheme);

            // Assert
            Assert.IsAssignableFrom(expectedType, validator);
        }
    }
}
