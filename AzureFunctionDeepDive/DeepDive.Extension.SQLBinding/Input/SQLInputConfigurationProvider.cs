using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Collections.Generic;

namespace DeepDive.Extension.SQLBinding
{
   public class SqlInputConfiguration : IExtensionConfigProvider
   {
      public void Initialize(ExtensionConfigContext context)
      {
            var bindingRule = context.AddBindingRule<SqlInputBindingAttribute>();
            bindingRule.BindToInput<IEnumerable<OpenType>>(typeof(SqlInputEnumerableBuilder<>));
            bindingRule.BindToInput<OpenType>(typeof(SqlInputBuilder<>));
        }

   }
}
