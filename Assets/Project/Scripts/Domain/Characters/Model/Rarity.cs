using System;
using System.Collections.Generic;
using System.Linq;
using Project.Domain.Shared;

// [REF]
//  qiita: DDD実装パターンの区分オブジェクトをC#で実装する https://qiita.com/haguta/items/ceca207c313eef332cb1

namespace Project.Domain.Characters.Model {

    public sealed class Rarity : ValueObject<Rarity> {

        #region Static
        // プリセット値
        public static Rarity Common => new(1, nameof(Rarity.Common));
        public static Rarity Rare => new(2, nameof(Rarity.Rare));
        public static Rarity Epic => new(3, nameof(Rarity.Epic));

        private static readonly Dictionary<int, Rarity> _valuesById;
        public static IEnumerable<Rarity> GetAll() => _valuesById.Values;

        /// <summary>
        /// 静的コンストラクタ．
        /// </summary>
        static Rarity() {

            var values = new[] { Common, Rare, Epic };
            _valuesById = values.ToDictionary(rarity => rarity.Id);
        }
        
        /// <summary>
        /// Idから Rarity へ変換する．
        /// </summary>
        public static Rarity FromId(int id) {
            if (_valuesById.TryGetValue(id, out var rarity))
                return rarity;

            throw new ArgumentException($"Invalid Rarity ID: {id}");
        }

        /// <summary>
        /// 名前から Rarity へ変換する．
        /// </summary>
        public static Rarity FromName(string name) {
            var rarity = GetAll().FirstOrDefault(r => r.Name == name);
            if (rarity == null)
                throw new ArgumentException($"Invalid Rarity Name: {name}");

            return rarity;
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．(非公開)
        /// </summary>
        internal Rarity(int id, string name) {
            Id = id;
            Name = name;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;


        /// ----------------------------------------------------------------------------
        // Protected Method

        protected override bool EqualsCore(Rarity other) {
            return Id == other.Id;
        }
    }

}
