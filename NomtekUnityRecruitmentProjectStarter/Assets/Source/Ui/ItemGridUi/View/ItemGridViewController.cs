using System;
using System.Collections.Generic;
using System.Linq;
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
        public event Action<IItem> OnItemChosen;

        [SerializeField]
        ItemViewController itemViewPrefab;

        [Inject]
        ViewFactory viewFactory;

        [Inject]
        IItemModel itemModel;

        IEnumerable<IGrouping<string, ItemViewController>> itemListGroups;

        void OnEnable()
        {
            View.OnInputFieldChanged += OnInputFieldChanged;

            itemModel.ItemList.OnChanged += OnItemListChanged;
            OnItemListChanged(itemModel.ItemList.Data);
        }

        void OnDisable()
        {
            View.OnInputFieldChanged -= OnInputFieldChanged;

            itemModel.ItemList.OnChanged -= OnItemListChanged;
        }

        public void OpenView() => View.OpenView();

        public void CloseView() => View.CloseView();

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

        void OnItemClicked(IItem item)
        {
            OnItemChosen?.Invoke(item);
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
    }
}