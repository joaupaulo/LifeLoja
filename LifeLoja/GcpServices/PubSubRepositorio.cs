using Google.Apis.Util;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using LifeLoja.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LifeLoja.GcpServices
{
    public class PubSubRepositorio : IPubSubRepositorio
    {

        private string projectId = "windy-cedar-332513";
        private string topicId = "projects/windy-cedar-332513/topics/LifeLoja";

        public async Task PublishMessageWithCustomAttributesAsync( Produtos produtos)
        {
            TopicName topicName = TopicName.FromProjectTopic(projectId, topicId);
            PublisherClient publisher = await PublisherClient.CreateAsync(topicName);
            var messagem = "";
           
            messagem = System.Text.Json.JsonSerializer.Serialize(produtos);
 
            string message = await publisher.PublishAsync(messagem);
          

        }

        
    }
}
