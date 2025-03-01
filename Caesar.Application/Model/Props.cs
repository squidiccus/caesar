namespace Caesar.Application.Model;

public class Props(string content, string operation)
{
    public string Content { get; } = content;
    public string Operation { get; } = operation;
    public CaesarProps? CaesarProps { get; set; }
    public XorProps? XorProps { get; set; }
}

public class CaesarProps(int shift)
{
    public int Shift { get; } = shift;
}

public class XorProps(string key)
{
    public string Key { get; } = key;
}

