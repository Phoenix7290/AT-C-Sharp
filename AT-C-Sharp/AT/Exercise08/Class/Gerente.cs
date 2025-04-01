using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise08.Class
{
    public class Gerente : Funcionario
    {
        private const decimal Bonus = 0.20m; 

        public Gerente(string nome, decimal salarioBase)
            : base(nome, "Gerente", salarioBase) { }

        public override decimal CalcularSalario()
        {
            return SalarioBase * (1 + Bonus); 
        }
    }
}
