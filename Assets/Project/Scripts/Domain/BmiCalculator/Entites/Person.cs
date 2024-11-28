using System;
using BmiApp.Domain.BmiCalculater.ValueObjects;

namespace BmiApp.Domain.BmiCalculater.Eintities {

    public class Person {

        /// <summary>
        /// 身長[m]
        /// </summary>
        public Height Height { get; }

        /// <summary>
        /// 体重[kg]
        /// </summary>
        public Weight Weight { get; }

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public Person(Height height, Weight weight) {
            Height = height ?? throw new ArgumentNullException(nameof(height));
            Weight = weight ?? throw new ArgumentNullException(nameof(weight));
        }

        /// <summary>
        /// 
        /// </summary>
        public Bmi CalculateBmi() => Bmi.Calculate(Height, Weight);

        /// <summary>
        /// 
        /// </summary>
        public string EvaluateBmi() {            
            var bmi = CalculateBmi();
            return bmi.Value switch {
                < 16.0F => "やせすぎ",
                < 17.0F => "やせ",
                < 18.5F => "やせ気味",
                < 25.0F => "普通",
                < 30.0F => "肥満気味",
                _ => "肥満"
            };
        }
    }
}
