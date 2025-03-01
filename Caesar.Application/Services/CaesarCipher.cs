using System.Text;
using Caesar.Application.Constants;
using Caesar.Application.Model;

namespace Caesar.Application.Services;

public class CaesarCipher : Cipher
{
    private const string AlphabetLower = "abcdefghijklmnopqrstuvwxyzæøå ";
    private static readonly string AlphabetUpper = AlphabetLower.ToUpper();
    private static readonly int AlphabetCount = AlphabetUpper.Length;
    private static readonly Dictionary<char, int> AlphabetUpperMap = AlphabetUpper.Select((c, i) => (c, i)).ToDictionary(x => x.c, x => x.i);
    private static readonly Dictionary<char, int> AlphabetLowerMap = AlphabetLower.Select((c, i) => (c, i)).ToDictionary(x => x.c, x => x.i);
    public override string Encrypt(Props props)
    {
        if (props.CaesarProps == null)
        {
            throw new ArgumentException("CaesarProps is null");
        }
        int shift = props.CaesarProps.Shift % AlphabetCount;

        if (shift < 0)
        {
            shift += AlphabetCount;
        }

        Console.WriteLine($"Encrypting using {Args.Caesar} cipher with shift {props.CaesarProps.Shift} {shift}...");
        StringBuilder sb = new StringBuilder();
        foreach (char c in props.Content)
        {
            if (AlphabetLowerMap.TryGetValue(c, out int lower))
            {
                int index = (lower + shift) % AlphabetCount;
                sb.Append(AlphabetLower[index]);
            }
            else if (AlphabetUpperMap.TryGetValue(c, out int upper))
            {
                int index = (upper + shift) % AlphabetCount;
                sb.Append(AlphabetUpper[index]);
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

        int shift = props.CaesarProps.Shift % AlphabetCount;

        if (shift < 0)
        {
            shift += AlphabetCount;
        }

        Console.WriteLine($"Decrypting using {Args.Caesar} cipher with shift {props.CaesarProps.Shift} {shift}...");


        StringBuilder sb = new StringBuilder();
        foreach (char c in props.Content)
        {
            if (AlphabetLowerMap.TryGetValue(c, out int lower))
            {
                int index = (lower - shift + AlphabetCount) % AlphabetCount;
                sb.Append(AlphabetLower[index]);
            }
            else if (AlphabetUpperMap.TryGetValue(c, out int upper))
            {
                int index = (upper - shift + AlphabetCount) % AlphabetCount;
                sb.Append(AlphabetUpper[index]);
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
