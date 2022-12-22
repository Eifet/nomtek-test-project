using Nomtek.Source.Ui.ItemGridUi.View;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.GameplayFlow.States
{
    public class GameState : MonoBehaviour
    {
        [SerializeField]
        EndState nextState;

        [Inject]
        ItemGridViewController itemGridView;

        void OnEnable()
        {
            Debug.Log("GameState");
            itemGridView.gameObject.SetActive(true);
        }

        void OnDisable()
        {
            itemGridView.gameObject.SetActive(false);
        }
    }
}