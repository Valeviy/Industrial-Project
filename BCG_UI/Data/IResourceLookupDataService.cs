using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCG_UI.Data
{
    public interface IResourceLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetResourceLookupAsync();
    }
}