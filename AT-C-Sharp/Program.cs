using System;

namespace TP_C_
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                string? exerciseChoice = GetUserInput("Escolha o Exercício (1-12) ou 'exit' para encerrar:");
                if (exerciseChoice == null || exerciseChoice.ToLower() == "exit")
                {
                    Console.WriteLine("Encerrando o programa.");
                    break;
                }

                if (int.TryParse(exerciseChoice, out int exerciseNumber) && exerciseNumber >= 1 && exerciseNumber <= 12)
                {
                    RunExercise(exerciseNumber);
                }
                else
                {
                    Console.WriteLine("Escolha de exercício inválida.");
                }
            }
        }

        static string? GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        static void RunExercise(int exerciseNumber)
        {
            switch (exerciseNumber)
            {
                case 1:
                    AT_C_Sharp.AT.Exercise01.Exercise.Run();
                    break;
                case 2:
                    AT_C_Sharp.AT.Exercise02.Exercise.Run();
                    break;
                case 3:
                    AT_C_Sharp.AT.Exercise03.Exercise.Run();
                    break;
                case 4:
                    AT_C_Sharp.AT.Exercise04.Exercise.Run();
                    break;
                case 5:
                    AT_C_Sharp.AT.Exercise05.Exercise.Run();
                    break;
                case 6:
                    AT_C_Sharp.AT.Exercise06.Exercise.Run();
                    break;
                case 7:
                    AT_C_Sharp.AT.Exercise07.Exercise.Run();
                    break;
                case 8:
                    AT_C_Sharp.AT.Exercise08.Exercise.Run();
                    break;
                case 9:
                    AT_C_Sharp.AT.Exercise09.Exercise.Run();
                    break;
                case 10:
                    AT_C_Sharp.AT.Exercise10.Exercise.Run();
                    break;
                case 11:
                    AT_C_Sharp.AT.Exercise11.Exercise.Run();
                    break;
                case 12:
                    AT_C_Sharp.AT.Exercise12.Exercise.Run();
                    break;
                default:
                    Console.WriteLine("Escolha de exercício inválida.");
                    break;
            }
        }
    }
}