using System;
using BmiApp.Domain.ValueObjects;

namespace BmiApp.Domain.Eintities {

    public class Person {

        /// <summary>
        /// �g��[m]
        /// </summary>
        public Height Height { get; }

        /// <summary>
        /// �̏d[kg]
        /// </summary>
        public Weight Weight { get; }

        /// <summary>
        /// �R���X�g���N�^�D
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
                < 16.0F => "�₹����",
                < 17.0F => "�₹",
                < 18.5F => "�₹�C��",
                < 25.0F => "����",
                < 30.0F => "�얞�C��",
                _ => "�얞"
            };
        }
    }
}
