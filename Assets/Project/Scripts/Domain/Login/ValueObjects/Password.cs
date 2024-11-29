using System;
using System.Text.RegularExpressions;
using BmiApp.Domain.Shared;

namespace BmiApp.Domain.Authentification.ValueObjects {

    /// <summary>
    /// �p�X���[�h��\��ValueObject�D
    /// </summary>
    public sealed class Password : ValueObject<Password>{

        private static readonly int MinTextCount = 8;

        public string Value { get; }


        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public Password(string password) {
            if (string.IsNullOrWhiteSpace(password) || password.Length < MinTextCount)
                throw new ArgumentException($"�p�X���[�h��{MinTextCount}�����ȏ�łȂ���΂Ȃ�܂���B");
            Value = password;
        }

        public override int GetHashCode() => Value.GetHashCode();
        
        public override string ToString() => "********"; // �p�X���[�h�͒��ڕ\�����Ȃ�

        protected override bool EqualsCore(Password other) {
            return this.Value == other.Value;
        }

    }
}
