using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise01
{
    internal class Exercise
    {
        public static void Run()
        {
            // Houve a Troca do método Main para Run para fins de padronização
            String name = "Marcos Ryan";
            DateTime birthDate = new DateTime(2006, 6, 12);

            Console.WriteLine($"Olá, meu nome é {name}");
            Console.WriteLine($"Nasci em {birthDate:dd/MM/yyyy} e estou aprendendo C#!");
        }
    }
}
