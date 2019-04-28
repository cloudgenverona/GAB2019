using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DeepDive.Extension.SQLBinding
{
    internal class SqlResolutionPolicy : IResolutionPolicy
    {
        public string TemplateBind(PropertyInfo propInfo, Attribute resolvedAttribute, BindingTemplate bindingTemplate, IReadOnlyDictionary<string, object> bindingData)
        {
            if (bindingTemplate == null)
            {
                throw new ArgumentNullException(nameof(bindingTemplate));
            }

            if (bindingData == null)
            {
                throw new ArgumentNullException(nameof(bindingData));
            }

            var sqlServerAttribute = resolvedAttribute as SqlInputBindingAttribute;

            if (sqlServerAttribute == null)
            {
                throw new NotSupportedException($"This policy is only supported for {nameof(SqlInputBindingAttribute)}.");
            }

            var parameters = new List<SqlParameter>();
            var replacements = new Dictionary<string, object>();

            foreach (var token in bindingTemplate.ParameterNames.Distinct())
            {
                string sqlToken = $"@{token}";
                parameters.Add(new SqlParameter(sqlToken, bindingData[token]));
                replacements.Add(token, sqlToken);
            }

            sqlServerAttribute.Parameters = parameters;
            var replacement = bindingTemplate.Bind(new ReadOnlyDictionary<string, object>(replacements));

            return replacement;
        }
    }
}