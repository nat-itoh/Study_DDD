using Project.Domain.Shared;

namespace Project.Domain.Characters.Model {

    public sealed class CharacterId : ValueObject<CharacterId> {
        
        public int Value { get; }

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
