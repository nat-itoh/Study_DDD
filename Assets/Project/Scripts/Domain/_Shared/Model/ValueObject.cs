using System;

// [REF]
//  _: C#�Ńh���C���쓮�J��ValueObject�Ńv���O�����̕��G������菜�� https://anderson02.com/cs/ddd/ddd10/
//  qiita: DDD �ɓ��傷��Ȃ�A�܂��� ValueObject �����ł������񂶂�Ȃ��H https://qiita.com/t2-kob/items/9d9dd038fe7497756dbf
//  _: �l�I�u�W�F�N�g���������� https://learn.microsoft.com/ja-jp/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects

namespace Project.Domain.Shared {

    /// <summary>
    /// ValueObject�̊��N���X�D
    /// </summary>
    public abstract class ValueObject<T> where T : ValueObject<T> {

        public override bool Equals(object obj) {
            var vo = obj as T;
            if (vo == null) {
                return false;
            }

            return EqualsCore(vo);
        }

        public abstract override int GetHashCode();

        protected abstract bool EqualsCore(T other);


        /// ----------------------------------------------------------------------------
        #region Static
        
        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2) {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2) {
            return !Equals(vo1, vo2);
        }
        #endregion
    }
}
