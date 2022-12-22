using System;
using DG.Tweening;
using Nomtek.Source.Ui._Ui.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Nomtek.Source.Ui.ItemGridUi.View
{
    public class ItemGridView : ViewMono
    {
        public event Action<string> OnInputFieldChanged; 

        [SerializeField]
        TMP_InputField inputField;

        //Unity's scroll rect is not the best, it's still rendering stuff when it's not visible. So if there are shit tons of items, it will be a big deal.
        //Implementing RecyclerView like on Android would be a good idea here.
        [SerializeField]
        ScrollRect scrollRect;

        float hideXValue = -600;
        float openXValue = 30;
        float animationSpeed = .5f;

        #region Lifecycle
        void OnEnable()
        {
            inputField.onValueChanged.AddListener(OnInputChanged);
        }

        void OnDisable()
        {
            inputField.onValueChanged.RemoveListener(OnInputChanged);
        }
        #endregion

        public void OpenView()
        {
            transform.DOMoveX(openXValue, animationSpeed).SetEase(Ease.OutSine);
        }

        public void CloseView()
        {
            transform.DOMoveX(hideXValue, animationSpeed).SetEase(Ease.InSine);
        }
        
        public void AddItemToList(Transform item)
        {
            item.SetParent(scrollRect.content);
        }

        public void ClearList()
        {
            foreach (Transform child in scrollRect.content) {
                Destroy(child.gameObject);
            }
        }

        void OnInputChanged(string input)
        {
            OnInputFieldChanged?.Invoke(input);
        }
    }
}