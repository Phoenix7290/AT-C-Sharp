using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise08.Class
{
    public class Funcionario
    {
        public string Nome { get; private set; }
        public string Cargo { get; private set; }
        protected decimal SalarioBase;

        public Funcionario(string nome, string cargo, decimal salarioBase)
        {
            Nome = nome;
            Cargo = cargo;
            SalarioBase = salarioBase >= 0 ? salarioBase : 0;
        }

        public virtual decimal CalcularSalario()
        {
            return SalarioBase;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salário: R$ {CalcularSalario():F2}");
        }
    }
}
