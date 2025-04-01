using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT_C_Sharp.AT.Exercise06.Class;

namespace AT_C_Sharp.AT.Exercise06
{
    internal class Exercise
    {
        public static void Run()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine() ?? "Sem nome";

            Console.Write("Digite sua matrícula: ");
            string matricula = Console.ReadLine() ?? "Sem matrícula";

            Console.Write("Digite seu curso: ");
            string curso = Console.ReadLine() ?? "Sem curso";

            Console.Write("Digite sua média das notas (0 a 10): ");
            double mediaNotas;
            while (!double.TryParse(Console.ReadLine(), out mediaNotas) || mediaNotas < 0 || mediaNotas > 10)
            {
                Console.Write("Entrada inválida. Digite uma média válida (0 a 10): ");
            }

            Aluno aluno = new Aluno(nome, matricula, curso, mediaNotas);
            aluno.ExibirDados();
        }
    }
}
