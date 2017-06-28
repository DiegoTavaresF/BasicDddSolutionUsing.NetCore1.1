namespace Domain.Base
{
    public class Entity<T> : IEntity<T>
    {
        protected Entity()
        {
            //Erros = new List<string>();
        }

        public bool Excluido { get; set; }

        public string ExcluidoPor { get; set; }

        public T Id { get; private set; }

        public void SetId(T id)
        {
            Id = id;
        }
    }
}