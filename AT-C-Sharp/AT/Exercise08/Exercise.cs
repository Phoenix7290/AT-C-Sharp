using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT_C_Sharp.AT.Exercise08.Class;

namespace AT_C_Sharp.AT.Exercise08
{
    internal class Exercise
    {
        public static void Run()
        {
            Funcionario funcionario = new Funcionario("Carlos Silva", "Desenvolvedor", 3000.00m);
            Console.WriteLine("Dados do Funcionário:");
            funcionario.ExibirDados();

            Console.WriteLine("\n-----------------------------\n");

            Gerente gerente = new Gerente("Ana Souza", 5000.00m);
            Console.WriteLine("Dados do Gerente:");
            gerente.ExibirDados();
        }
    }
}
