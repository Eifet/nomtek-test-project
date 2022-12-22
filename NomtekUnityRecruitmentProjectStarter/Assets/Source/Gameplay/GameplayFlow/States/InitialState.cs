using System.Collections;
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

            StartCoroutine(GoToNextStateWithDelay());
        }

        void OnDisable()
        {
            
        }

        //Artificially waiting for Unity to fetch thumbnails and wake up. 
        IEnumerator GoToNextStateWithDelay()
        {
            yield return new WaitForSeconds(2f);
            GoToNextState();
        }

        void GoToNextState()
        {
            gameObject.SetActive(false);
            nextState.gameObject.SetActive(true);
        }
    }
}