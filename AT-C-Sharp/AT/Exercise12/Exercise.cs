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

    public class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Contato(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }

        public string ToFileFormat()
        {
            return $"{Nome},{Telefone},{Email}";
        }
    }

    public abstract class ContatoFormatter
    {
        public abstract void ExibirContatos(List<Contato> contatos);
    }

    public class MarkdownFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("## Lista de Contatos\n");
            foreach (var contato in contatos)
            {
                Console.WriteLine($"- **Nome:** {contato.Nome}");
                Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
                Console.WriteLine($"- 📧 Email: {contato.Email}\n");
            }
        }
    }

    public class TabelaFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("| Nome           | Telefone      | Email          |");
            Console.WriteLine("----------------------------------------");
            foreach (var contato in contatos)
            {
                Console.WriteLine($"| {contato.Nome,-14} | {contato.Telefone,-13} | {contato.Email,-14} |");
            }
            Console.WriteLine("----------------------------------------");
        }
    }

    public class RawTextFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            foreach (var contato in contatos)
            {
                Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
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
                ExibirMenu();
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarContato();
                        break;
                    case "2":
                        ListarContatos();
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
        private static void ExibirMenu()
        {
            Console.WriteLine("=== Sistema de Gerenciamento de Contatos ===");
            Console.WriteLine("1 - Cadastrar Contato");
            Console.WriteLine("2 - Listar Contatos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
        }
        private static void CadastrarContato()
        {
            Console.Write("Digite o nome: ");
            string? nome = Console.ReadLine();
            if (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Nome inválido!");
                return;
            }

            Console.Write("Digite o telefone (ex.: (21) 99999-9999): ");
            string? telefone = Console.ReadLine();
            if (string.IsNullOrEmpty(telefone))
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

            Contato contato = new Contato(nome, telefone, email);

            try
            {
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    sw.WriteLine(contato.ToFileFormat());
                }
                Console.WriteLine("Contato cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o contato: {ex.Message}");
            }
        }

        private static void ListarContatos()
        {
            List<Contato> contatos = LerContatosDoArquivo();
            if (contatos.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
                return;
            }

            Console.WriteLine("Escolha o formato de exibição:");
            Console.WriteLine("1 - Markdown");
            Console.WriteLine("2 - Tabela");
            Console.WriteLine("3 - Texto Puro");
            Console.Write("Digite a opção (1-3): ");
            string? formato = Console.ReadLine();

            ContatoFormatter formatter = formato switch
            {
                "1" => new MarkdownFormatter(),
                "2" => new TabelaFormatter(),
                "3" => new RawTextFormatter(),
                _ => null
            };

            if (formatter == null)
            {
                Console.WriteLine("Formato inválido! Usando Texto Puro como padrão.");
                formatter = new RawTextFormatter();
            }

            formatter.ExibirContatos(contatos);
        }

        private static List<Contato> LerContatosDoArquivo()
        {
            List<Contato> contatos = new List<Contato>();

            if (!File.Exists(FilePath))
            {
                return contatos; 
            }

            try
            {
                string[] linhas = File.ReadAllLines(FilePath);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(',');
                    if (partes.Length == 3)
                    {
                        contatos.Add(new Contato(partes[0], partes[1], partes[2]));
                    }
                    else
                    {
                        Console.WriteLine($"Erro ao ler linha: {linha} (formato inválido)");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
            }

            return contatos;
        }
    }
}