using System;

namespace BmiApp.Domain.ValueObjects {

    /// <summary>
    /// BMIを表すValueObject．
    /// </summary>
    public sealed class Bmi : ValueObject<Bmi>{

        public float Value { get; }

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public Bmi(float value) {
            if (value <= 0) {
                throw new ArgumentException("Weight must be greater than 0.");
            }
            Value = value;
        }


        public static Bmi Calculate(Height height, Weight weight) {
            float bmiValue = weight.Value / (height.Value * height.Value);
            return new Bmi(bmiValue);
        }

        protected override bool EqualsCore(Bmi other) {
            return Value.Equals(other.Value);
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }
    }
}
