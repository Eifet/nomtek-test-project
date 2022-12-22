using System;
using Nomtek.Source.Gameplay.Item.Model;
using Nomtek.Source.Ui._Ui.View;

namespace Nomtek.Source.Ui.ItemGridUi.View.SubView
{
    public class ItemViewController : ViewControllerMono<ItemView>
    {
        public event Action<IItem> OnItemClicked;
        
        public IItem Item;

        void OnEnable()
        {
            View.OnClicked += OnClicked;
        }

        void OnDisable()
        {
            View.OnClicked -= OnClicked;
        }

        public void Configure(IItem item)
        {
            this.Item = item;
            View.Configure(item.ItemName,item.ThumbnailImage);
        }

        void OnClicked()
        {
            OnItemClicked?.Invoke(Item);
        }
    }
}