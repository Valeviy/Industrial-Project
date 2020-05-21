using System.Threading.Tasks;

namespace BCG_UI.ViewModel
{
    public interface IResourceViewModel
    {
		//implemented F1.6 requirement
        Task LoadAsync();
    }
}