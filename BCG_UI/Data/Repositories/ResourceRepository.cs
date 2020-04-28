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

    class ResourceRepository : GenericRepository<Resources, SEICBalanceDBContext>, IResourceRepository

    {
        public ResourceRepository(SEICBalanceDBContext context) : base(context)
        {

        }

        public override async Task<Resources> GetByIdAsync(int resourceId)
        {
            return await Context.Resources.Include(f => f.BGroups).SingleAsync(f => f.ResourceID == resourceId);

        }


        public void RemoveBGroup(BGroups model)
        {
            Context.BGroups.Remove(model);
        }
    }
}
