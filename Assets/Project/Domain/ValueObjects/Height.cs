using System;

namespace BmiApp.Domain.ValueObjects {

    /// <summary>
    /// g’·‚ğ•\‚·ValueObjectD
    /// </summary>
    public sealed class Height : ValueObject<Height> {

        public float Value { get;}

        public Height(float value) {
            if (value <= 0) {
                throw new ArgumentException("Height must be greater than 0.");
            }
            Value = value;
        }


        protected override bool EqualsCore(Height other) {
            return Value.Equals(other.Value);
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }
    }
}
