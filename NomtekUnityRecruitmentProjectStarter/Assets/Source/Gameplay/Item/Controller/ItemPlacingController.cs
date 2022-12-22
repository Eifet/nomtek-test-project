using Nomtek.Source.Gameplay.Controller;
using Nomtek.Source.Gameplay.Item.Model;
using Nomtek.Source.Gameplay.Model;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.Item.Controller
{
    public class ItemPlacingController : IController
    {
        [Inject]
        IInputHandler inputHandler;

        [Inject]
        CameraModel cameraModel;
        
        [Inject]
        ISelectedItemModel selectedItemModel;

        GameObject placingItem;
        Vector3 offset = new Vector3(0,.7f,0);
        bool placingMode;
        
        public void Initialize()
        {
            selectedItemModel.SelectedItem.OnChanged += OnSelectedItemChanged;
            inputHandler.OnClick += OnClick;
            inputHandler.OnMousePositionChanged += OnMousePositionChanged;

            OnSelectedItemChanged(selectedItemModel.SelectedItem.Data);
        }

        public void Dispose()
        {
            selectedItemModel.SelectedItem.OnChanged -= OnSelectedItemChanged;
            inputHandler.OnClick -= OnClick;
            inputHandler.OnMousePositionChanged -= OnMousePositionChanged;
        }

        void OnSelectedItemChanged(IItem item)
        {
            if (item == null)
            {
                placingMode = false;
                Object.Destroy(placingItem);
                return;
            }

            placingItem = Object.Instantiate(item.PlacementPrefab);
            placingItem.SetActive(false);
            placingMode = true;
        }

        void OnClick(Vector3 mousePosition)
        {
            if(!placingMode)
                return;
            
            var ray = cameraModel.MainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray,out var hit, 100, LayerMask.GetMask("InteractPlane")))
            {
                var stageItem = Object.Instantiate(selectedItemModel.SelectedItem.Data.StagePrefab);
                stageItem.transform.position = hit.point + offset;
                
                Object.Destroy(placingItem);
                placingItem = null;
                placingMode = false;
                selectedItemModel.SelectedItem.Data = null;
            }
        }

        void OnMousePositionChanged(Vector3 mousePosition)
        {
            if(!placingMode)
                return;
            
            var ray = cameraModel.MainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray,out var hit, 100, LayerMask.GetMask("InteractPlane")))
            {
                placingItem.SetActive(true);
                placingItem.gameObject.transform.position = hit.point + offset;
            }
            else
            {
                placingItem.SetActive(false);
            }
        }
    }
}