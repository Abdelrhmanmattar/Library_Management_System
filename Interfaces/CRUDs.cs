namespace Library_Management_System.Interfaces
{
    public interface CRUDs<T> where T : class
    {
        //CRUDs OPERATIONS
        /*
         * READ ALL
         * READ BY ID
         * DELETE
         * UPDATE
         * CREATE
         */
        public void Add(T entity);
        public void Remove(int id);
        public bool find(int id);
        public void Update(T entity);
        public List<T> Get_All();
        public T GetById(int id);
        public void Save();
    }
}
