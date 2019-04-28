using Dapper;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepDive.Extension.SQLBinding
{
    internal class SqlInputBuilder<T> : IAsyncConverter<SqlInputBindingAttribute, T> where T : class
    {
        public async Task<T> ConvertAsync(SqlInputBindingAttribute input, CancellationToken cancellationToken)
        {
            var data = default(T);

            using (var connection = new SqlConnection(input.ConnectionString))
            {
                var parameters = new DynamicParameters(new { });
                input.Parameters.ForEach(param => parameters.Add(param.ParameterName, param.Value));

                data = await connection.QuerySingleAsync<T>(new CommandDefinition(input.Query, parameters)).ConfigureAwait(false);
            }

            return data;
        }
    }
}
