using UnityEngine;

namespace Nomtek.Source.Gameplay.GameplayFlow.States
{
    public class EndState : MonoBehaviour
    {
        void OnEnable()
        {
            Debug.Log("EndState");
            Application.Quit();
        }

        void OnDisable()
        {
            
        }
    }
}