using Nomtek.Source.Gameplay.Controller;
using Nomtek.Source.Gameplay.Item.Model;
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
        IInputHandler inputHandler;
        
        [Inject]
        ItemGridViewController itemGridView;

        void OnEnable()
        {
            Debug.Log("GameState");

            inputHandler.OnInputCancel += OnCancel;
            
            itemGridView.OnItemChosen += OnItemChosen;
            itemGridView.gameObject.SetActive(true);
        }

        void OnDisable()
        {
            inputHandler.OnInputCancel -= OnCancel;
            
            itemGridView.OnItemChosen -= OnItemChosen;
            itemGridView.gameObject.SetActive(false);
        }

        void OnItemChosen(IItem item)
        {
            Debug.Log($"OnItemChosen {item.ItemName}");
            itemGridView.CloseView();
        }

        void OnItemPlaced()
        {
            
        }

        void OnCancel()
        {
            itemGridView.OpenView();
        }
    }
}