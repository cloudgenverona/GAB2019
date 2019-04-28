using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DeepBinding.Models;
using DeepDive.Extension.SQLBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DeepBinding
{
    public class BlobBatchInsert
    {
        [FunctionName("BlobBatchInsert")]
        public async Task Run(
            [BlobTrigger("batchinsert/{name}", Connection = "")]Stream jsonBlob, string name,
            [SqlOutputBinding]
            IAsyncCollector<WriteModel> sqlCollector,
            ILogger log)
        {
            //log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            IEnumerable<WriteModel> modelsToWrite = null;
            using (var stream = new StreamReader(jsonBlob))
            {
                string content = await stream.ReadToEndAsync();
                modelsToWrite = JsonConvert.DeserializeObject<IEnumerable<WriteModel>>(content);
            }
            foreach (var model in modelsToWrite)
            {
                await sqlCollector.AddAsync(model);
            }
        }
    }
}
