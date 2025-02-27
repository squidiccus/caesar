using Caesar.Application.Constants;
using Caesar.Application.Model;

namespace Caesar.Application.Extensions;

public static class ArgumentValidationExtensions
{
    public static bool IsValidOperation(this string op)
    {
        return op == Args.Decrypt || op == Args.Encrypt;
    }

    public static bool IsValidCipher(this string cipher)
    {
        return cipher is Args.Caesar or Args.CaesarMerged;
    }
}