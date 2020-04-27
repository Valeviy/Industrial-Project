using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.Data.Repositories
{
    public interface IResourceRepository
    {
        Task<Resources> GetByIdAsync(int resourceId);
        Task SaveAsync();
        bool HasChanges();
        void Add(Resources resource);
        void Remove(Resources model);
    }
}
