using Nomtek.Source.Gameplay.Item.Model;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.Item
{
    public class ItemMonoInstaller: MonoInstaller
    {
        [SerializeField]
        ItemListSo itemListSo;
        
        public override void InstallBindings()
        {
            Container.Bind<IItemModel>().To<ItemModel>().AsSingle().WithArguments(itemListSo);
        }
    }
}