using System;
using Nomtek.Source.Gameplay.Item.Model;
using Nomtek.Source.Ui._Ui.View;

namespace Nomtek.Source.Ui.ItemGridUi.View.SubView
{
    public class ItemViewController : ViewControllerMono<ItemView>
    {
        IItem item;
        
        public void Configure(IItem item)
        {
            this.item = item;
            View.Configure(item.ItemName,item.ThumbnailImage);
        }
    }
}