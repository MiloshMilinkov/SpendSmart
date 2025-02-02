using SpendSmart.Architecture.Repository;
using SpendSmart.Architecture.Repository.Interfaces;
using SpendSmart.Models;
using SpendSmart.Services.Interfaces;

namespace SpendSmart.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task CreateExpenseAsync(Expense expense)
        {
            ArgumentNullException.ThrowIfNull(expense);
            if (expense.Value <= 0) throw new ArgumentException("Expense value must be greater than zero.");
            await _expenseRepository.AddExpenseAsync(expense);
        }
        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllExpensesAsync();
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var existingExpense = await _expenseRepository.GetExpenseById(id) 
                ?? throw new KeyNotFoundException($"Expense with ID {id} not found.");
            await _expenseRepository.DeleteExpenseAsync(id);
        }
    }
}
