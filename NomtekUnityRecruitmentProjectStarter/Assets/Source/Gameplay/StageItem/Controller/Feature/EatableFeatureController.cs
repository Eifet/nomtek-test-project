using Nomtek.Source.Gameplay.StageItem.Model;
using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.StageItem.Controller.Feature
{
    public interface IEatable
    {
        void Eat();
    }
    
    public class EatableFeatureController : MonoBehaviour, IEatable
    {
        [Inject]
        IStageItemModel stageItemModel;
        
        public void Eat()
        {
            stageItemModel.RemoveItem(gameObject);
            Destroy(gameObject);
        }
    }
}