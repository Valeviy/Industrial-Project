using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCG_UI.Data.Lookups
{
    public interface IBGroupLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetBGroupLookupAsync();
    }
}