using System;

namespace Nomtek.Source.Gameplay.Model
{
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