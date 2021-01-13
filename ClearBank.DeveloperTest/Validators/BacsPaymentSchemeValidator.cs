using ClearBank.DeveloperTest.Types;
using System;

namespace ClearBank.DeveloperTest.Validators
{
    public class BacsPaymentSchemeValidator : IPaymentSchemeValidator
    {
        public bool Validate(Account account, MakePaymentRequest makePaymentRequest)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else if (makePaymentRequest is null)
            {
                throw new ArgumentNullException(nameof(makePaymentRequest));
            }

            return IsAccountValidForPaymentScheme(account);
        }

        private static bool IsAccountValidForPaymentScheme(Account account)
        {
            return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs);
        }
    }
}
