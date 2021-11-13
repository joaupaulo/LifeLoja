using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLoja.DatabaseSettings;
using LifeLoja.Entidades;
using MongoDB.Driver;

namespace LifeLoja.Services
{
    public class ProdutosService 
    {

        private readonly IMongoCollection<Produtos> _context;

        public ProdutosService(IProdutoStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _context = database.GetCollection<Produtos>(settings.ProdutosCollectionName);
        }


        public async Task CreateProduct(Produtos product)
        {
            await _context.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Produtos> filter = Builders<Produtos>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }



        public async Task<IEnumerable<Produtos>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Produtos> filter = Builders<Produtos>.Filter.Eq(p => p.Category, categoryName);

            return await _context.Find(filter).ToListAsync();
        }

        public async Task<Produtos> GetProdut(string id)
        {
            return await _context.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Produtos>> GetProduto()
        {
            return await _context.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Produtos>> GetProdutoByName(string name)
        {
            FilterDefinition<Produtos> filter = Builders<Produtos>.Filter.ElemMatch(p => p.Name, name);

            return await _context.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Produtos product)
        {
            var updateResult = await _context.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

    }
}
