using System;
using App.Domain.Shared;

namespace App.Domain.BmiCalculater.ValueObjects {

    /// <summary>
    /// �̏d��\��ValueObject�D
    /// </summary>
    public sealed class Weight : ValueObject<Weight> {

        public float Value { get; }

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public Weight(float value) {
            if (value <= 0) {
                throw new ArgumentException("Weight must be greater than 0.");
            }
            Value = value;
        }

        public Weight Add(float value) {
            return new Weight(this.Value + value);
        }


        protected override bool EqualsCore(Weight other) {
            return Value.Equals(other.Value);
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }
    }
}
