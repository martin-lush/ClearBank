using ClearBank.DeveloperTest.Config;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Helpers;
using ClearBank.DeveloperTest.Types;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStore _accountDataStore;

        public PaymentService(IAccountDataStore accountDataStore)
        {
            // NOTE: This would typically be controlled via a Dependency Injection framework
            if (accountDataStore is null)
            {
                var config = new AccountDataStoreConfig();
                accountDataStore = AccountDataStoreHelper.GetAccountDataStore(config);
            }

            _accountDataStore = accountDataStore;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var result = new MakePaymentResult { Success = false };

            var account = _accountDataStore.GetAccount(request.DebtorAccountNumber);
            var paymentSchemeValidator = PaymentSchemeValidatorHelper.GetValidatorForPaymentScheme(request.PaymentScheme);

            var isValidPaymentRequest = false;

            if (account != null && paymentSchemeValidator != null)
            {
                isValidPaymentRequest = paymentSchemeValidator.Validate(account, request);

                // NOTE: Other validation missing such as:
                // * PaymentDate is in an acceptable range
                // * Amount is in an acceptable range

                // Note: Other considerations include returning the reasons why validation fail in the result
            }

            if (isValidPaymentRequest)
            {
                // NOTE: At this point we have not checked the Creditor Account
                // An assumption is made here that this would be external to this system.
                // In reality we'd have an API call, orchestrator or reconciliation process to handle things.
                account.Balance -= request.Amount;

                if (_accountDataStore.UpdateAccount(account))
                {
                    result = new MakePaymentResult { Success = true };
                }
            }

            return result;
        }
    }
}
