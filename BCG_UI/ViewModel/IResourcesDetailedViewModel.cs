using System.Threading.Tasks;

namespace BCG_UI.ViewModel
{
    public interface IResourcesDetailedViewModel
    {
        Task LoadAsync(int resourceId);
    }
}