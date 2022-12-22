using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Nomtek.Source.Gameplay.Controller
{
    public interface IInputHandler
    {
        public event Action<Vector3> OnMousePositionChanged; 
        event Action<Vector3> OnClick; 
        event Action OnInputCancel;
    }
    
    public class InputHandler : IInputHandler
    {
        public event Action<Vector3> OnMousePositionChanged; 
        public event Action<Vector3> OnClick; 
        public event Action OnInputCancel;

        Vector3 currentMousePosition;

        [Inject]
        void Initialize()
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ => CheckInput());

            Observable
                .EveryUpdate()
                .Where(_ => currentMousePosition != Input.mousePosition)
                .Subscribe(_ =>
                {
                    currentMousePosition = Input.mousePosition;
                    OnMousePositionChanged?.Invoke(currentMousePosition);
                });
        }

        void CheckInput()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
                OnInputCancel?.Invoke();

            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                OnClick?.Invoke(Input.mousePosition);
            }
                
        }
    }
}