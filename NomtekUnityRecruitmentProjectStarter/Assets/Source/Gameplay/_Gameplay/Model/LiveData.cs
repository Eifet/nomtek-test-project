using System;

namespace Nomtek.Source.Gameplay.Model
{
    //Simple implementation of Observer. There's ReactiveProperty/ReactiveCollection in Rx that looks cool, but I haven't used it much yet really.
    public class LiveData<T>
    {
        public event Action<T> OnChanged;

        T value;
        public T Value
        {
            get => value;

            set
            {
                this.value = value;
                OnChanged?.Invoke(this.value);
            }
        }
    }
}