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
        if (props.CaesarProps == null)
        {
            throw new ArgumentException("CaesarProps is null");
        }

        Console.WriteLine($"Encrypting using {Args.Caesar} cipher with shift {props.CaesarProps.Shift}...");
        StringBuilder sb = new StringBuilder();
        foreach (char c in props.Content)
        {
            Console.WriteLine($"Encrypting {c}");
            if (AlphabetMap.TryGetValue(c, out int lower))
            {
                int index = (lower + props.CaesarProps.Shift) % AlphabetCount;
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
        if (props.CaesarProps == null)
        {
            throw new ArgumentException("CaesarProps is null");
        }

        Console.WriteLine($"Decrypting using {Args.Caesar} cipher with CaesarProps.Shift {props.CaesarProps.Shift}...");

        Console.WriteLine(props.Content);

        StringBuilder sb = new StringBuilder();
        foreach (char c in props.Content)
        {
            Console.WriteLine($"Decrypting {c}");
            if (AlphabetMap.TryGetValue(c, out int lower))
            {
                int index = (lower - props.CaesarProps.Shift + AlphabetCount) % AlphabetCount;
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