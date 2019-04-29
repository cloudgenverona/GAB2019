using DeepDive.Extension.SQLBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: WebJobsStartup(typeof(DeepBinding.Scalability.Startup))]
namespace DeepBinding.Scalability
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSqlBinding();
        }
    }
}
