using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLoja.Entidades;

namespace LifeLoja.GcpServices
{
    public interface IPubSubRepositorio
    {
         Task PublishMessageWithCustomAttributesAsync(Produtos produtos);
    }
}
