using System;

namespace Project.Domain.Shared {

    /// <summary>
    /// ���ʎq��\��ValueObject�D
    /// </summary>
    public abstract class IdentifierBase<T> : IEquatable<IdentifierBase<T>> 
        where T : IEquatable<T> {
        
        public T Value { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
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
        /// �n�b�V���l�̎擾�D
        /// </summary>
        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        /// <summary>
        /// ������ւ̕ϊ��D
        /// </summary>
        public override string ToString() {
            return Value.ToString();
        }
    }
}
