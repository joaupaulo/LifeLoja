using Google.Apis.Util;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LifeLoja.GcpServices
{
    public class PubSubRepositorio
    {





        public async Task<int> PublishProtoMessagesAsync(string projectId, string topicId, IEnumerable<AvroUtilities.State> messageStates)
        {
            TopicName topicName = TopicName.FromProjectTopic(projectId, topicId);
            PublisherClient publisher = await PublisherClient.CreateAsync(topicName);

            PublisherServiceApiClient publishApi = PublisherServiceApiClient.Create();
            var topic = publishApi.GetTopic(topicName);

            int publishedMessageCount = 0;
            var publishTasks = messageStates.Select(async state =>
            {
                try
                {
                    string messageId = null;
                    switch (topic.SchemaSettings.Encoding)
                    {
                        case Encoding.Binary:
                            var binaryMessage = state.ToByteString();
                            messageId = await publisher.PublishAsync(binaryMessage);
                            break;
                        case Encoding.Json:
                            var jsonMessage = JsonFormatter.Default.Format(state);
                            messageId = await publisher.PublishAsync(jsonMessage);
                            break;
                    }
                    Console.WriteLine($"Published message {messageId}");
                    Interlocked.Increment(ref publishedMessageCount);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"An error ocurred when publishing message {state}: {exception.Message}");
                }
            });
            await Task.WhenAll(publishTasks);
            return publishedMessageCount;
        }

    }
}
