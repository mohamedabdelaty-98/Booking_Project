using System.Linq.Expressions;

namespace Booking_Project.Reposatory
{
    public interface ISlider : ICrudOperation<T> 
    {
        List<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);
        void insert(T Entity);
        void update(T Entity);
        void Delete(int id);
        int save();
    }

    public class T
    {
    }
}
