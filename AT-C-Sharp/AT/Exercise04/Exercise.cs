using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise04
{
    public class Exercise
    {
        public static void Run()
        {
            Console.Write("Digite sua data de nascimento (dia/mês/ano): ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Data inválida. Por favor, insira uma data no formato dia/mês/ano.");
                return;
            }

            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
            {
                DateTime today = DateTime.Today;
                DateTime nextBirthday = GetNextBirthday(birthDate, today);

                int daysUntilBirthday = (nextBirthday - today).Days;

                Console.WriteLine($"Faltam {daysUntilBirthday} dias para seu próximo aniversário.");
                if (daysUntilBirthday < 7 && daysUntilBirthday >= 0)
                {
                    Console.WriteLine("Falta pouco! Seu aniversário está a menos de uma semana!");
                }
            }
            else
            {
                Console.WriteLine("Data inválida. Por favor, insira uma data no formato dia/mês/ano.");
            }
        }

        private static DateTime GetNextBirthday(DateTime birthDate, DateTime today)
        {
            int year = today.Year;
            int day = birthDate.Day;
            if (birthDate.Month == 2 && birthDate.Day == 29 && !DateTime.IsLeapYear(year))
            {
                day = 28;
            }

            DateTime nextBirthday;
            try
            {
                nextBirthday = new DateTime(year, birthDate.Month, day);
            }
            catch (ArgumentOutOfRangeException)
            {
                nextBirthday = new DateTime(year, birthDate.Month, 28); 
            }

            if (nextBirthday < today)
            {
                year++;
                if (birthDate.Month == 2 && birthDate.Day == 29 && !DateTime.IsLeapYear(year))
                {
                    day = 28;
                }
                nextBirthday = new DateTime(year, birthDate.Month, day);
            }

            return nextBirthday;
        }
    }
}