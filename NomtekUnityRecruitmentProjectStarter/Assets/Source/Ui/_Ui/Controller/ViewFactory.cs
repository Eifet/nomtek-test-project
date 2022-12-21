using Nomtek.Source.Ui._Ui.View;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Ui._Ui.Controller
{
    public class ViewFactory
    {
        [Inject]
        DiContainer container;

        public T Create<T>(GameObject prefab)  where T : ViewControllerMono
        {
            return container.InstantiatePrefabForComponent<T>(prefab);
        }
    }
}