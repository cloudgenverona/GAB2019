using System.IO;
using System.Threading.Tasks;
using DeepBinding.Scalability.Model;
using FlatFile.Delimited.Implementation;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace DeepBinding.Scalability
{
    public class BlobLoader
    {
        [FunctionName("BlobLoader")]
        public async Task Run(
            [BlobTrigger("scalability/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name,
            [Queue("scalabilityqueue", Connection = "AzureWebJobsStorage")] IAsyncCollector<ImportEntity> queueCollector,
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            var layout = new ImportDelimeterLayout();
            var factory = new DelimitedFileEngineFactory();
            using (var stream = myBlob)
            {
                var flatFile = factory.GetEngine(layout);
                var records = flatFile.Read<ImportEntity>(stream);
                foreach (var item in records)
                {
                    await queueCollector.AddAsync(item);
                }
            }
        }
    }

   
}
