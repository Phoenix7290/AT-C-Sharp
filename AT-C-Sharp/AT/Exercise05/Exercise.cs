using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise05
{
    public class Exercise
    {
        public static void Run()
        {
            DateTime graduationDate = new DateTime(2027, 12, 15);

            Console.Write("Digite a data atual (dia/mês/ano): ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Erro: Data inválida. Insira uma data no formato dia/mês/ano.");
                return;
            }

            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime currentDate))
            {
                if (currentDate > DateTime.Today)
                {
                    Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                    return;
                }

                TimeSpan timeRemaining = graduationDate - currentDate;

                if (timeRemaining.TotalDays < 0)
                {
                    Console.WriteLine("Parabéns! Você já deveria estar formado!");
                    return;
                }
                
                int years = graduationDate.Year - currentDate.Year;
                int months = graduationDate.Month - currentDate.Month + (years * 12);
                int days = graduationDate.Day - currentDate.Day;

                if (days < 0)
                {
                    months--;
                    days += DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                }
                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                years = Math.Max(0, years);
                months = Math.Max(0, months);

                bool isLessThanSixMonths = timeRemaining.TotalDays < 180;

                if (years > 0)
                {
                    Console.WriteLine($"Faltam {years} ano(s), {months} mês(es) e {days} dia(s) para sua formatura!");
                }
                else if (months > 0)
                {
                    Console.WriteLine($"Faltam {months} mês(es) e {days} dia(s) para sua formatura!");
                }
                else
                {
                    Console.WriteLine($"Faltam {days} dia(s) para sua formatura!");
                }

                if (isLessThanSixMonths && timeRemaining.TotalDays >= 0)
                {
                    Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
                }
            }
            else
            {
                Console.WriteLine("Erro: Data inválida. Insira uma data no formato dd/MM/yyyy.");
            }
        }
    }
}