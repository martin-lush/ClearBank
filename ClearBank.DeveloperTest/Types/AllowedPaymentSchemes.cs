using System;

namespace ClearBank.DeveloperTest.Types
{
    [Flags] // Note: This was missing. Seems appropriate that an Account would have more than one scheme allowed
    public enum AllowedPaymentSchemes
    {
        FasterPayments = 1 << 0,
        Bacs = 1 << 1,
        Chaps = 1 << 2
    }
}
