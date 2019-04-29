using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;

namespace DeepDive.Extension.SQLBinding
{
    public static class Extension
    {
        public static IWebJobsBuilder AddSqlBinding(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<SqlInputConfiguration>();
            builder.AddExtension<SqlOutputConfiguration>();
            return builder;
        }
    }
}
