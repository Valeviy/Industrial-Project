using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCG_UI.Data.Lookups
{
    public interface ILookupDataService
    {
        Task<IEnumerable<LookupItem>> GetResourceLookupAsync();
    }
}