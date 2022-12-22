using Nomtek.Source.Gameplay.Model;

namespace Nomtek.Source.Gameplay.Item.Model
{
    public interface ISelectedItemModel
    {
        LiveData<IItem> SelectedItem { get; } 
    }
    
    class SelectedItemModel : ISelectedItemModel
    {
        public LiveData<IItem> SelectedItem { get; } = new();
    }
}