using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.Data
{

    class ResourceDataService : IResourceDataService
    {
        private Func<SEICBalanceDBContext> _contextCreator;


        public ResourceDataService(Func<SEICBalanceDBContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<Resources> GetByIdAsync(int resourceId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Resources.AsNoTracking().SingleAsync(f => f.ResourceID == resourceId);
            }

        }

        public async Task SaveAsync(Resources resource)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Resources.Attach(resource);
                ctx.Entry(resource).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
