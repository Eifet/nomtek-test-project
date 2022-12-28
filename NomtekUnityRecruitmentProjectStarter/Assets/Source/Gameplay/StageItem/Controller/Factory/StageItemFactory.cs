using Nomtek.Source.Gameplay.Item.Model;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.StageItem.Controller.Factory
{
    public interface IStageItemFactory
    {
        GameObject CreatePlacementItem(IItem item);
        GameObject CreateStageItem(IItem item);
    }
    
    public class StageItemFactory : IStageItemFactory
    {
        [Inject]
        DiContainer container;
        
        public GameObject CreatePlacementItem(IItem item)
        {
            return container.InstantiatePrefab(item.PlacementPrefab);
        }

        public GameObject CreateStageItem(IItem item)
        {
            return container.InstantiatePrefab(item.StagePrefab);
        }
    }
}