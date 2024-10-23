using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
namespace FakeAPIMVC.Controllers;
using System.Linq;
using FakeAPIMVC.Models;

public class HomeController : Controller
{
    private const string RequestUri = "https://fakestoreapi.com/products";
    private readonly HttpClient _httpClient;

    public HomeController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync(RequestUri);
        response.EnsureSuccessStatusCode();
        var products = await response.Content.ReadFromJsonAsync<List<Product>>();
        var viewModel = new ProductViewModel
        {
            Products = products
        };
        return View(viewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var response = await _httpClient.GetAsync($"{RequestUri} + {id}");
        response.EnsureSuccessStatusCode();
        var Product = await response.Content.ReadFromJsonAsync<Product>();
        return View(Product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product Product)
    {
        var response = await _httpClient.PostAsJsonAsync(RequestUri, Product);
        response.EnsureSuccessStatusCode();
        return RedirectToAction(nameof(Index));        
    }
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product Product)
    {
        var response = await _httpClient.PutAsJsonAsync($"{RequestUri}+{id}", Product);
        response.EnsureSuccessStatusCode();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"{RequestUri}{id}");
        response.EnsureSuccessStatusCode();
        return RedirectToAction(nameof(Index));
    }
}
