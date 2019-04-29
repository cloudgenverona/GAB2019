using System;
using System.Threading.Tasks;
using DeepDive.Extension.SQLBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace DeepBinding.Scalability
{
    public class QueueLoader
    {
        [FunctionName("QueueLoader")]
        public async Task Run(
            [QueueTrigger("scalabilityqueue", Connection = "AzureWebJobsStorage")] CloudQueueMessage myQueueItem,
            [SqlOutputBinding]
            IAsyncCollector<ImportEntity> collector,
            ILogger log)
        {
            var e = JsonConvert.DeserializeObject<ImportEntity>(myQueueItem.AsString);
            await collector.AddAsync(e);
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
