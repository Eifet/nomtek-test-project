using Nomtek.Source.Gameplay.StageItem.Controller;
using Source.Gameplay.StageItem.Model;
using Zenject;

namespace Nomtek.Source.Gameplay.StageItem
{
    public class StageItemMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Controllers
            Container.BindInterfacesTo<SelectedStageItemController>().AsSingle();
            Container.BindInterfacesTo<ItemPlacingController>().AsSingle();
            
            //Models
            Container.Bind<ISelectedStageItemModel>().To<SelectedStageItemModel>().AsSingle();
        }
    }
}