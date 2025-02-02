﻿using Microsoft.EntityFrameworkCore;
using SpendSmart.Architecture.Data;
using SpendSmart.Architecture.Repository.Interfaces;
using SpendSmart.Models;
using SpendSmart.Services;

namespace SpendSmart.Architecture.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly SpendSmartDbContext _spendSmartDbContext;

        public ExpenseRepository(SpendSmartDbContext spendSmartDbContext) { 
            _spendSmartDbContext = spendSmartDbContext;
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            await _spendSmartDbContext.AddAsync(expense);
            await _spendSmartDbContext.SaveChangesAsync();
        }
        public async Task<Expense> GetExpenseById(int id)
        {
            var expense = await _spendSmartDbContext.Expenses.FirstOrDefaultAsync(ex => ex.Id == id);
            return expense;
        }

        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            return await _spendSmartDbContext.Expenses.ToListAsync();
        }
        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await GetExpenseById(id);
            _spendSmartDbContext.Expenses.Remove(expense);
            await _spendSmartDbContext.SaveChangesAsync();

        }

    }
}
