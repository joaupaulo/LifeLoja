using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LifeLoja.Entidades
{
    public class Produtos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Descrption { get; set; }
        public int  Price { get; set; }
        public int Amount { get; set; }
    }
}
