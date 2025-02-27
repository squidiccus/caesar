using Caesar.Application.Constants;
using Caesar.Application.Extensions;
using Caesar.Application.Model;
using Caesar.Application.Services;
using Caesar.Application.Util;

namespace Caesar.Application;

public static class Program
{
    static void Main(string[] args)
    {
        switch (args.Length)
        {
            case 1 when (args[0] == "-h" || args[0] == "--help"):
                Help.PrintUsage();
                return;
            // Minimum arguments: inputFilePath, operation
            case < 2:
                Console.WriteLine("Error: Invalid number of arguments. Input filepath and operation are required.");
                Help.PrintUsage();
                return;
        }

        string inputFilePath = args[0]; // Input filepath is positional, first argument
        string operation = args[1].ToLower(); // Operation is positional, second argument
        string cipher = "caesar"; // Default cipher is caesar if not specified
        int shiftValue = 3; // Default Caesar shift value
        string? outputFilePath = null; // Output filepath is initially null, meaning output to console

        Dictionary<string, string> namedArguments = ArgumentParser.ExtractNamedArguments(args);

        if (namedArguments.TryGetValue(Args.Cipher, out string? argument))
        {
            cipher = argument.ToLower();
        }

        if (namedArguments.TryGetValue(Args.Shift, out string? namedArgument))
        {
            if (int.TryParse(namedArgument, out int parsedShiftValue))
            {
                shiftValue = parsedShiftValue;
            }
            else
            {
                Console.WriteLine("Error: Invalid shift value provided in named argument. Must be an integer.");
                Help.PrintUsage();
                return;
            }
        }

        if (namedArguments.TryGetValue("output", out string? argument1))
        {
            outputFilePath = argument1;
        }

        if (ArgsInvalid(inputFilePath, operation, cipher, shiftValue))
        {
            return;
        }

        string processedContent = string.Empty; // To store encrypted/decrypted content

        try
        {
            string content = File.ReadAllText(inputFilePath);
            Console.WriteLine($"File content read successfully from: {inputFilePath}");
            Console.WriteLine($"Operation: {operation}");
            Console.WriteLine($"Cipher: {cipher}");
            Cipher cipherService = CipherFactory.Get(cipher);
            processedContent = cipherService.DoOperation(new Props(content, operation, shiftValue));

            if (outputFilePath != null)
            {
                File.WriteAllText(outputFilePath, processedContent);
                Console.WriteLine($"Processed content written to file: {outputFilePath}");
            }
            else
            {
                Console.WriteLine($"Processed Content:\n{processedContent}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file: {ex.Message}");
            Console.WriteLine("Stack Trace:");
            Console.WriteLine(ex.StackTrace);
        }
    }

    private static bool ArgsInvalid(string inputFilePath, string operation, string cipher, int shiftValue)
    {
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Error: Input file not found at path: {inputFilePath}");
            return true;
        }

        if (!operation.IsValidOperation())
        {
            Console.WriteLine($"Error: Invalid operation argument: '{operation}'.");
            Console.WriteLine("Operation argument must be either 'encrypt' or 'decrypt'.");
            Help.PrintUsage();
            return true;
        }

        if (!cipher.IsValidCipher())
        {
            Console.WriteLine($"Error: Invalid cipher argument: '{cipher}'.");
            Console.WriteLine("Cipher argument must be.");
            Help.PrintUsage();
            return true;
        }

        if ((cipher == Args.Caesar || cipher == Args.CaesarMerged) && shiftValue < 0)
        {
            Console.WriteLine("Error: Shift value must be a non-negative integer.");
            Help.PrintUsage();
            return true;
        }

        return false;
    }
}