using SpendSmart.Models;

namespace SpendSmart.Architecture.Repository.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int id);
        Task<List<Expense>> GetAllExpensesAsync();
        Task<Expense> GetExpenseById(int id);
        //Task UpdateExpenseAsync(string id, Expense expense);
    }
}
