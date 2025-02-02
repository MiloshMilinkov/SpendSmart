using SpendSmart.Models;

namespace SpendSmart.Services.Interfaces
{
    public interface IExpenseService
    {
        Task CreateExpenseAsync(Expense expense);
        Task<List<Expense>> GetAllExpensesAsync();
        Task DeleteExpenseAsync(int id);
    }
}
