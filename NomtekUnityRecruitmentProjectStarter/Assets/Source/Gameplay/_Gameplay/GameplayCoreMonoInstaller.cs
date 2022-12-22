using Nomtek.Source.Gameplay.Controller;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay
{
    public class GameplayCoreMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputHandler>().AsSingle();
        }
    }
}