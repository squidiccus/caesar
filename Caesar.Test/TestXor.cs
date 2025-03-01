using Caesar.Application.Constants;
using Caesar.Application.Extensions;
using Caesar.Application.Model;
using Caesar.Application.Services;

namespace Caesar.Test;

public class TestXor
{
    [Fact]
    public void TestSimple()
    {
        // Arrange
        string content = "Hello World";
        string operation = Args.Encrypt;
        string key = "abc";
        Props props = new Props(content, operation)
        {
            XorProps = new XorProps(key)
        };
        Cipher service = CipherFactory.Get(Args.Xor);
        string result = service.DoOperation(props);
        Props decryptedProps = new Props(result, Args.Decrypt)
        {
            XorProps = new XorProps(key)
        };
        string decryptedResult = service.DoOperation(decryptedProps);
    }
}