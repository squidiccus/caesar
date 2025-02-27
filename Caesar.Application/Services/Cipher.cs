using Caesar.Application.Constants;

namespace Caesar.Application.Model;

public abstract class Cipher
{
    public string DoOperation(Props props)
    {
        return props.Operation switch
        {
            Args.Encrypt => Encrypt(props),
            Args.Decrypt => Decrypt(props),
            _ => throw new ArgumentException("Invalid operation")
        };
    }
    public abstract string Encrypt(Props props);

    public abstract string Decrypt(Props props);
}