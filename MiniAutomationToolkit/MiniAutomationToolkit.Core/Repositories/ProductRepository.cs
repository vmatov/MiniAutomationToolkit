

namespace MiniAutomationToolkit.Core.Models
{
    public static class ProductRepository
    {
        public static List<Product> LoadFromCsv(string filePath)
        {
            var products = new List<Product>();

            using (var reader = new StreamReader(filePath))
            {
                // Пропустили первую строку (заголовок) и считаем что это строка номер 1, а не 0 для выведения ошибок валидации
                reader.ReadLine();
                int lineNumber = 1;

                while (!reader.EndOfStream)
                {
                    lineNumber++;
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var price = decimal.TryParse(values[1], out var parsedPrice);
                    try
                    {
                        if (string.IsNullOrWhiteSpace(values[0]) || string.IsNullOrWhiteSpace(values[2]) || !price || parsedPrice < 0)
                        {
                            throw new InvalidDataException($"Invalid line №{lineNumber}: '{line}'. Name, Price, and Category cannot be empty.");
                        }
                        else
                        {
                            var product = new Product
                            {
                                Name = values[0],
                                Price = parsedPrice,
                                Category = values[2]
                            };
                            products.Add(product);
                        }
                    }
                    catch (InvalidDataException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return products;
        }

public static List<string> GetAffordableProducts(
    IEnumerable<Product> products,
    ProductCategory category,
    decimal maxPrice)
        {
            var affordableProducts = products
            .OrderBy(p => p.Price)
            .ThenByDescending(p => p.Name)
                .Where(p => p.Category == category.ToString() && p.Price <= maxPrice)
                .Select(p => p.Name)
                .ToList();

            return affordableProducts;
        }
    }
}
