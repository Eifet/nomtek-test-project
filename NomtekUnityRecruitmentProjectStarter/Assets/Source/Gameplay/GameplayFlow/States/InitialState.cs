using Nomtek.Source.Gameplay.Item.Model;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.GameplayFlow.States
{
    //A dummy implementation of Fsm.
    public class InitialState : MonoBehaviour
    {
        [SerializeField]
        GameState nextState;

        [Inject]
        ItemListSo itemListSo;

        [Inject]
        IItemModel itemModel;
        
        void OnEnable()
        {
            Debug.Log("InitialState");
            
            itemModel.ItemList.Data = itemListSo.ItemList;
            GoToNextState();
        }

        void OnDisable()
        {
            
        }

        void GoToNextState()
        {
            gameObject.SetActive(false);
            nextState.gameObject.SetActive(true);
        }
    }
}