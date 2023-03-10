using ApiProducts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Data.Repositorys
{
    public interface IProductsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Products>> GetProductsAsync();
        Task<Products> GetProductsById(int id);
        public List<Products> GetProductsByDescrption(string descrption);
    }
}
