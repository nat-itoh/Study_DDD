using System;
using BmiApp.Domain.Shared;

namespace BmiApp.Domain.BmiCalculater.ValueObjects {

    /// <summary>
    /// ‘Ìd‚ğ•\‚·ValueObjectD
    /// </summary>
    public sealed class Weight : ValueObject<Weight> {

        public float Value { get; }

        public Weight(float value) {
            if (value <= 0) {
                throw new ArgumentException("Weight must be greater than 0.");
            }
            Value = value;
        }

        protected override bool EqualsCore(Weight other) {
            return Value.Equals(other.Value);
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }
    }
}
