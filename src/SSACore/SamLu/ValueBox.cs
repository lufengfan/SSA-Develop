using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamLu
{
    public struct ValueBox<T> : IEquatable<ValueBox<T>>
    {
        public static ValueBox<T> Empty => new ValueBox<T>(false);

        private bool hasValue;
        public bool HasValue => this.hasValue;

        private T value;
        public T Value
        {
            get
            {
                if (this.hasValue)
                    return this.value;
                else throw new InvalidOperationException();
            }
            set
            {
                this.value = value;
                this.hasValue = true;
            }
        }

        private ValueBox(bool hasValue, T value = default(T))
        {
            this.hasValue = hasValue;
            this.value = value;
        }

        public ValueBox(T value) : this(true, value) { }

        public void Clear() => this.hasValue = false;

        public override bool Equals(object obj) => obj != null && obj is ValueBox<T> valueBox && this.Equals(valueBox);

        public bool Equals(ValueBox<T> other) => this.hasValue && other.hasValue && EqualityComparer<T>.Default.Equals(this.value, other.value);

        public static implicit operator ValueBox<T>(T value) => new ValueBox<T>(value);
        public static explicit operator T(ValueBox<T> valueBox) => valueBox.value;
    }
}
