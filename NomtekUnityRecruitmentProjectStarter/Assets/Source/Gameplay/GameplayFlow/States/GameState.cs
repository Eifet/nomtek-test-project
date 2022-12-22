using UnityEngine;

namespace Nomtek.Source.Gameplay.GameplayFlow.States
{
    public class GameState : MonoBehaviour
    {
        [SerializeField]
        EndState nextState;

        void OnEnable()
        {
            Debug.Log("GameState");
        }

        void OnDisable()
        {
            
        }
    }
}