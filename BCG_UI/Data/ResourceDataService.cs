using DataAccess;
using Model;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Resources> GetAll()
        {
            using (var ctx = _contextCreator())
            {
                return ctx.Resources.AsNoTracking().ToList();
            }

        }
    }
}
