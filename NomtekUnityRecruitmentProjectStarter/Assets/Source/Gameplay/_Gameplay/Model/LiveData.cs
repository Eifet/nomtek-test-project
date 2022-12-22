using System;

namespace Nomtek.Source.Gameplay.Model
{
    //Simple implementation of Observer. There's ReactiveProperty/ReactiveCollection in Rx that looks cool, but I haven't used it much yet really.
    public class LiveData<T>
    {
        public event Action<T> OnChanged;

        T data;
        public T Data
        {
            get => data;

            set
            {
                data = value;
                OnChanged?.Invoke(data);
            }
        }
    }
}