
namespace LanguageFeatures.Controllers;

public class HomeController : Controller
{
    public ViewResult Index()
    {
        ShoppingCart cart
        = new ShoppingCart { Products = Product.GetProducts() };
        Product[] productArray = {
        new Product {Name = "Kayak", Price = 275M},
        new Product {Name = "Lifejacket", Price = 48.95M},
        new Product {Name = "Soccer ball", Price = 19.50M},
        new Product {Name = "Corner flag", Price = 34.95M}
 };
        var arrayTotal = productArray.FilterByPrice(20).TotalPrices();
        decimal totalcart = cart.TotalPrices();
        return View("Index", new string[] { $"Array Total: {arrayTotal:C2}" });
    }
}
