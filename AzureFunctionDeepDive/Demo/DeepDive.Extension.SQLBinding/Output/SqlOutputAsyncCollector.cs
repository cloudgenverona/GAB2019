using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepDive.Extension.SQLBinding
{
    public class SqlOutputAsyncCollector<T> : IAsyncCollector<T> where T: class
    {
        private readonly SqlOutputBindingAttribute attr;
        public SqlOutputAsyncCollector(SqlOutputBindingAttribute attr)
        {
            this.attr = attr;
        }
        public async Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
             using (IDbConnection connection = new SqlConnection(attr.ConnectionString))
            {
                try
                {
                    await connection.InsertAsync(item);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
            //throw new NotImplementedException();
        }
    }

    
}
