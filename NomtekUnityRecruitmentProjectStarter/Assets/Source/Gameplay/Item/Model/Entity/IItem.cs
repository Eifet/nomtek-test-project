using UnityEngine;

namespace Nomtek.Source.Gameplay.Item.Model
{
    public interface IItem
    {
        string ItemName { get; }
        GameObject PlacementPrefab { get; }
        GameObject StagePrefab { get; }
        Texture2D ThumbnailImage { get; }
    }
}