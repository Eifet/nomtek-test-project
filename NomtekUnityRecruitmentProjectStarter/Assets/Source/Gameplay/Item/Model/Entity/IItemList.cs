using System.Collections.Generic;

namespace Nomtek.Source.Gameplay.Item.Model
{
    public interface IItemList
    {
        List<IItem> ItemList { get; }
    }
}