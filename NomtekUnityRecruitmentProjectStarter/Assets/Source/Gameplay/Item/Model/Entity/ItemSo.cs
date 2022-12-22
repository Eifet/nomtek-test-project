using System;
using UnityEditor;
using UnityEngine;

namespace Nomtek.Source.Gameplay.Item.Model
{
    [CreateAssetMenu(fileName = "ItemSo", menuName = "Nomtek/Gameplay/ItemSo")]
    public class ItemSo : ScriptableObject, IItem
    {
        [SerializeField]
        string itemName;
        public string ItemName => itemName;

        [SerializeField]
        GameObject placementPrefab;
        public GameObject PlacementPrefab => placementPrefab;

        [SerializeField]
        GameObject stagePrefab;
        public GameObject StagePrefab => stagePrefab;

        //Ideally we'd have a url reference to the image and have some ResourceProvider with some Promise that would fetch and release the image when needed and not needed in the UI views.
        public Texture2D ThumbnailImage { get; private set; }

        public void Initialize()
        {
            ThumbnailImage = AssetPreview.GetAssetPreview(placementPrefab);
        }
    }
}