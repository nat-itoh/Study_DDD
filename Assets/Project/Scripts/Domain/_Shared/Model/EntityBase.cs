using System;

namespace Project.Domain.Shared {

    public abstract class EntityBase<T1, T2> 
        where T1 : IdentifierBase<T2> 
        where T2 : IEquatable<T2>{
        
        public T1 Id { get; }

        
        public EntityBase(T1 id) {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public override bool Equals(object obj) {
            var other = obj as EntityBase<T>;
            if (other == null) {
                return false;
            }
            return Id.Equals(other.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();


        /// ----------------------------------------------------------------------------
        #region Static

        public static bool operator ==(EntityBase<T1, T2> left, EntityBase<T1, T2> right) => Equals(left, right);
        public static bool operator !=(EntityBase<T1, T2> left, EntityBase<T1, T2> right) => !Equals(left, right);
        #endregion
    }
}
