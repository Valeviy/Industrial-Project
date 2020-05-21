using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCG_UI.Data.Repositories
{
    public interface IBGroupRepository : IGenericRepository<BGroups>
    {
        Task<List<BGroups>> GetRootsAsync(int resourceId);

        List<BGroups> GetChildren(int parentId);

        void RemoveBGroup(int bGroupID);
    }
}