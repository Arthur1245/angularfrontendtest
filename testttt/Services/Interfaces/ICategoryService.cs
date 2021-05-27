using Models;
using System.Collections;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public interface ICategoryService
    {
        Task<Category> AddCategoryAsync(Category addCategory);
        Task<Category> DeleteCategoryAsync(int id);
        Task<Category> GetCategoryAsync(int id);
        Task<IEnumerable> GetCategorysAsync();
        Task<Category> UpdateCategoryAsync(Category updateCategory);
    }
}