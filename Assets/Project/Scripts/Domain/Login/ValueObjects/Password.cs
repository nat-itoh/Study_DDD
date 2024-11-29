using System;
using System.Text.RegularExpressions;
using BmiApp.Domain.Shared;

namespace BmiApp.Domain.Authentification.ValueObjects {

    /// <summary>
    /// パスワードを表すValueObject．
    /// </summary>
    public sealed class Password : ValueObject<Password>{

        private static readonly int MinTextCount = 8;

        public string Value { get; }


        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public Password(string password) {
            if (string.IsNullOrWhiteSpace(password) || password.Length < MinTextCount)
                throw new ArgumentException($"パスワードは{MinTextCount}文字以上でなければなりません。");
            Value = password;
        }

        public override int GetHashCode() => Value.GetHashCode();
        
        public override string ToString() => "********"; // パスワードは直接表示しない

        protected override bool EqualsCore(Password other) {
            return this.Value == other.Value;
        }

    }
}
