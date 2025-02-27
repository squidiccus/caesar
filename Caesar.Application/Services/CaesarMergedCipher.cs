using System.Text;
using Caesar.Application.Constants;
using Caesar.Application.Model;

namespace Caesar.Application.Services;

public class CaesarMergedCipher : Cipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyzæøåABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ1234567890 ";
    private static readonly int AlphabetCount = Alphabet.Length;
    private static readonly Dictionary<char, int> AlphabetMap = Alphabet.Select((c, i) => (c, i)).ToDictionary(x => x.c, x => x.i);
    public override string Encrypt(Props props)
    {
        Console.WriteLine($"Encrypting using {Args.Caesar} cipher with shift {props.Shift}...");
        StringBuilder sb = new StringBuilder();
        foreach (char c in props.Content)
        {
            if (AlphabetMap.TryGetValue(c, out int lower))
            {
                int index = (lower + props.Shift) % AlphabetCount;
                sb.Append(Alphabet[index]);
            }
            else if (char.IsWhiteSpace(c))
            {
                sb.Append(c);
            }
            else
            {
                throw new ArgumentException($"Invalid character: {c}");
            }
        }

        return sb.ToString();
    }

    public override string Decrypt(Props props)
    {
        Console.WriteLine($"Decrypting using {Args.Caesar} cipher with shift {props.Shift}...");

        StringBuilder sb = new StringBuilder();
        foreach (char c in props.Content)
        {
            if (AlphabetMap.TryGetValue(c, out int lower))
            {
                int index = (lower - props.Shift + AlphabetCount) % AlphabetCount;
                sb.Append(Alphabet[index]);
            }
            else if (char.IsWhiteSpace(c))
            {
                sb.Append(c);
            }
            else
            {
                throw new ArgumentException($"Invalid character: {c}");
            }
        }

        return sb.ToString();
    }
}