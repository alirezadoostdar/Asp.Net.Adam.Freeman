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


public class ShoppingCart : IEnumerable<Product?>
{
    public IEnumerable<Product?>? Products { get; set;}

    public IEnumerator<Product?> GetEnumerator() => Products?.GetEnumerator() 
        ?? Enumerable.Empty<Product?>().GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
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
}