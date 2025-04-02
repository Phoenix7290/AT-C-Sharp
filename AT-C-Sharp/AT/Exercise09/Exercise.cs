using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace AT_C_Sharp.AT.Exercise09
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Product(string name, int quantity, decimal unitPrice)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public override string ToString()
        {
            return $"Produto: {Name} | Quantidade: {Quantity} | Preço: R$ {UnitPrice:F2}";
        }

        public string ToFileFormat()
        {
            return $"{Name},{Quantity},{UnitPrice.ToString(CultureInfo.InvariantCulture)}";
        }
    }

    public class Exercise
    {
        private const string FilePath = "estoque.txt";
        private static Product[] productsArray = new Product[5];
        private static int productCount = 0;

        public static void Run()
        {
            while (true)
            {
                DisplayMenu();
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ListProducts();
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
            Console.WriteLine("=== Sistema de Controle de Estoque ===");
            Console.WriteLine("1 - Inserir Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        private static void AddProduct()
        {
            if (productCount >= 5)
            {
                Console.WriteLine("Limite de produtos atingido!");
                return;
            }

            Console.Write("Digite o nome do produto: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Nome inválido!");
                return;
            }

            Console.Write("Digite a quantidade em estoque: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Quantidade inválida! Deve ser um número inteiro positivo.");
                return;
            }

            Console.Write("Digite o preço unitário (ex.: 4500,00): ");
            string? priceInput = Console.ReadLine();
            decimal price;

            if (!decimal.TryParse(priceInput, NumberStyles.Any, CultureInfo.CurrentCulture, out price) &&
                !decimal.TryParse(priceInput, NumberStyles.Any, CultureInfo.InvariantCulture, out price) ||
                price < 0)
            {
                Console.WriteLine("Preço inválido! Deve ser um valor positivo.");
                return;
            }

            Product product = new Product(name, quantity, price);

            try
            {
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    sw.WriteLine(product.ToFileFormat());
                }
                Console.WriteLine("Produto inserido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o produto: {ex.Message}");
            }
        }

        private static void ListProducts()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(FilePath);
                if (lines.Length == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                    return;
                }

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3 &&
                        int.TryParse(parts[1], out int quantity))
                    {
                        if (decimal.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                        {
                            Product product = new Product(parts[0], quantity, price);
                            Console.WriteLine(product.ToString());
                        }
                        else
                        {
                            Console.WriteLine($"Erro ao ler linha: {line} (formato de preço inválido)");
                        }
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
        }
    }
}
