using Microsoft.EntityFrameworkCore;
using Models;
using StreamingService.Db;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly StreamingServiceDbContext _context;
        public CategoryService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetCategorysAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Category.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> AddCategoryAsync(Category addCategory)
        {
            _context.Category.Add(addCategory);
            await _context.SaveChangesAsync();
            return addCategory;
        }

        public async Task<Category> UpdateCategoryAsync(Category updateCategory)
        {
            _context.Category.Update(updateCategory);
            await _context.SaveChangesAsync();
            return updateCategory;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var CategoryToDelete = await _context.Category.FirstOrDefaultAsync(category => category.Id == id);
            _context.Category.Remove(CategoryToDelete);
            await _context.SaveChangesAsync();
            return CategoryToDelete;
        }
    }
}
