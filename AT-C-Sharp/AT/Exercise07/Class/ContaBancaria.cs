using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise07.Class
{
    public class ContaBancaria
    {
        public string Titular { get; private set; }
        private decimal saldo;

        public ContaBancaria(string titular, decimal saldoInicial = 0)
        {
            Titular = titular;
            saldo = saldoInicial >= 0 ? saldoInicial : 0; 
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("O valor do depósito deve ser positivo!");
                return;
            }

            saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("O valor do saque deve ser positivo!");
                return;
            }

            if (valor > saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
                return;
            }

            saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual: R$ {saldo:F2}");
        }
    }
}
