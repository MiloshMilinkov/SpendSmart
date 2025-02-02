using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;
using SpendSmart.Services.Interfaces;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExpenseService _expenseService;

        public HomeController(ILogger<HomeController> logger, IExpenseService expenseService)
        {
            _logger = logger;
            _expenseService = expenseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<ActionResult> Expenses()
        {
            var allExpenses = await _expenseService.GetAllExpensesAsync();
            return View(allExpenses);
        }

        public IActionResult CreateEditExpense(int? id)
        {
            return View();
        }

        public async Task<ActionResult> AddCreatedExpense(Expense model)
        {

                await _expenseService.CreateExpenseAsync(model);
                return RedirectToAction("Expenses");

            //return View("CreateEditExpense", model);
        }
        public async Task<ActionResult> DeleteExpense(int id)
        {
            await _expenseService.DeleteExpenseAsync(id);
            return RedirectToAction("Expenses");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
