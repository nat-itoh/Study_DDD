using System;
using System.Text.RegularExpressions;
using BmiApp.Domain.Shared;

namespace BmiApp.Domain.Authentification.ValueObjects {

    /// <summary>
    /// Email��\��ValueObject�D
    /// </summary>
    public sealed class Email : ValueObject<Email>{

        private static readonly Regex EmailRegex = 
            new(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", RegexOptions.Compiled);
        
        public string Value { get;}

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public Email(string email) {
            if (!IsValid(email))
                throw new ArgumentException("�����ȃ��[���A�h���X�`���ł��B");
            Value = email;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool IsValid(string email) => EmailRegex.IsMatch(email);
        
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;

        protected override bool EqualsCore(Email other) {
            return this.Value == other.Value;
        }
    }
}
