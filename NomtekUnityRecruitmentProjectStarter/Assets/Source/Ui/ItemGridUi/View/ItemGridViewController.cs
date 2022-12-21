using System;
using Nomtek.Source.Gameplay.Item.Model;
using Nomtek.Source.Ui._Ui.Controller;
using Nomtek.Source.Ui._Ui.View;
using Nomtek.Source.Ui.ItemGridUi.View.SubView;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Ui.ItemGridUi.View
{
    public class ItemGridViewController : ViewControllerMono<ItemGridView>
    {
        [SerializeField]
        GameObject itemViewPrefab;
        
        [Inject]
        ViewFactory viewFactory;

        [Inject]
        IItemModel itemModel;
        
        void OnEnable()
        {
            
        }

        void OnDisable()
        {
            
        }

        void CreateItemView(IItem item)
        {
            var itemViewController = viewFactory.Create<ItemViewController>(itemViewPrefab);
            itemViewController.Configure(item);
        }
    }
}