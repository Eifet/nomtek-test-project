using UnityEngine;

namespace Nomtek.Source.Gameplay.Item.Model
{
    public interface IItem
    {
        string ItemName { get; }
        GameObject Prefab { get; }
        Texture2D ThumbnailImage { get; }
    }
}