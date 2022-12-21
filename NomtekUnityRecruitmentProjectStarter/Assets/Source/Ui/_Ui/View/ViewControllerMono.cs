using UnityEngine;

namespace Nomtek.Source.Ui._Ui.View
{
    // Some really simple View Controller implementation
    public class ViewControllerMono<T> : MonoBehaviour
        where T : ViewMono
    {
        T view;
        public T View => view ??= GetComponent<T>();
    }
}