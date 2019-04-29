using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text;

namespace DeepDive.Extension.SQLBinding
{
   [Binding]
   [AttributeUsage(AttributeTargets.Parameter)]
   public sealed class SqlInputBindingAttribute : Attribute
   {
      [AppSetting(Default = "SqlInputConnectionString")]
      [Required]
      public string ConnectionString { get; set; }

      [AutoResolve(ResolutionPolicyType = typeof(SqlResolutionPolicy))]
      [Required]
      public string Query { get; set; }

      internal List<SqlParameter> Parameters { get; set; }
   }
}
