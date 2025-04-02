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
            Aluno aluno = new Aluno(
                nome: "Josinaldo da Silva",
                matricula: "2023001234",
                curso: "Engenharia de Software",
                mediaNotas: 8.5
            );

            aluno.ExibirDados();
        }
    }
}
