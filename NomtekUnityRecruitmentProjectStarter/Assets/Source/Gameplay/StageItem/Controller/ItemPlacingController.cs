using Nomtek.Source.Gameplay.Controller;
using Nomtek.Source.Gameplay.Item.Model;
using Nomtek.Source.Gameplay.Model;
using Source.Gameplay.StageItem.Model;
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
        ISelectedItemModel selectedItemModel;
        
        [Inject]
        ISelectedStageItemModel selectedStageItemModel;

        GameObject PlacingItem => selectedStageItemModel.SelectedStageItem.Data;
        Vector3 offset = new Vector3(0,.7f,0);
        bool placingMode;
        
        public void Initialize()
        {
            selectedStageItemModel.SelectedStageItem.OnChanged += OnSelectedItemChanged;
            inputHandler.OnClick += OnClick;
            inputHandler.OnMousePositionChanged += OnMousePositionChanged;

            OnSelectedItemChanged(selectedStageItemModel.SelectedStageItem.Data);
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
            
            var ray = cameraModel.MainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray,out var hit, 100, LayerMask.GetMask("InteractPlane")))
            {
                var stagePrefab = selectedItemModel.SelectedItem.Data.StagePrefab;
                var stageItem = Object.Instantiate(stagePrefab);
                var placingPosition = hit.point + offset;
                stageItem.transform.position = placingPosition;

                selectedItemModel.SelectedItem.Data = null;
                placingMode = false;
            }
        }

        void OnMousePositionChanged(Vector3 mousePosition)
        {
            if(!placingMode)
                return;
            
            var ray = cameraModel.MainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray,out var hit, 100, LayerMask.GetMask("InteractPlane")))
            {
                PlacingItem.SetActive(true);
                PlacingItem.gameObject.transform.position = hit.point + offset;
            }
            else
            {
                PlacingItem.SetActive(false);
            }
        }
    }
}