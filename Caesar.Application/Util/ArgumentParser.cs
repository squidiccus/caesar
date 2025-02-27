using Caesar.Application.Extensions;

namespace Caesar.Application.Util;

public static class ArgumentParser
{
    public static Dictionary<string, string> ExtractNamedArguments(string[] args)
    {
        Dictionary<string, string> namedArguments = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        for (int i = 2; i < args.Length; i++)
        {
            string arg = args[i];
            string argName = null;
            string argValue = null;
            bool argumentParsed = false;

            if (arg.StartsWith("--cipher")) // --cipher value format (space separated)
            {
                argName = "cipher";
                if (i + 1 < args.Length)
                {
                    argValue = args[i + 1];
                    i++; // Consume the next argument as the value
                    argumentParsed = true;
                }
                else
                {
                    Console.WriteLine($"Error: Missing value for '--cipher' argument.");
                    Help.PrintUsage();
                    Environment.Exit(1);
                }
            }
            else if (arg.StartsWith("-c")) // -c value format (space separated)
            {
                argName = "cipher";
                if (i + 1 < args.Length)
                {
                    argValue = args[i + 1];
                    i++; // Consume the next argument as the value
                    argumentParsed = true;
                }
                else
                {
                    Console.WriteLine($"Error: Missing value for '-c' argument.");
                    Help.PrintUsage();
                    Environment.Exit(1);
                }
            }
            else if (arg.StartsWith("--shift"))
            {
                argName = "shift";
                if (i + 1 < args.Length)
                {
                    argValue = args[i + 1];
                    i++;
                    argumentParsed = true;
                }
                else
                {
                    Console.WriteLine($"Error: Missing value for '--shift' argument.");
                    Help.PrintUsage();
                    Environment.Exit(1);
                }
            }
            else if (arg.StartsWith("-s"))
            {
                argName = "shift";
                if (i + 1 < args.Length)
                {
                    argValue = args[i + 1];
                    i++;
                    argumentParsed = true;
                }
                else
                {
                    Console.WriteLine($"Error: Missing value for '-s' argument.");
                    Help.PrintUsage();
                    Environment.Exit(1);
                }
            }
            else if (arg.StartsWith("--output"))
            {
                argName = "output";
                if (i + 1 < args.Length)
                {
                    argValue = args[i + 1];
                    i++;
                    argumentParsed = true;
                }
                else
                {
                    Console.WriteLine($"Error: Missing value for '--output' argument.");
                   Help.PrintUsage();
                    Environment.Exit(1);
                }
            }
            else if (arg.StartsWith("-o"))
            {
                argName = "output";
                if (i + 1 < args.Length)
                {
                    argValue = args[i + 1];
                    i++;
                    argumentParsed = true;
                }
                else
                {
                    Console.WriteLine($"Error: Missing value for '-o' argument.");
                    Help.PrintUsage();
                    Environment.Exit(1);
                }
            }


            if (argumentParsed)
            {
                if (namedArguments.ContainsKey(argName))
                {
                    Console.WriteLine($"Error: Duplicate named argument '{argName}' provided.");
                    Help.PrintUsage();
                    Environment.Exit(1);
                }
                namedArguments[argName] = argValue;
            }
            else
            {
                Console.WriteLine($"Error: Unknown argument: '{arg}'. Named arguments should be specified as -c <cipher>, --cipher <cipher>, -s <shift>, -o <outputFilePath> or --output <outputFilePath>.");
                Help.PrintUsage();
                Environment.Exit(1);
            }
        }
        return namedArguments;
    }
}