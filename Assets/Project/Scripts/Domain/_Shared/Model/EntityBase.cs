using System;

namespace Project.Domain.Shared {

    public abstract class EntityBase<T> {
        
        public T Id { get; }

        public EntityBase(T id) {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
