using Caesar.Application.Constants;
using Caesar.Application.Extensions;
using Caesar.Application.Model;
using Caesar.Application.Services;

namespace Caesar.Test;

public class TestCaesarMerged
{
    [Fact]
    public void TestSimple()
    {
        // Arrange
        const string content = "Hello Worldvæåoaufnvoadnsfv089u92384towiu890qp84759038";
        const string operation = Args.Encrypt;
        const int shift = 5;
        Props props = new Props(content, operation, shift);
        Cipher service = CipherFactory.Get(Args.CaesarMerged);
        string result = service.DoOperation(props);
        Props decryptedProps = new Props(result, Args.Decrypt, shift);
        string decryptedResult = service.DoOperation(decryptedProps);
    }
}