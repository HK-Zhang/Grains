using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace ConsoleApp.DapperSql.Model
{
    [Table("glb_pais")]
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Uf> Ufs { get; set; }
    }
}