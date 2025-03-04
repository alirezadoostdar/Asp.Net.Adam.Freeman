namespace LanguageFeatures.Models;

public class Product
{
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public static Product[] GetProducts()
    {
        Product kayak = new Product
        {
            Name = "Kayak",
            Price = 275M
        };
		Product lifejacket = new Product
		{
			Name = "lifejacket",
			Price = 48.95M
		};
        return new Product[] { kayak, lifejacket, null };
	}
}

public class MyAsyncMethods
{
    public static async IAsyncEnumerable<long?> GetPageLenght(
        List<string> output, params string[] urls)
    {
        List<long?> result = new List<long?>();
        HttpClient client = new HttpClient();
        foreach(string url in urls)
        {
            output.Add($"Staretd request for {url}");
            var httpMessage = await client.GetAsync($"http://{url}");
            //result.Add(httpMessage.Content.Headers.ContentLength);
            output.Add(url);
            yield return httpMessage.Content.Headers.ContentLength;
        }
    }
}
public interface IProductSelection
{
    IEnumerable<Product>? Products { get; }
    IEnumerable<string>? Names => Products?.Select(x => x.Name);
}

public class ShoppingCart : IProductSelection
{
    private List<Product> products = new();

    public ShoppingCart(params Product[] prods)
    {
        products.AddRange(prods);
    }
    public IEnumerable<Product>? Products { get => products; }
}

public static class MyExtensionMethods
{
    public static decimal TotalPrices(this IEnumerable<Product?> products)
    {
        decimal total = 0;
        foreach (Product? item in products)
        {
            total += item?.Price ?? 0;
        }
        return total;
    }

    public static IEnumerable<Product?> FilterByPrice(
        this IEnumerable<Product?> products, decimal minimumPrice)
    {
        foreach (Product? item in products)
        {
            if ((item?.Price ?? 0) >= minimumPrice)
            {
                yield return item;
            }
        }
    }
}