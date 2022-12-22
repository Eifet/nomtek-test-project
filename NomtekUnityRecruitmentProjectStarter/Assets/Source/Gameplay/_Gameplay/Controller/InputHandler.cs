using System;
using UnityEngine;

namespace Nomtek.Source.Gameplay.Controller
{
    public class InputHandler : MonoBehaviour
    {
        public event Action<Vector2> OnClick; 
        public event Action OnInputCancel;

        void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
                OnInputCancel?.Invoke();
            
            if(Input.GetMouseButtonUp(0))
                OnClick?.Invoke(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
        }
    }
}