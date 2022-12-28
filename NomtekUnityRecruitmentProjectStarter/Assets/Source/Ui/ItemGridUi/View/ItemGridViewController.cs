using System;
using System.Collections.Generic;
using System.Linq;
using Nomtek.Source.Gameplay.Controller;
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
        IInputHandler inputHandler;
        
        [Inject]
        ViewFactory viewFactory;

        [Inject]
        IItemModel itemModel;

        [Inject]
        ISelectedItemModel selectedItemModel;

        IEnumerable<IGrouping<string, ItemViewController>> itemListGroups;

        void OnEnable()
        {
            inputHandler.OnInputCancel += OnCancel;
            View.OnInputFieldChanged += OnInputFieldChanged;

            itemModel.ItemList.OnChanged += OnItemListChanged;
            selectedItemModel.SelectedItem.OnChanged += OnItemSelected;
            
            OnItemListChanged(itemModel.ItemList.Value);
        }

        void OnDisable()
        {
            inputHandler.OnInputCancel -= OnCancel;
            View.OnInputFieldChanged -= OnInputFieldChanged;

            itemModel.ItemList.OnChanged -= OnItemListChanged;
            selectedItemModel.SelectedItem.OnChanged -= OnItemSelected;
        }

        #region List management

        void OnItemListChanged(List<IItem> items)
        {
            View.ClearList();

            var itemList = new List<ItemViewController>();
            foreach (var item in items)
            {
                var itemViewController = CreateItemView(item);
                itemList.Add(itemViewController);
            }

            //grouping the list to make it at least a bit more efficient.
            itemListGroups = itemList.GroupBy(x => x.Item.ItemName.ToLowerInvariant());
        }

        ItemViewController CreateItemView(IItem item)
        {
            var itemViewController = viewFactory.Create<ItemViewController>(itemViewPrefab.gameObject);
            itemViewController.Configure(item);
            itemViewController.OnItemClicked += OnItemClicked;
            View.AddItemToList(itemViewController.transform);

            return itemViewController;
        }
        
        #endregion

        #region List filtering

        //Filtering by groups with StartsWith
        void OnInputFieldChanged(string filter)
        {
            EnableAllItems();
            DisableItemsByFilter(filter);
        }

        void EnableAllItems()
        {
            foreach (var group in itemListGroups)
            {
                foreach (var itemViewController in group)
                {
                    itemViewController.gameObject.SetActive(true);
                }
            }
        }

        void DisableItemsByFilter(string filter)
        {
            foreach (var group in itemListGroups)
            {
                if (!group.Key.StartsWith(filter))
                {
                    foreach (var item in group)
                        item.gameObject.SetActive(false);
                }
            }
        }

        #endregion

        #region Selected Item management

        void OnItemClicked(IItem item)
        {
            selectedItemModel.SelectedItem.Value = item;
        }
        
        void OnCancel()
        {
            selectedItemModel.SelectedItem.Value = null;
        }
        
        //Not calling directly from OnItemClicked, because it should be controlled by data events, not the controller method calls.
        void OnItemSelected(IItem item)
        {
            if (item == null)
                View.OpenView();
            else
                View.CloseView();
        }

        #endregion
    }
}