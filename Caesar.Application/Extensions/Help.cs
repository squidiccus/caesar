namespace Caesar.Application.Extensions;

public static class Help
{
    public static void PrintUsage()
    {
        string usageText = """
                           Usage: dotnet run -- <inputFilePath> <encrypt|decrypt> [-c <cipher> | --cipher <cipher>] [-s <shift> | --shift <shift>] [-o <outputFilePath> | --output <outputFilePath>]

                           Description:
                             This console application reads the content of an input file,
                             performs either encryption or decryption using a specified cipher,
                             and writes the processed content to either an output file or the console.
                             
                           Cipher Types:
                             - Caesar: Shifts each letter in the input text by a fixed number of positions with separate alphabets for upper and lower case.
                             - Caesar-Merged: Shifts each letter in the input text by a fixed number of positions, 
                               the alphabet is alphanumeric and merges upper, lower and numbers into a single alphabet.
                             - XOR: Encrypts or decrypts the input text using a key and the XOR operation.

                           Arguments:
                             <inputFilePath>      Path to the input file to be processed. Must be a valid file.
                             <encrypt|decrypt>    Specifies the operation to be performed.
                                                  Use 'encrypt' to indicate encryption, or 'decrypt'
                                                  for decryption.
                             [-c <cipher> | --cipher <cipher>]
                                                 Specifies the cipher to use. Currently supported: 'caesar', 'caesar-merged'.
                                                 If not provided, defaults to 'caesar'.
                             [-s <shift> | --shift <shift>]
                                                 (Optional for Caesar cipher) The integer shift value.
                                                 Defaults to 3 if not provided. Must be a non-negative integer.
                             [-o <outputFilePath> | --output <outputFilePath>]
                                                 (Optional) Path to the output file where the processed content will be written.
                                                 If not provided, output will be written to the console.
                             [-h | --help]        Displays this help message.
                             [-k <key> | --key <key>] (Optional for XOR cipher) The key to use for encryption/decryption.
                                                 Must be a string of characters. If not provided, defaults to 'key'.

                           Error Handling:
                             The program provides clear error messages for the following cases:
                               - Missing input filepath or operation arguments
                               - Input file not found
                               - Invalid operation argument (not 'encrypt' or 'decrypt')
                               - Invalid cipher argument (not 'caesar')
                               - Invalid shift value (for Caesar cipher, must be an integer)
                               - Negative shift value
                               - Incorrect or duplicate named arguments
                               - Errors during file reading/writing
                               - Missing value for named arguments (-c, --cipher, -s, --shift, -o, --output)

                           Example:
                             dotnet run -- "input.txt" encrypt -c caesar -o "output.txt"
                             dotnet run -- "input.txt" encrypt -c caesar-merged -s 5
                             dotnet run -- "data.in" decrypt --cipher caesar -s 5
                             dotnet run -- "plain.txt" encrypt
                             dotnet run -- "plain.txt" encrypt -o encrypted.txt
                           """;

        Console.WriteLine(usageText);
    }
}