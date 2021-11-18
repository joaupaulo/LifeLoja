using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLoja.Entidades;

namespace LifeLoja.RabbitServices
{
    public interface IRabbitServices
    {
        void ConnectMensage(Produtos produto);
    }
}
