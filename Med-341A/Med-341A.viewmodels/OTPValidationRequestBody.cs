using System;

namespace Med_341A.viewmodels;

public class OTPValidationRequestBody
{
    public string Email { get; set; }
    public string? Otp { get; set; }
    public string? usedFor { get; set; }
}
