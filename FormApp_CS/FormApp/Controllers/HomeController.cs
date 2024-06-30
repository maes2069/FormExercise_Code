using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormApp.Models;
using FormApp.Data;

namespace FormApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RequestRepository _requestRepository;

    public HomeController(ILogger<HomeController> logger, RequestRepository requestRepository)
    {
        _logger = logger;
        _requestRepository = requestRepository;
    }

    public IActionResult Index()
    {
        // return View();
        var model = new RequestModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Form(RequestModel model)
    {
        if (!ModelState.IsValid)
            {
                // Model state is not valid, return the view with validation errors
                return View("Index", model);
            }
            try
            {
                _requestRepository.AddRequest(model);
                ViewBag.SuccessMessage = "Your request has been submitted!";
                return View("Index", new RequestModel());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred while submitting your request: {ex.Message}";
            }
        return View("Index", model);
    } 


    public IActionResult RequestList()
    {
        // return View();
        var requests = _requestRepository.GetAllRequests();
        return View(requests);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
