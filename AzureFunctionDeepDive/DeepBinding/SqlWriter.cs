using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DeepBinding.Models;
using DeepDive.Extension.SQLBinding;

namespace DeepBinding
{
    public class SqlWriter
    {
        [FunctionName("SqlWriter")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [SqlOutputBinding]
            IAsyncCollector<WriteModel> sqlCollector,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            await sqlCollector.AddAsync(new WriteModel { Id = 2, CodArticolo = "Banane", Prezzo = 10 });

            return new OkObjectResult("Ok");
        }
    }
}
