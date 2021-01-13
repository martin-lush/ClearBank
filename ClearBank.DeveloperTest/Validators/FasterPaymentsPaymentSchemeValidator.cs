using ClearBank.DeveloperTest.Types;
using System;

namespace ClearBank.DeveloperTest.Validators
{
    public class FasterPaymentsPaymentSchemeValidator : IPaymentSchemeValidator
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

            return IsAccountValidForPaymentScheme(account) && HasAccountGotSuffientFunds(account, makePaymentRequest.Amount);
        }

        private static bool IsAccountValidForPaymentScheme(Account account)
        {
            return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments);
        }

        private static bool HasAccountGotSuffientFunds(Account account, decimal amountToWithdraw)
        {
            return account.Balance >= amountToWithdraw;
        }
    }
}
