using Nomtek.Source.Gameplay.Controller;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay
{
    public class GameplayCoreMonoInstaller : MonoInstaller
    {
        [SerializeField]
        InputHandler inputHandler;

        public override void InstallBindings()
        {
            Container.BindInstance(inputHandler).AsSingle();
        }
    }
}