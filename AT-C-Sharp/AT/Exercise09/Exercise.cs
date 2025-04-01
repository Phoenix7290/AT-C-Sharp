using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace AT_C_Sharp.AT.Exercise09
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public Produto(string nome, int quantidade, decimal precoUnitario)
        {
            Nome = nome;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public override string ToString()
        {
            return $"Produto: {Nome} | Quantidade: {Quantidade} | Preço: R$ {PrecoUnitario:F2}";
        }

        public string ToFileFormat()
        {
            return $"{Nome},{Quantidade},{PrecoUnitario.ToString(CultureInfo.InvariantCulture)}";
        }
    }

    public class Exercise
    {
        private const string FilePath = "estoque.txt";
        private static Produto[] produtosArray = new Produto[5];
        private static int produtoCount = 0;

        public static void Run()
        {
            while (true)
            {
                ExibirMenu();
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        InserirProduto();
                        break;
                    case "2":
                        ListarProdutos();
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
            Console.WriteLine("=== Sistema de Controle de Estoque ===");
            Console.WriteLine("1 - Inserir Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        private static void InserirProduto()
        {
            if (produtoCount >= 5)
            {
                Console.WriteLine("Limite de produtos atingido!");
                return;
            }

            Console.Write("Digite o nome do produto: ");
            string? nome = Console.ReadLine();
            if (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Nome inválido!");
                return;
            }

            Console.Write("Digite a quantidade em estoque: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade < 0)
            {
                Console.WriteLine("Quantidade inválida! Deve ser um número inteiro positivo.");
                return;
            }

            Console.Write("Digite o preço unitário (ex.: 4500,00): ");
            string? precoInput = Console.ReadLine();
            decimal preco;

            if (!decimal.TryParse(precoInput, NumberStyles.Any, CultureInfo.CurrentCulture, out preco) &&
                !decimal.TryParse(precoInput, NumberStyles.Any, CultureInfo.InvariantCulture, out preco) ||
                preco < 0)
            {
                Console.WriteLine("Preço inválido! Deve ser um valor positivo.");
                return;
            }

            Produto produto = new Produto(nome, quantidade, preco);

            try
            {
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    sw.WriteLine(produto.ToFileFormat());
                }
                Console.WriteLine("Produto inserido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o produto: {ex.Message}");
            }
        }

        private static void ListarProdutos()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            try
            {
                string[] linhas = File.ReadAllLines(FilePath);
                if (linhas.Length == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                    return;
                }

                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(',');
                    if (partes.Length == 3 &&
                        int.TryParse(partes[1], out int quantidade))
                    {
                        if (decimal.TryParse(partes[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal preco))
                        {
                            Produto produto = new Produto(partes[0], quantidade, preco);
                            Console.WriteLine(produto.ToString());
                        }
                        else
                        {
                            Console.WriteLine($"Erro ao ler linha: {linha} (formato de preço inválido)");
                        }
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
        }
    }
}
