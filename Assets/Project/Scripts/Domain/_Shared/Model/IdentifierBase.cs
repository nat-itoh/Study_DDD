using System;

namespace Project.Domain.Shared {

    /// <summary>
    /// 識別子を表すValueObject．
    /// </summary>
    public abstract class IdentifierBase<T> : IEquatable<IdentifierBase<T>> 
        where T : IEquatable<T> {
        
        public T Value { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public IdentifierBase(T value) {

            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override bool Equals(object obj) {
            return obj is IdentifierBase<T> other && Equals(other);
        }

        public bool Equals(IdentifierBase<T> other) {
            if (other == null) return false;
            return Value.Equals(other.Value);
        }

        /// <summary>
        /// ハッシュ値の取得．
        /// </summary>
        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        /// <summary>
        /// 文字列への変換．
        /// </summary>
        public override string ToString() {
            return Value.ToString();
        }
    }
}
