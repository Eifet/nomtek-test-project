using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.Controller
{
    public interface IInputHandler
    {
        event Action<Vector2> OnClick; 
        event Action OnInputCancel;
    }
    
    public class InputHandler : IInputHandler
    {
        public event Action<Vector2> OnClick; 
        public event Action OnInputCancel;

        [Inject]
        void Initialize()
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ => CheckInput());
        }

        void CheckInput()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
                OnInputCancel?.Invoke();
            
            if(Input.GetMouseButtonUp(0))
                OnClick?.Invoke(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
        }
    }
}