using Caesar.Application.Constants;
using Caesar.Application.Model;

namespace Caesar.Application.Services;

public static class CipherFactory
{
    public static Cipher Get(string cipher)
    {
        return cipher switch
        {
            Args.Caesar => new CaesarCipher(),
            Args.CaesarMerged => new CaesarMergedCipher(),
            _ => throw new ArgumentException("Invalid cipher")
        };
    }

}