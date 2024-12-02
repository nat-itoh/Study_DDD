using System;

// [REF]
//  _: C#�Ńh���C���쓮�J��ValueObject�Ńv���O�����̕��G������菜�� https://anderson02.com/cs/ddd/ddd10/
//  qiita: DDD �ɓ��傷��Ȃ�A�܂��� ValueObject �����ł������񂶂�Ȃ��H https://qiita.com/t2-kob/items/9d9dd038fe7497756dbf

namespace App.Domain.Shared {

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

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        protected abstract bool EqualsCore(T other);


        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2) {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2) {
            return !Equals(vo1, vo2);
        }
    }
}
