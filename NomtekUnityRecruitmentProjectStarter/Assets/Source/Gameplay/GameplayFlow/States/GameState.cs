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
        ItemGridViewController itemGridView;

        void OnEnable()
        {
            Debug.Log("GameState");
            itemGridView.OnItemChosen += OnItemChosen;
            itemGridView.gameObject.SetActive(true);
        }

        void OnDisable()
        {
            itemGridView.OnItemChosen -= OnItemChosen;
            itemGridView.gameObject.SetActive(false);
        }

        void OnItemChosen(IItem item)
        {
            Debug.Log($"OnItemChosen {item.ItemName}");
        }
    }
}