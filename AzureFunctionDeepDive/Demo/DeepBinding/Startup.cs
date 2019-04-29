using DeepDive.Extension.SQLBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: WebJobsStartup(typeof(DeepBinding.Startup))]
namespace DeepBinding
{
    public class Startup : IWebJobsStartup
    {
        public Startup()
        {
            string azureStorage = Environment.GetEnvironmentVariable("AzureWebJobsStorage", EnvironmentVariableTarget.Process);
            Log.Logger = new LoggerConfiguration()
             .Enrich.FromLogContext()
             .WriteTo.AzureTableStorage(CloudStorageAccount.Parse(azureStorage))
             .CreateLogger();
        }

        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSqlBinding();
            ConfigureServices(builder.Services)
                .BuildServiceProvider(true);
        }

        private IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services
                .AddLogging(loggingBuilder =>
                    loggingBuilder.AddSerilog(dispose: true)
                );

            return services;
        }
    }
}
