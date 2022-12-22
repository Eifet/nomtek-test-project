using System;
using Nomtek.Source.Ui._Ui.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Nomtek.Source.Ui.ItemGridUi.View.SubView
{
    public class ItemView : ViewMono
    {
        [SerializeField]
        TMP_Text title;
        
        [SerializeField]
        Image thumbnail;

        Sprite sprite;
        
        public void Configure(string itemText, Texture2D itemImage)
        {
            title.text = itemText;
            SetImage(itemImage);
        }

        void SetImage(Texture2D itemImage)
        {
            DestroySprite();
            sprite = CreateSprite(itemImage);
            thumbnail.sprite = sprite;
        }

        Sprite CreateSprite(Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
        }

        void DestroySprite()
        {
            Destroy(sprite);
        }
    }
}