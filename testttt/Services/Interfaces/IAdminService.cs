using Models;
using System.Collections;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public interface IAdminService
    {
        Task<Admin> AddAdminAsync(Admin addAdmin);
        Task<Admin> DeleteAdminAsync(int id);
        Task<Admin> GetAdminAsync(int id);
        Task<IEnumerable> GetAdminsAsync();
        Task<Admin> UpdateAdminAsync(Admin updateAdmin);
    }
}