using Nomtek.Source.Ui._Ui.Controller;
using Zenject;

namespace Nomtek.Source.Ui
{
    public class UiCoreMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ViewFactory>().AsTransient();
        }
    }
}