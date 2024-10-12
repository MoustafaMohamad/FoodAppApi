using FoodAppApi.Models;

namespace FoodAppApi.Repositories
{
    public interface IBaseRepository<T> where T: BaseModel
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(int id);
 
        void SaveChanges();
    }
}
