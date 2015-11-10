using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Classe DTO (Data Table Object) réplicas das tabelas no BD
    /// </summary>
    public class Inscricao
    {
        public int PK_INSCRICAO { get; set; }

        public string CPF { get; set; }

        public DateTime DATE { get; set; }
    }
}
