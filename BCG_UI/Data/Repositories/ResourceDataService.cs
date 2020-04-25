using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.Data.Repositories
{

    class ResourceRepository : IResourceRepository
    {
        private SEICBalanceDBContext _context;


        public ResourceRepository(SEICBalanceDBContext context)
        {
            _context = context;
        }

        public async Task<Resources> GetByIdAsync(int resourceId)
        {
            return await _context.Resources.SingleAsync(f => f.ResourceID == resourceId);

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
