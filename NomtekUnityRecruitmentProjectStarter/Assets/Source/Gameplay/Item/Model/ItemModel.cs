using System.Collections.Generic;
using Zenject;

namespace Nomtek.Source.Gameplay.Item.Model
{
    public interface IItemModel
    {
        List<IItem> ItemList { get; }
    }
    
    public class ItemModel : IItemModel
    {
        [Inject]
        IItemList itemList;
        
        public List<IItem> ItemList => itemList.ItemList;
    }
}