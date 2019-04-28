//using Microsoft.Azure.WebJobs;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace DeepDive.Extension.SQLBinding
//{
//    public class SqlOutputAsyncConverterBuilder<T> : IAsyncConverter<SqlOutputBindingAttribute, SqlOutputAsyncCollector<T>> where T : class
//    {
//        public Task<SqlOutputAsyncCollector<T>> ConvertAsync(SqlOutputBindingAttribute input, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(new SqlOutputAsyncCollector<T>(input));
//        }
//    }
//}
