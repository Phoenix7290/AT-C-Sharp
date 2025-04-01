using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_C_Sharp.AT.Exercise06.Class
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public double MediaNotas { get; set; }

        public Aluno(string nome, string matricula, string curso, double mediaNotas)
        {
            Nome = nome;
            Matricula = matricula;
            Curso = curso;
            MediaNotas = mediaNotas;
        }

        public void ExibirDados()
        {
            Console.WriteLine("Dados do Aluno:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Curso: {Curso}");
            Console.WriteLine($"Média das Notas: {MediaNotas:F2}");
            Console.WriteLine($"Situação: {VerificarAprovacao()}");
        }

        public string VerificarAprovacao()
        {
            return MediaNotas >= 7 ? "Aprovado" : "Reprovado";
        }
    }

    public class Exercise
    {
        public static void Run()
        {
            Aluno aluno = new Aluno(
                nome: "Marcos Ryan",
                matricula: "2023001234",
                curso: "Engenharia de Software",
                mediaNotas: 8.5
            );

            aluno.ExibirDados();
        }
    }
}
