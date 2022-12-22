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
            Container.BindInstance(itemListSo).AsTransient();
            Container.Bind<IItemModel>().To<ItemModel>().AsSingle();
            Container.Bind<ISelectedItemModel>().To<SelectedItemModel>().AsSingle();

        }
    }
}