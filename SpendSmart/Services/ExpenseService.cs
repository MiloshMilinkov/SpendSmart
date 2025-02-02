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
            if(expense == null) throw new ArgumentNullException(nameof(expense));
            await _expenseRepository.AddExpenseAsync(expense);
        }
        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllExpensesAsync();
        }

        public async Task DeleteExpenseAsync(int id)
        {
            await _expenseRepository.DeleteExpenseAsync(id);
        }
    }
}
