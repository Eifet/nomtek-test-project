using UnityEngine;
using Zenject;

namespace Nomtek.Source.Gameplay.Model
{
    public class CameraModel
    {
        [Inject]
        public Camera MainCamera;
    }
}