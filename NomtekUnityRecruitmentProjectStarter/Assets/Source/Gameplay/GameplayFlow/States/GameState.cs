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

        [Inject]
        ISelectedItemModel selectedItemModel;

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
            selectedItemModel.SelectedItem.Data = item;
            itemGridView.CloseView();
        }

        void OnItemPlaced()
        {
            selectedItemModel.SelectedItem.Data = null;
            itemGridView.OpenView();
        }

        void OnCancel()
        {
            selectedItemModel.SelectedItem.Data = null;
            itemGridView.OpenView();
        }
    }
}