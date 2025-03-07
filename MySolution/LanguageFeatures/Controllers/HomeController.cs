﻿
namespace LanguageFeatures.Controllers;

public class HomeController : Controller
{
    public async Task<ViewResult> Index()
    {
        List<string> output = new List<string>();
        await foreach (long? len in  MyAsyncMethods.GetPageLenght(output, "apress.com", "microsoft.com", "amazon.com"))
        {
            output.Add($"Page lenght: {len}");
        }
        return View(output);    
    }

    public string? name(Product? product,decimal que)
    {
        return  product?.Name;
    }


}
