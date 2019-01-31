using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace ConsoleApp.DapperSql.Model
{
    [Table("GLB_Pais")]
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Uf> Ufs { get; set; }
    }
}