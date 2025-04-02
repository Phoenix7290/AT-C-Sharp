using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.IO;

namespace AT_C_Sharp.AT.Exercise12
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, string phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string ToFileFormat()
        {
            return $"{Name},{PhoneNumber},{Email}";
        }
    }

    public abstract class ContactFormatter
    {
        public abstract void DisplayContacts(List<Contact> contacts);
    }

    public class MarkdownFormatter : ContactFormatter
    {
        public override void DisplayContacts(List<Contact> contacts)
        {
            Console.WriteLine("## Lista de Contatos\n");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"- **Nome:** {contact.Name}");
                Console.WriteLine($"- 📞 Telefone: {contact.PhoneNumber}");
                Console.WriteLine($"- 📧 Email: {contact.Email}\n");
            }
        }
    }

    public class TableFormatter : ContactFormatter
    {
        public override void DisplayContacts(List<Contact> contacts)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("| Nome           | Telefone      | Email          |");
            Console.WriteLine("----------------------------------------");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"| {contact.Name,-14} | {contact.PhoneNumber,-13} | {contact.Email,-14} |");
            }
            Console.WriteLine("----------------------------------------");
        }
    }

    public class RawTextFormatter : ContactFormatter
    {
        public override void DisplayContacts(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Nome: {contact.Name} | Telefone: {contact.PhoneNumber} | Email: {contact.Email}");
            }
        }
    }

    public class Exercise
    {
        private const string FilePath = "contatos.txt";

        public static void Run()
        {
            while (true)
            {
                DisplayMenu();
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterContact();
                        break;
                    case "2":
                        ListContacts();
                        break;
                    case "3":
                        Console.WriteLine("Encerrando o programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("=== Sistema de Gerenciamento de Contatos ===");
            Console.WriteLine("1 - Cadastrar Contato");
            Console.WriteLine("2 - Listar Contatos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        private static void RegisterContact()
        {
            Console.Write("Digite o nome: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Nome inválido!");
                return;
            }

            Console.Write("Digite o telefone (ex.: (21) 99999-9999): ");
            string? phone = Console.ReadLine();
            if (string.IsNullOrEmpty(phone))
            {
                Console.WriteLine("Telefone inválido!");
                return;
            }

            Console.Write("Digite o email: ");
            string? email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email inválido!");
                return;
            }

            Contact contact = new Contact(name, phone, email);

            try
            {
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    sw.WriteLine(contact.ToFileFormat());
                }
                Console.WriteLine("Contato cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o contato: {ex.Message}");
            }
        }

        private static void ListContacts()
        {
            List<Contact> contacts = ReadContactsFromFile();
            if (contacts.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
                return;
            }

            Console.WriteLine("Escolha o formato de exibição:");
            Console.WriteLine("1 - Markdown");
            Console.WriteLine("2 - Tabela");
            Console.WriteLine("3 - Texto Puro");
            Console.Write("Digite a opção (1-3): ");
            string? format = Console.ReadLine();

            ContactFormatter formatter = format switch
            {
                "1" => new MarkdownFormatter(),
                "2" => new TableFormatter(),
                "3" => new RawTextFormatter(),
                _ => null
            };

            if (formatter == null)
            {
                Console.WriteLine("Formato inválido! Usando Texto Puro como padrão.");
                formatter = new RawTextFormatter();
            }

            formatter.DisplayContacts(contacts);
        }

        private static List<Contact> ReadContactsFromFile()
        {
            List<Contact> contacts = new List<Contact>();

            if (!File.Exists(FilePath))
            {
                return contacts;
            }

            try
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        contacts.Add(new Contact(parts[0], parts[1], parts[2]));
                    }
                    else
                    {
                        Console.WriteLine($"Erro ao ler linha: {line} (formato inválido)");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
            }

            return contacts;
        }
    }
}