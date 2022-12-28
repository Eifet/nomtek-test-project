using System;
using System.Collections.Generic;
using System.Linq;
using Nomtek.Source.Gameplay.StageItem.Model;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Nomtek.Source.Gameplay.Item.Controller
{
    public class CubeEaterFeatureController : MonoBehaviour
    {
        [SerializeField]
        NavMeshAgent navMeshAgent;
        
        [Inject]
        IStageItemModel stageItemModel;

        GameObject currentEatableTarget;

        void OnEnable()
        {
            stageItemModel.OnListChanged += OnStageItemsChanged;
            OnStageItemsChanged();
        }

        void OnDisable()
        {
            stageItemModel.OnListChanged -= OnStageItemsChanged;
        }

        void OnStageItemsChanged()
        {
            var eatableItems = stageItemModel.StageEatableItems;
            if (eatableItems.Count == 0)
            {
                StopEat();
                return;
            }
            
            if (!eatableItems.Contains(currentEatableTarget)) 
                GoToNextTarget();
        }

        GameObject FindClosestItem(List<GameObject> items)
        {
            var minDistance = float.MaxValue;
            var minItem = stageItemModel.StageEatableItems.First();
            foreach (var item in items)
            {
                var distanceToItem = Vector3.Distance(transform.position, item.transform.position);
                if (minDistance > distanceToItem)
                {
                    minDistance = distanceToItem;
                    minItem = item;
                }
            }

            return minItem;
        }

        void GoEat()
        {
            navMeshAgent.SetDestination(currentEatableTarget.transform.position);
        }

        void StopEat()
        {
            navMeshAgent.ResetPath();
        }

        void GoToNextTarget()
        {
            var eatableItems = stageItemModel.StageEatableItems;
            var closestTarget = FindClosestItem(eatableItems);
            currentEatableTarget = closestTarget;
            GoEat();
        }

        void OnTriggerEnter(Collider other)
        {
            var isEatable = other.TryGetComponent<IEatable>(out var eatable);
            if (!isEatable)
                return;

            eatable.Eat();
        }
    }
}