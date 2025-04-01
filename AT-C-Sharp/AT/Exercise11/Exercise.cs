using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AT_C_Sharp.AT.Exercise11
{
    internal class Exercise
    {
        private const string ArquivoContatos = "contatos.txt";

        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciador de Contatos ===");
                Console.WriteLine("1 - Adicionar novo contato");
                Console.WriteLine("2 - Listar contatos cadastrados");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        AdicionarContato();
                        break;
                    case "2":
                        ListarContatos();
                        break;
                    case "3":
                        Console.WriteLine("Encerrando programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AdicionarContato()
        {
            Console.Clear();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone) || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Erro: Nenhum campo pode estar vazio!");
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(ArquivoContatos, true))
                {
                    sw.WriteLine($"{nome},{telefone},{email}");
                }
                Console.WriteLine("Contato cadastrado com sucesso!");
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void ListarContatos()
        {
            Console.Clear();
            Console.WriteLine("=== Contatos Cadastrados ===");
            if (!File.Exists(ArquivoContatos) || new FileInfo(ArquivoContatos).Length == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
            }
            else
            {
                using (StreamReader sr = new StreamReader(ArquivoContatos))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(',');
                        if (dados.Length == 3)
                        {
                            Console.WriteLine($"Nome: {dados[0]} | Telefone: {dados[1]} | Email: {dados[2]}");
                        }
                    }
                }
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
