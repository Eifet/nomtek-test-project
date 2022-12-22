using Nomtek.Source.Gameplay.Controller;
using Nomtek.Source.Gameplay.Item.Model;
using Source.Gameplay.StageItem.Model;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.StageItem.Controller
{
    public class SelectedStageItemController : IController
    {
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
            if (selectedStageItemModel.SelectedStageItem.Data != null)
                Object.Destroy(selectedStageItemModel.SelectedStageItem.Data);

            GameObject stageItem = null;
            if(item!=null)
                stageItem = Object.Instantiate(item.PlacementPrefab);
            
            selectedStageItemModel.SelectedStageItem.Data = stageItem;
        }
    }
}