using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise10
{
    public class Exercise
    {
        public static void Run()
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 51);
            int remainingAttempts = 5;

            Console.WriteLine("Bem-vindo ao Jogo de Adivinhação!");
            Console.WriteLine("Tente adivinhar um número entre 1 e 50. Você tem 5 tentativas.");

            while (remainingAttempts > 0)
            {
                Console.Write($"\nTentativas restantes: {remainingAttempts}. Digite seu palpite: ");
                try
                {
                    string? input = Console.ReadLine();
                    if (!int.TryParse(input, out int guess))
                    {
                        Console.WriteLine("Erro: Digite um número válido!");
                        continue;
                    }

                    if (guess < 1 || guess > 50)
                    {
                        Console.WriteLine("Erro: O número deve estar entre 1 e 50!");
                        continue;
                    }

                    remainingAttempts--;

                    if (guess == secretNumber)
                    {
                        Console.WriteLine($"Parabéns! Você acertou o número {secretNumber}!");
                        return;
                    }
                    else if (guess < secretNumber)
                    {
                        Console.WriteLine("Dica: O número secreto é maior!");
                    }
                    else
                    {
                        Console.WriteLine("Dica: O número secreto é menor!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                    continue;
                }
            }

            Console.WriteLine($"\nGame Over! O número secreto era {secretNumber}.");
        }
    }
}
