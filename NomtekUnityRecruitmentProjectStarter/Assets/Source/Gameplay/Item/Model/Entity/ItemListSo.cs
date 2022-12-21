using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nomtek.Source.Gameplay.Item.Model
{
    [CreateAssetMenu(fileName = "ItemListSo", menuName = "Nomtek/Gameplay/ItemListSo")]
    public class ItemListSo : ScriptableObject, IItemList
    {
        [SerializeField]
        List<ItemSo> itemList = new();

        List<IItem> itemListInternal;
        public List<IItem> ItemList => itemListInternal??=itemList.Cast<IItem>().ToList();
    }
}