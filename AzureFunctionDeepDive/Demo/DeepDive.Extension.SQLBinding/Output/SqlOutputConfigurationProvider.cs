using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepDive.Extension.SQLBinding
{
    public class SqlOutputConfiguration : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var bindingRule = context.AddBindingRule<SqlOutputBindingAttribute>();
            bindingRule.BindToCollector<IWriterEntity>(BuildFromAttribute);
        }

        private IAsyncCollector<IWriterEntity> BuildFromAttribute(SqlOutputBindingAttribute attribute)
        {
            var writer = new SqlOutputAsyncCollector<IWriterEntity>(attribute);
            return writer;
        }

    }
}
