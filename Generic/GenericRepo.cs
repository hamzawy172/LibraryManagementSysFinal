using LibraryManagementSys.Data;

namespace LibraryManagementSys.Generic
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly MyContext c;
        public GenericRepo(MyContext c) 
        {
            this.c = c;
        }

        public void Add(T item)
        {
            c.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            var data = c.Set<T>().Find(id);
            c.Set<T>().Remove(data);
        }

        public List<T> GetAll()
        {
            return c.Set<T>().ToList(); 
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public void Update(T item)
        {
           c.Set<T>().Update(item);
        }
    }
}
