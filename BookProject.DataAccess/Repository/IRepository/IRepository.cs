using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.DataAccess.Repository.IRepository
{
    public interface IRepository<T>
    {
        // Read
        List<T> GetAllData();
        List<T> Search(string SerachItem);
        T Find(int Id);

        //Write
        void Add(T table);
        void Edit(int Id,T table);
        void Delete(int Id);
    }
}
