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
    public class AdminService : IAdminService
    {
        private readonly StreamingServiceDbContext _context;
        public AdminService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetAdminsAsync()
        {
            return await _context.Admin.ToListAsync();
        }

        public async Task<Admin> GetAdminAsync(int id)
        {
            return await _context.Admin.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Admin> AddAdminAsync(Admin addAdmin)
        {
            _context.Admin.Add(addAdmin);
            await _context.SaveChangesAsync();
            return addAdmin;
        }

        public async Task<Admin> UpdateAdminAsync(Admin updateAdmin)
        {
            _context.Admin.Update(updateAdmin);
            await _context.SaveChangesAsync();
            return updateAdmin;
        }

        public async Task<Admin> DeleteAdminAsync(int id)
        {
            var AdminToDelete = await _context.Admin.FirstOrDefaultAsync(admin => admin.Id == id);
            _context.Admin.Remove(AdminToDelete);
            await _context.SaveChangesAsync();
            return AdminToDelete;
        }
    }
}
