using System;
using Project.Domain.Shared;

namespace Project.Domain.Common.Model {

    public class Name : ValueObject<Name> {

        /// <summary>
        /// 名前．
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// 名字．
        /// </summary>
        public string LastName { get; }

        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public Name(string firstName, string lastName) {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException($"{nameof(firstName)}は空であってはいけません。");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException($"{nameof(lastName)}は空であってはいけません。");

            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// ハッシュ値の取得．
        /// </summary>
        public override string ToString() => $"{LastName} {FirstName}";

        /// <summary>
        /// 文字列への変換．
        /// </summary>
        public override int GetHashCode() => HashCode.Combine(FirstName, LastName);


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 値の比較ロジック．
        /// </summary>
        protected override bool EqualsCore(Name other) {
            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

    }
}
