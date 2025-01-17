using System;

namespace Project.Domain.Shared {

    /// <summary>
    /// ���ʎq��\��ValueObject�D
    /// </summary>
    public abstract class IdentifierBase<T> : ValueObject<IdentifierBase<T>> 
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


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// �l�̔�r���W�b�N�D
        /// </summary>
        protected override bool EqualsCore(IdentifierBase<T> other) {
            return this.Value.Equals(other.Value);
        }
    }
}
