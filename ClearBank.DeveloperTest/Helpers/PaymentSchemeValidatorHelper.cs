using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Helpers
{
    public static class PaymentSchemeValidatorHelper
    {
        public static IPaymentSchemeValidator GetValidatorForPaymentScheme(PaymentScheme paymentScheme)
        {
            switch (paymentScheme)
            {
                case PaymentScheme.Bacs:
                    return new BacsPaymentSchemeValidator();
                case PaymentScheme.FasterPayments:
                    return new FasterPaymentsPaymentSchemeValidator();
                case PaymentScheme.Chaps:
                    return new ChapsPaymentSchemeValidator();
                default:
                    return null;
            }
        }
    }
}
