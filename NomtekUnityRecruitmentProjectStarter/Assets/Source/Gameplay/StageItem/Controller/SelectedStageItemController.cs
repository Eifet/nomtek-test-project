using Nomtek.Source.Gameplay.Controller;
using Nomtek.Source.Gameplay.Item.Model;
using Nomtek.Source.Gameplay.StageItem.Controller.Factory;
using Nomtek.Source.Gameplay.StageItem.Model;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.StageItem.Controller
{
    public class SelectedStageItemController : IController
    {
        [Inject]
        IStageItemFactory stageItemFactory;
        
        [Inject]
        ISelectedItemModel selectedItemModel;

        [Inject]
        ISelectedStageItemModel selectedStageItemModel;
        
        public void Initialize()
        {
            selectedItemModel.SelectedItem.OnChanged += OnSelectedItemChanged;
        }

        public void Dispose()
        {
            selectedItemModel.SelectedItem.OnChanged -= OnSelectedItemChanged;
        }

        void OnSelectedItemChanged(IItem item)
        {
            if (selectedStageItemModel.SelectedStageItem.Value != null)
                Object.Destroy(selectedStageItemModel.SelectedStageItem.Value);

            GameObject stageItem = null;
            if(item!=null)
                stageItem = stageItemFactory.CreatePlacementItem(item);
            
            selectedStageItemModel.SelectedStageItem.Value = stageItem;
        }
    }
}