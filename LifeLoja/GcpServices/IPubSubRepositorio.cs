using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeLoja.GcpServices
{
    public interface IPubSubRepositorio
    {
        Task<int> PublishProtoMessagesAsync();
    }
}
