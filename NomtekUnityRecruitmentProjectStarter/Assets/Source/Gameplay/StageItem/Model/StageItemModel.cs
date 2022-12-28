using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree.Util;
using Nomtek.Source.Gameplay.Item.Model;
using Nomtek.Source.Gameplay.StageItem.Controller.Feature;
using UnityEngine;

namespace Nomtek.Source.Gameplay.StageItem.Model
{
    public interface IStageItemModel
    {
        event Action OnListChanged;
        List<GameObject> StageItems { get; }

        List<GameObject> StageEatableItems { get; }

        void AddItem(GameObject item);
        void RemoveItem(GameObject item);
    }

    public class StageItemModel : IStageItemModel
    {
        public event Action OnListChanged;

        List<GameObject> stageItems = new();

        public List<GameObject> StageItems
        {
            get => stageItems.ToList();
            set
            {
                stageItems = value;
                OnListChanged?.Invoke();
            }
        }

        public List<GameObject> StageEatableItems => stageItems
            .FindAll(i => i.GetComponent<IEatable>() != null).ToList();

        public void AddItem(GameObject item)
        {
            stageItems.Add(item);
            OnListChanged?.Invoke();
        }

        public void RemoveItem(GameObject item)
        {
            stageItems.Remove(item);
            OnListChanged?.Invoke();
        }
    }
}