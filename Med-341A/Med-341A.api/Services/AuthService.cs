using Microsoft.AspNetCore.Identity;

namespace Med_341A.api.Services;

public class AuthService
{
    private readonly PasswordHasher<string> _passwordHasher;

    public AuthService()
    {
        _passwordHasher = new PasswordHasher<string>();
    }

    // hashing password utils
    public string HashPassword(string plainPassword)
    {
        var hashedPassword = _passwordHasher.HashPassword("secret", plainPassword);

        return hashedPassword;
    }

    public bool VerifyPassword(string HashedPassword, string PlainPassword)
    {
        // Verifikasi password
        var result = _passwordHasher.VerifyHashedPassword("secret", HashedPassword, PlainPassword);

        return result == PasswordVerificationResult.Success;
    }
}
