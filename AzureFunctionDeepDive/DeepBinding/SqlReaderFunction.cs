using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DeepDive.Extension.SQLBinding;
using DeepBinding.Models;
using System.Collections.Generic;

namespace DeepBinding
{
   public class SqlReaderFunction
   {
        [FunctionName("SqlReader")]
        public IActionResult Run(
          [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "user/{id}")]
          HttpRequest req,
        
          [SqlInputBinding(Query = "SELECT * FROM TestData WHERE Id = {id}")]
          ReadModel entity,
          ILogger log)
        {
           log.LogInformation("C# HTTP trigger function processed a request.");
        
           return new OkObjectResult(entity);
        }

        [FunctionName("SqlReaderEnumerable")]
        public IActionResult RunEnumerable(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "user")]
        HttpRequest req,

        [SqlInputBinding(Query = "SELECT * FROM TestData")]
        IEnumerable<ReadModel> entities,
        ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(entities);
        }
    }
}
