using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise02
{
    internal class Exercise
    {
        public static void Run()
        {
            Console.WriteLine("Digite seu nome completo:");
            string input = Console.ReadLine() ?? string.Empty;

            string result = ShiftLetters(input);
            Console.WriteLine($"Resultado: {result}");
        }

        private static string ShiftLetters(string input)
        {
            char[] shiftedArray = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (char.IsLetter(currentChar))
                {
                    char shiftedChar = ShiftChar(currentChar, 2);
                    shiftedArray[i] = shiftedChar;
                }
                else
                {
                    shiftedArray[i] = currentChar;
                }
            }

            return new string(shiftedArray);
        }

        private static char ShiftChar(char c, int shift)
        {
            if (char.IsLower(c))
            {
                return (char)(((c - 'a' + shift) % 26) + 'a');
            }
            else if (char.IsUpper(c))
            {
                return (char)(((c - 'A' + shift) % 26) + 'A');
            }
            else
            {
                return c;
            }
        }
    }
}
