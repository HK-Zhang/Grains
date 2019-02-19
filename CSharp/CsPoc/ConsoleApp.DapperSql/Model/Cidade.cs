using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace ConsoleApp.DapperSql.Model
{

    [Table("GLB_Cidade")]
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        public int Id_GLB_UF { get; set; }

        public string Nome { get; set; }

        public Uf Uf { get; set; }
    }
}
