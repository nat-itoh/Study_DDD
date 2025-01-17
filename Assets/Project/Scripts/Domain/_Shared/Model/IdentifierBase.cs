using System;

namespace Project.Domain.Shared {

    /// <summary>
    /// 識別子を表すValueObject．
    /// </summary>
    public abstract class IdentifierBase<T> : ValueObject<IdentifierBase<T>> 
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


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 値の比較ロジック．
        /// </summary>
        protected override bool EqualsCore(IdentifierBase<T> other) {
            return this.Value.Equals(other.Value);
        }
    }
}
