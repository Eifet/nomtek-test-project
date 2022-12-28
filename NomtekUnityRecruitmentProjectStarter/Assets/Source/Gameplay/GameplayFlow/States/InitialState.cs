using System;
using System.Collections;
using System.Linq;
using Nomtek.Source.Gameplay.Item.Model;
using UniRx;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.GameplayFlow.States
{
    //A dummy implementation of Fsm.
    //Initializing items and waiting for images to be fetched from Unity
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

            itemListSo.Initialize(OnItemListInitialized);
        }

        void OnDisable()
        {
        }

        void OnItemListInitialized()
        {
            itemModel.ItemList.Value = itemListSo.ItemList;
            GoToNextState();
        }
        
        void GoToNextState()
        {
            gameObject.SetActive(false);
            nextState.gameObject.SetActive(true);
        }
    }
}