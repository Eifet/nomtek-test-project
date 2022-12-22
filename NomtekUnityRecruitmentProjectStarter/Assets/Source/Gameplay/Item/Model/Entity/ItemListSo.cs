using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Nomtek.Source.Gameplay.Item.Model
{
    [CreateAssetMenu(fileName = "ItemListSo", menuName = "Nomtek/Gameplay/ItemListSo")]
    public class ItemListSo : ScriptableObject, IItemList
    {
        [SerializeField]
        List<ItemSo> itemList = new();
        public List<IItem> ItemList { get; private set; }

        IDisposable loadingObserver;

        public void Initialize(Action onSuccessCallback)
        {
            InitializeList();
            Observe1(onSuccessCallback);
        }

        void InitializeList()
        {
            foreach (var itemSo in itemList) 
                itemSo.Initialize();
        }

        void Observe1(Action onSuccessCallback)
        {
            loadingObserver?.Dispose();
            loadingObserver = Observable
                .EveryUpdate()
                .Where(_ =>
                {
                    var allLoaded = itemList.All(i => i.ThumbnailImage != null);
                    if(!allLoaded)
                        InitializeList(); // Unity is not very smart with this, need to ping multiple times to get the textures.
                    return allLoaded;
                })
                .Subscribe(_ => OnLoadedAllImages(onSuccessCallback));
        }

        void OnLoadedAllImages(Action onSuccessCallback)
        {
            loadingObserver.Dispose();
            loadingObserver = null;
            
            ItemList = itemList.Cast<IItem>().ToList();
            onSuccessCallback?.Invoke();
        }
    }
}