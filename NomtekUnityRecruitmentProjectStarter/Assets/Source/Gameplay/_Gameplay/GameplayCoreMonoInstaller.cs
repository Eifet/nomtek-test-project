using Nomtek.Source.Gameplay.Controller;
using Nomtek.Source.Gameplay.Model;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay
{
    public class GameplayCoreMonoInstaller : MonoInstaller
    {
        [SerializeField]
        Camera camera;
        
        public override void InstallBindings()
        {
            Container.Bind<IInputHandler>().To<InputHandler>().AsSingle();
            Container.Bind<CameraModel>().AsSingle().WithArguments(camera);
        }
    }
}