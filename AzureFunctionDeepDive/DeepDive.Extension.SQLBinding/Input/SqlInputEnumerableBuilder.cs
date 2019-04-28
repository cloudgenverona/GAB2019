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
    internal class SqlInputEnumerableBuilder<T> : IAsyncConverter<SqlInputBindingAttribute, IEnumerable<T>> where T : class
    {
        public async Task<IEnumerable<T>> ConvertAsync(SqlInputBindingAttribute input, CancellationToken cancellationToken)
        {
            var data = default(IEnumerable<T>);

            using (var connection = new SqlConnection(input.ConnectionString))
            {
                var parameters = new DynamicParameters(new { });
                input.Parameters.ForEach(param => parameters.Add(param.ParameterName, param.Value));

                data = await connection.QueryAsync<T>(new CommandDefinition(input.Query, parameters)).ConfigureAwait(false);
            }

            return data ?? System.Linq.Enumerable.Empty<T>();
        }
    }
}
