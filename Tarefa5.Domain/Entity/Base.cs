using System;

namespace Tarefa5.Domain.Entity
{
    public abstract class Base
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? RemovedDate { get; private set; }
        public bool Removed { get; private set; }

        protected Base()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            Removed = false;
        }

        public virtual void Update()
        {
            UpdatedDate = DateTime.UtcNow;
        }

        public virtual void Remove()
        {
            RemovedDate = DateTime.UtcNow;
            Removed = true;
        }
    }
}
