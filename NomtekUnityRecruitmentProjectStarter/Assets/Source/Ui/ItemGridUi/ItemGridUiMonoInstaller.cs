using Nomtek.Source.Ui.ItemGridUi.View;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Ui.ItemGridUi
{
    public class ItemGridUiMonoInstaller : MonoInstaller
    {
        [SerializeField]
        ItemGridViewController itemGridView;

        public override void InstallBindings()
        {
            Container.BindInstance(itemGridView).AsSingle();
        }
    }
}