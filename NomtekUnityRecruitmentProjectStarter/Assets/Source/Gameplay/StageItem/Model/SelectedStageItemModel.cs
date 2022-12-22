﻿using Nomtek.Source.Gameplay.Model;
using UnityEngine;

namespace Source.Gameplay.StageItem.Model
{
    public interface ISelectedStageItemModel
    {
        LiveData<GameObject> SelectedStageItem { get; }
    }
    
    public class SelectedStageItemModel : ISelectedStageItemModel
    {
        public LiveData<GameObject> SelectedStageItem { get; } = new();
    }
}