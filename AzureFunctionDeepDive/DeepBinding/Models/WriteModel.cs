using Dapper.Contrib.Extensions;
using DeepDive.Extension.SQLBinding;

namespace DeepBinding.Models
{
    [Dapper.Contrib.Extensions.Table("Articoli")]
    public class WriteModel : IWriterEntity
    {
        [ExplicitKey]
        public int Id { get; set; }
        public string CodArticolo { get; set; }
        public decimal Prezzo { get; set; }
    }
}
