using Caesar.Application.Constants;
using Caesar.Application.Extensions;
using Caesar.Application.Model;
using Caesar.Application.Services;

namespace Caesar.Test;

public class TestCaesar
{
    [Fact]
    public void TestSimple()
    {
        // Arrange
        string content = "Hello World";
        string operation = Args.Encrypt;
        int shift = 5;
        Props props = new Props(content, operation)
        {
            CaesarProps = new CaesarProps(shift)
        };
        Cipher service = CipherFactory.Get(Args.Caesar);
        string result = service.DoOperation(props);
        Props decryptedProps = new Props(result, Args.Decrypt)
        {
            CaesarProps = new CaesarProps(shift)
        };
        string decryptedResult = service.DoOperation(decryptedProps);
    }

    [Fact]
    public void TestGiven()
    {
        // Arrange
        string content = """
                         experience is the teacher of all things
                         no one is so brave that he is not disturbed by something unexpected
                         i had rather be first in a village than second at rome
                         men freely believe that which they desire
                         i came i saw i conquered
                         """;
        string expected = """
                          lawlyplujlgpzgæolgælhjolygvmghssgæopunz
                          uvgvulgpzgzvgiyhålgæohægolgpzguvægkpzæøyilkgibgzvtlæopungøulawljælk
                          pgohkgyhæolygilgmpyzægpughgåpsshnlgæohugzljvukghægyvtl
                          tlugmyllsbgilsplålgæohæg opjogæolbgklzpyl
                          pgjhtlgpgzh gpgjvuxølylk
                          """;
        string operation = Args.Encrypt;
        int shift = 7;
        Props props = new Props(content, operation)
        {
            CaesarProps = new CaesarProps(shift)
        };
        Cipher service = CipherFactory.Get(Args.Caesar);
        Assert.Equal(expected, service.DoOperation(props));
    }


}