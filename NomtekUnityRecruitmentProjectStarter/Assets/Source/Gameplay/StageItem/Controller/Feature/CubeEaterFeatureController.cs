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
                StopHunting();
                return;
            }
            
            if (!eatableItems.Contains(currentEatableTarget)) 
                GoHuntNextTarget();
        }

        GameObject FindClosestItem(List<GameObject> items)
        {
            var closestDistance = float.MaxValue;
            var closestItem = stageItemModel.StageEatableItems.First();
            foreach (var item in items)
            {
                var distanceToItem = Vector3.Distance(transform.position, item.transform.position);
                if (closestDistance > distanceToItem)
                {
                    closestDistance = distanceToItem;
                    closestItem = item;
                }
            }

            return closestItem;
        }

        void GoHuntNextTarget()
        {
            var eatableItems = stageItemModel.StageEatableItems;
            var closestTarget = FindClosestItem(eatableItems);
            currentEatableTarget = closestTarget;
            
            navMeshAgent.SetDestination(currentEatableTarget.transform.position);
        }
        
        void StopHunting()
        {
            currentEatableTarget = null;
            navMeshAgent.ResetPath();
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