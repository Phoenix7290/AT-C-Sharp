using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise03
{
    internal class Exercise
    {
        public static void Run()
        {
            // Os comentários foram requisitados na questãp. Portanto farei alguns comentários.

            // Executa a calculadora.
            Console.WriteLine("Escolha a Operação Matemática: " +
                "\n 1 = Soma " +
                "\n 2 = Subtração " +
                "\n 3 = Multiplicação " +
                "\n 4 = Divisão ");

            string? operationOption = Console.ReadLine();

            // Verifica se a opção é válida.
            if (operationOption != null)
            {
                double number1 = GetNumber("Digite o primeiro número: ");
                double number2 = GetNumber("Digite o segundo número: ");

                double result = operationOption switch
                {
                    "1" => Add(number1, number2),
                    "2" => Subtract(number1, number2),
                    "3" => Multiply(number1, number2),
                    "4" => Divide(number1, number2),
                    _ => double.NaN
                };

                if (double.IsNaN(result))
                {
                    Console.WriteLine("Opção inválida");
                }
                else
                {
                    Console.WriteLine($"Resultado: {result}");
                }
            }
        }

        // Método para obter um número do usuário.
        private static double GetNumber(string prompt)
        {
            Console.WriteLine(prompt);
            return Convert.ToDouble(Console.ReadLine());
        }

        // Todas as operações matemáticas.
        private static double Add(double a, double b) => a + b;

        private static double Subtract(double a, double b) => a - b;

        private static double Multiply(double a, double b) => a * b;

        private static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Erro: Divisão por zero.");
                return double.NaN;
            }
            return a / b;
        }
    }
}
