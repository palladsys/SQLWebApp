using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLWebApp.Models;
using SQLWebApp.Services;

namespace SQLWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Product> Products;

        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products = productService.GetProducts();


        }
    }
}