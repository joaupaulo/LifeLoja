using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLoja.Entidades;

namespace LifeLoja.Services
{
    public interface IProdutosService
    {
        Task<IEnumerable<Produtos>> GetProduto();
        Task<Produtos> GetProdut(string id);
        Task<IEnumerable<Produtos>> GetProdutoByName(string name);
        Task<IEnumerable<Produtos>> GetProductByCategory(string categoryName);
        Task CreateProduct(Produtos product);
        Task<bool> UpdateProduct(Produtos product);
        Task<bool> DeleteProduct(string id);
    }
}
