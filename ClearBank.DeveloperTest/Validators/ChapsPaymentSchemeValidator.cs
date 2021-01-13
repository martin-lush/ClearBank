using ClearBank.DeveloperTest.Types;
using System;

namespace ClearBank.DeveloperTest.Validators
{
    public class ChapsPaymentSchemeValidator : IPaymentSchemeValidator
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

            return IsAccountValidForPaymentScheme(account) && IsAccountLive(account);
        }

        private static bool IsAccountValidForPaymentScheme(Account account)
        {
            return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps);
        }

        private static bool IsAccountLive(Account account)
        {
            return account.Status == AccountStatus.Live;
        }
    }
}
