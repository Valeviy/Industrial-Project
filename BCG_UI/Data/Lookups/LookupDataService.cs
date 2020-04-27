using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.Data.Lookups
{
    public class LookupDataService : ILookupDataService
    {
        private Func<SEICBalanceDBContext> _contextCreator;
        public LookupDataService(Func<SEICBalanceDBContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetResourceLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Resources.AsNoTracking()
                    .Select(f =>
                    new LookupItem
                    {
                        Id = f.ResourceID,
                        DisplayMember = f.ResourceName
                    })
                .ToListAsync();
            }
        }

        
    }


}
