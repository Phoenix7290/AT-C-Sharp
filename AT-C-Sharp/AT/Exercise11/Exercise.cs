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
        private const string ContactFile = "contatos.txt";

        public static void Run()
        {
            while (true)
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciador de Contatos ===");
                Console.WriteLine("1 - Adicionar novo contato");
                Console.WriteLine("2 - Listar contatos cadastrados");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ListContacts();
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

        static void AddContact()
        {
            Console.Clear();
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Telefone: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Erro: Nenhum campo pode estar vazio!");
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(ContactFile, true))
                {
                    sw.WriteLine($"{name},{phone},{email}");
                }
                Console.WriteLine("Contato cadastrado com sucesso!");
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void ListContacts()
        {
            Console.Clear();
            Console.WriteLine("=== Contatos Cadastrados ===");
            if (!File.Exists(ContactFile) || new FileInfo(ContactFile).Length == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
            }
            else
            {
                using (StreamReader sr = new StreamReader(ContactFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        if (data.Length == 3)
                        {
                            Console.WriteLine($"Nome: {data[0]} | Telefone: {data[1]} | Email: {data[2]}");
                        }
                    }
                }
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
