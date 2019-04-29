using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace DeepDive.Extension.SQLBinding
{
    public interface IWriterEntity
    {
        [ExplicitKey]
        int Id { get; set; }
    }
}