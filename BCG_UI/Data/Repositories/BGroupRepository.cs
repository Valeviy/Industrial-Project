using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BCG_UI.Data.Repositories
{
     //implemented F1.7 requirement
     class BGroupRepository : GenericRepository<BGroups, SEICBalanceDBContext>, IBGroupRepository
    {
        public BGroupRepository(SEICBalanceDBContext context) : base(context)
        {
        }

        public async override Task<BGroups> GetByIdAsync(int id)
        {
            return await Context.BGroups.Include(b => b.Points).SingleAsync(b => b.BGroupID == id);

        }

        public async Task<List<BGroups>> GetRootsAsync(int resourceId)
        {
            return await Context.Set<BGroups>().Where(b => (b.ResourceID == resourceId &&  b.BGroupIDParent == null )).ToListAsync();

        }

        public List<BGroups> GetChildren(int parentId)
        {
            return Context.Set<BGroups>().Where(b => b.BGroupIDParent == parentId)
                .ToList();

        }

        public void RemoveBGroup(int bGroupID)
        {
            //todo: remove not only one group, add children, points, rules 
            BGroups entity = Context.BGroups.Single(b => b.BGroupID == bGroupID);

            


            Context.BGroups.Remove(entity);
        }
    }
}
