using System.Text;
using Caesar.Application.Constants;
using Caesar.Application.Model;

namespace Caesar.Application.Services;

public class XorCipher : Cipher
{
    public override string Encrypt(Props props)
    {
        ValidateProps(props);

        string key = props.XorProps!.Key;
        Console.WriteLine($"Encrypting using {Args.Xor} cipher with key {key}...");

        StringBuilder sb = new StringBuilder();
        KeyIterator keyIterator = new KeyIterator(key);
        foreach (char c in props.Content)
        {
            char keyChar = keyIterator.Next();
            char encryptedChar = (char)(c ^ keyChar);
            sb.Append(encryptedChar);
        }

        return sb.ToString();
    }

    public override string Decrypt(Props props)
    {
        ValidateProps(props);
        string key = props.XorProps!.Key;

        Console.WriteLine($"Decrypting using {Args.Xor} cipher with shift {key}...");

        StringBuilder sb = new StringBuilder();
        KeyIterator keyIterator = new KeyIterator(key);

        foreach (char c in props.Content)
        {
            char keyChar = keyIterator.Next();
            char decryptedChar = (char)(c ^ keyChar);
            sb.Append(decryptedChar);
        }

        return sb.ToString();
    }

    private void ValidateProps(Props props)
    {
        if (props.XorProps == null)
        {
            throw new ArgumentException("XorProps is null");
        }

        if (props.XorProps.Key == null)
        {
            throw new ArgumentException("Key is null");
        }

        if (props.XorProps.Key.Length == 0)
        {
            throw new ArgumentException("Key is empty");
        }
    }

    private class KeyIterator(string key)
    {
        private int _index = -1;
        public char Next()
        {
            _index++;

            if (_index == key.Length)
            {
                _index = 0;
            }

            return key[_index];
        }
    }
}