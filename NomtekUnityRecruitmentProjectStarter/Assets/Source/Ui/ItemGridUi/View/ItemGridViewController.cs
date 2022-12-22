using System;
using System.Collections.Generic;
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
        ItemViewController itemViewPrefab;
        
        [Inject]
        ViewFactory viewFactory;

        [Inject]
        IItemModel itemModel;
        
        void OnEnable()
        {
            itemModel.ItemList.OnChanged += OnItemListChanged;
            OnItemListChanged(itemModel.ItemList.Data);
        }

        void OnDisable()
        {
            itemModel.ItemList.OnChanged -= OnItemListChanged;
        }

        void OnItemListChanged(List<IItem> items)
        {
            View.ClearList();
            
            foreach (var item in items) 
                CreateItemView(item);
        }

        void CreateItemView(IItem item)
        {
            var itemViewController = viewFactory.Create<ItemViewController>(itemViewPrefab.gameObject);
            itemViewController.Configure(item);
            
            View.AddItemToList(itemViewController.transform);
        }
    }
}