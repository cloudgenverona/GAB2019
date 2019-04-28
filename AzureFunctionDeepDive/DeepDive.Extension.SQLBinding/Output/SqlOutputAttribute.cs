using Microsoft.Azure.WebJobs.Description;
using System;
using System.ComponentModel.DataAnnotations;

namespace DeepDive.Extension.SQLBinding
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class SqlOutputBindingAttribute : Attribute
    {
        [AppSetting(Default = "SqlOutputConnectionString")]
        [Required]
        public string ConnectionString { get; set; }

        //[AutoResolve]
        //[Required]
        //public string Query { get; set; }

        //internal List<SqlParameter> Parameters { get; set; }
    }
    
}
