using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProdutoFakeData.ProdutosViewFake.ProdutosData
{
   public class ProdutosDataFake 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Descrption { get; set; }
        public string Price { get; set; }
        public int Amount { get; set; }
        
        public ProdutosDataFake()
        {


        }

        public ProdutosDataFake(string id, string name, string category, string description, string price, int amount)
        {
            Id = id;
           Name = name;
           Category = category;
            Descrption = description;
            Price = price;
            Amount = amount;



        }
    }


    

}
