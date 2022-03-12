using System;
using UnityEngine;

namespace Gilzoide.NamedEnum
{
    /// <summary>
    /// Enum wrapper that also serializes its name.
    /// 
    /// This is a safer alternative to raw enums when used as serialized fields in Unity. It maintains the right values
    /// after reordering, surviving code merges.
    /// </summary>
    /// <typeparam name="T">Enum type that this NamedEnum wraps</typeparam>
    [Serializable]
    public struct NamedEnum<T> : ISerializationCallbackReceiver
        where T : struct, Enum
    {
        [SerializeField] private T _value;
        [SerializeField] private string _name;
        
        public T Value => _value;

        public NamedEnum(T value)
        {
            _value = value;
            _name = value.ToString();
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        #region Implicit casts from/to T

        public static implicit operator T(NamedEnum<T> namedEnum)
        {
            return namedEnum._value;
        }

        public static implicit operator NamedEnum<T>(T value)
        {
            return new NamedEnum<T>(value);
        }

        #endregion

        #region ISerializationCallbackReceiver

        public void OnBeforeSerialize()
        {
            _name = _value.ToString();
        }

        public void OnAfterDeserialize()
        {
            if (Enum.TryParse(_name, out T value))
            {
                _value = value;
            }
            else
            {
                _name = _value.ToString();
            }
        }

        #endregion
    }
}