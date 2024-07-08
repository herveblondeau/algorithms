// https://www.codingame.com/training/easy/encryptiondecryption-of-enigma-machine

namespace Codingame.Easy.EncryptionDecryptionOfEnigmaMachine;

public class EncryptionDecryptionOfEnigmaMachine
{
    private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public string Transform(string operation, string message, string[] rotors, int startingShift)
    {
        if (operation == "ENCODE")
        {
            return _encode(message, rotors, startingShift);
        }
        else
        {
            return _decode(message, rotors, startingShift);
        }
    }

    private string _encode(string message, string[] rotors, int startingShift)
    {
        var result = _applyIncrementalShift(message, startingShift, shiftLeftInsteadOfRight: false);
        for (int i = 0; i < rotors.Length; i++)
        {
            result = _scramble(result, ALPHABET, rotors[i]);
        }

        return result;
    }

    private string _decode(string message, string[] rotors, int startingShift)
    {
        var result = message;
        for (int i = rotors.Length - 1; i >= 0; i--)
        {
            result = _scramble(result, rotors[i], ALPHABET);
        }
        return _applyIncrementalShift(result, startingShift, shiftLeftInsteadOfRight: true);
    }

    private string _applyIncrementalShift(string message, int increment, bool shiftLeftInsteadOfRight)
    {
        char[] result = message.ToCharArray();
        for (int i = 0; i < message.Length; i++)
        {
            result[i] = _rotN(result[i], shiftLeftInsteadOfRight ? -increment : increment);
            increment++;
        }

        return new string(result);
    }

    // Applying and unapplying a rotor are basically the same operation. For each character:
    // - get its position in the input alphabet
    // - get the character at that position in the output alphabet
    // The only difference is that the input and output alphabets are switched
    private string _scramble(string decoded, string inputAlphabet, string outputAlphabet)
    {
        char[] encoded = decoded.ToCharArray();
        for (int i = 0; i < decoded.Length; i++)
        {
            encoded[i] = outputAlphabet[inputAlphabet.IndexOf(decoded[i])];
        }

        return new string(encoded);
    }

    // Rotates a character by 'n' positions
    private char _rotN(char input, int n)
    {
        n = n % 26;
        int target = input + n;
        if (target < 65) target = 90 - (64 - target);
        else if (target > 90) target = 64 + (target - 90);

        return (char)target;
    }

}
