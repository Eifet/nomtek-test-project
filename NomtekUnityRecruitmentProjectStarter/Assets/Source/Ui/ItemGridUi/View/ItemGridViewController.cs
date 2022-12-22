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

        List<ItemViewController> itemList = new();

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
            itemList.Clear();
            
            foreach (var item in items) 
                CreateItemView(item);
        }

        void CreateItemView(IItem item)
        {
            var itemViewController = viewFactory.Create<ItemViewController>(itemViewPrefab.gameObject);
            itemViewController.Configure(item);
            itemViewController.OnItemClicked += OnItemClicked;
            itemList.Add(itemViewController);

            View.AddItemToList(itemViewController.transform);
        }

        void OnItemClicked(IItem item)
        {
            OnItemChosen?.Invoke(item);
        }

        #endregion

        #region List filtering

        void OnInputFieldChanged(string filter)
        {
            itemList.ForEach(x => x.gameObject.SetActive(true));
            var filteredList = itemList.FindAll(x => !x.Item.ItemName.ToLowerInvariant().StartsWith(filter.ToLowerInvariant()));
            filteredList.ForEach(x => x.gameObject.SetActive(false));
        }

        #endregion
    }
}