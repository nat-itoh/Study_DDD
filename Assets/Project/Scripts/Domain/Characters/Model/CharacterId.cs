using Project.Domain.Shared;

namespace Project.Domain.Characters.Model {

    /// <summary>
    /// キャラクタIdを表すValueObject．
    /// </summary>
    public sealed class CharacterId : ValueObject<CharacterId> {
        
        public int Value { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public CharacterId(int value) {
            Value = value;
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        public override string ToString() {
            return Value.ToString();
        }

        protected override bool EqualsCore(CharacterId other) {
            return Value == other.Value;
        }
    }
}
