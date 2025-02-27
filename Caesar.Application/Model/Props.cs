namespace Caesar.Application.Model;

public class Props(string content, string operation, int shift)
{
    public string Content { get; } = content;
    public string Operation { get; } = operation;
    public int Shift { get; } = shift;
}

