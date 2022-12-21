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
        GameObject prefab;
        public GameObject Prefab => prefab;

        Texture2D thumbnailImage;
        public Texture2D ThumbnailImage => thumbnailImage??=AssetPreview.GetMiniThumbnail(prefab);
    }
}