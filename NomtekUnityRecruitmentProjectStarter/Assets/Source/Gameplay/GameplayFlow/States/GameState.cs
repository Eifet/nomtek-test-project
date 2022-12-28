using Nomtek.Source.Gameplay.Controller;
using Nomtek.Source.Gameplay.Item.Model;
using Nomtek.Source.Ui.ItemGridUi.View;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.GameplayFlow.States
{
    //Kind of a main state. Manages Ui (could've managed all ui stuff like canceling or selecting the item, but sometimes it's okay to put the logic inside of view controller)
    public class GameState : MonoBehaviour
    {
        [SerializeField]
        EndState nextState;

        [Inject]
        IInputHandler inputHandler;
        
        [Inject]
        ItemGridViewController itemGridView;

        [Inject]
        ISelectedItemModel selectedItemModel;

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