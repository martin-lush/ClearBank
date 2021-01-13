﻿using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public interface IPaymentSchemeValidator
    {
        bool Validate(Account account, MakePaymentRequest makePaymentRequest);
    }
}