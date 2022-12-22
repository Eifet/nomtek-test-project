using System.Collections.Generic;
using Nomtek.Source.Gameplay.Model;
using Zenject;

namespace Nomtek.Source.Gameplay.Item.Model
{
    public interface IItemModel
    {
        LiveData<List<IItem>> ItemList { get; }
    }

    public class ItemModel : IItemModel
    {
        public LiveData<List<IItem>> ItemList { get; } = new();
    }
}