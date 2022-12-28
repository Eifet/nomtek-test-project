using Nomtek.Source.Gameplay.Controller;
using Nomtek.Source.Gameplay.Item.Model;
using Nomtek.Source.Gameplay.Model;
using Nomtek.Source.Gameplay.StageItem.Controller.Factory;
using Nomtek.Source.Gameplay.StageItem.Model;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.StageItem.Controller
{
    public class ItemPlacingController : IController
    {
        [Inject]
        IInputHandler inputHandler;

        [Inject]
        CameraModel cameraModel;

        [Inject]
        IStageItemFactory stageItemFactory;

        [Inject]
        ISelectedItemModel selectedItemModel;
        
        [Inject]
        ISelectedStageItemModel selectedStageItemModel;

        [Inject]
        IStageItemModel stageItemModel;

        GameObject PlacingItem => selectedStageItemModel.SelectedStageItem.Value;
        Vector3 offset = new Vector3(0,.7f,0);
        bool placingMode;
        
        public void Initialize()
        {
            selectedStageItemModel.SelectedStageItem.OnChanged += OnSelectedItemChanged;
            inputHandler.OnClick += OnClick;
            inputHandler.OnMousePositionChanged += OnMousePositionChanged;

            OnSelectedItemChanged(selectedStageItemModel.SelectedStageItem.Value);
        }

        public void Dispose()
        {
            selectedStageItemModel.SelectedStageItem.OnChanged -= OnSelectedItemChanged;
            inputHandler.OnClick -= OnClick;
            inputHandler.OnMousePositionChanged -= OnMousePositionChanged;
        }

        void OnSelectedItemChanged(GameObject _)
        {
            if (PlacingItem == null)
            {
                placingMode = false;
                return;
            }

            PlacingItem.SetActive(false);
            placingMode = true;
        }

        void OnClick(Vector3 mousePosition)
        {
            if(!placingMode)
                return;
            
            if (RaycastUnderMouse(mousePosition, out var hit))
            {
                var item = selectedItemModel.SelectedItem.Value;
                var stageItem = stageItemFactory.CreateStageItem(item);
                var placingPosition = hit.point + offset;
                stageItem.transform.position = placingPosition;

                stageItemModel.AddItem(stageItem);
                selectedItemModel.SelectedItem.Value = null;
                placingMode = false;
            }
        }

        void OnMousePositionChanged(Vector3 mousePosition)
        {
            if(!placingMode)
                return;
            
            if (RaycastUnderMouse(mousePosition, out var hit))
            {
                PlacingItem.SetActive(true);
                PlacingItem.gameObject.transform.position = hit.point + offset;
            }
            else
            {
                PlacingItem.SetActive(false);
            }
        }

        bool RaycastUnderMouse(Vector3 mousePosition, out RaycastHit hit)
        {
            var ray = cameraModel.MainCamera.ScreenPointToRay(mousePosition);
            return Physics.Raycast(ray,out hit, 100, LayerMask.GetMask("InteractPlane"))
        }
    }
}