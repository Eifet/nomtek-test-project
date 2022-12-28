using Nomtek.Source.Gameplay.StageItem.Controller;
using Nomtek.Source.Gameplay.StageItem.Controller.Factory;
using Nomtek.Source.Gameplay.StageItem.Model;
using Zenject;

namespace Nomtek.Source.Gameplay.StageItem
{
    public class StageItemMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Factory
            Container.Bind<IStageItemFactory>().To<StageItemFactory>().AsTransient();
            
            //Controllers
            Container.BindInterfacesTo<SelectedStageItemController>().AsSingle();
            Container.BindInterfacesTo<ItemPlacingController>().AsSingle();
            
            //Models
            Container.Bind<ISelectedStageItemModel>().To<SelectedStageItemModel>().AsSingle();
            Container.Bind<IStageItemModel>().To<StageItemModel>().AsSingle();
        }
    }
}