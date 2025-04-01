using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT_C_Sharp.AT.Exercise07.Class;

namespace AT_C_Sharp.AT.Exercise07
{
    internal class Exercise
    {
        public static void Run()
        {
            ContaBancaria conta = new ContaBancaria("João Silva");

            Console.WriteLine($"Titular: {conta.Titular}\n");

            conta.Depositar(500.00m);
            conta.ExibirSaldo();

            Console.WriteLine("\nTentativa de saque: R$ 700,00");
            conta.Sacar(700.00m); 
            conta.ExibirSaldo();

            Console.WriteLine();
            conta.Sacar(200.00m); 
            conta.ExibirSaldo();

            Console.WriteLine();
            conta.Depositar(-100.00m);
            conta.ExibirSaldo();
        }
    }
}
