using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using ProdutoFakeData.ProdutosViewFake.ProdutosData;

namespace ProdutosFakeData.ProdutosViewFake
{
   public class ProdutosViewFaker :  Faker<ProdutosDataFake>
    {

        public ProdutosViewFaker()
        {
           
            RuleFor(p => p.Id, f => f.Random.Hash());
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Category, f => f.Commerce.ProductMaterial());
            RuleFor(p => p.Descrption, f => f.Commerce.ProductDescription());
            RuleFor(p => p.Price, f => f.Commerce.Price(10, 100, 2, "R$   "));
            RuleFor(p => p.Amount, f => f.Commerce.Random.Odd(1,100));
        }

    }
}
