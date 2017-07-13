namespace Domain.Base
{
    public class Entity<T> : MainError, IEntity<T>
    {
        protected Entity()
        {
        }

        public bool Deleted { get; set; }

        public T Id { get; private set; }

        public void SetId(T id)
        {
            Id = id;
        }
    }
}