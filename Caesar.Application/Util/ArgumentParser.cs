using Caesar.Application.Extensions;

namespace Caesar.Application.Util;

public static class ArgumentParser
{
    public static Dictionary<string, string?> ExtractNamedArguments(string[] args)
    {
        Dictionary<string, string?> namedArguments = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);

        Dictionary<string, string> namedArgMap = new Dictionary<string, string>
        {
            { "--cipher", "cipher" },
            { "-c", "cipher" },
            { "--shift", "shift" },
            { "-s", "shift" },
            { "--output", "output" },
            { "-o", "output" },
            { "--key", "key" },
            { "-k", "key" }
        };
        for (int i = 2; i < args.Length; i++)
        {
            if (namedArgMap.TryGetValue(args[i], out string? key))
            {
                if (namedArguments.ContainsKey(key))
                {
                    Console.WriteLine($"Error: Duplicate named argument {args[i]}.");
                    Environment.Exit(1);
                }

                if (i + 1 < args.Length)
                {
                    namedArguments[key] = args[i + 1];
                    i++;
                }
                else
                {
                    Console.WriteLine($"Error: No value provided for named argument {args[i]}.");
                    Environment.Exit(1);
                }
            }
            else
            {
                Console.WriteLine($"Error: Invalid named argument {args[i]}.");
                Environment.Exit(1);
            }

        }

        Console.WriteLine("Named arguments:");
        foreach (var (key, value) in namedArguments)
        {
            Console.WriteLine($"{key}: {value}");
        }

        return namedArguments;
    }
}