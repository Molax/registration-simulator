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
    public class Insc_Evento
    {
        public int FK_INSC_EVENTO { get; set; }

        public int FK_EVENTO { get; set; }

        public int FK_INSCRICAO { get; set; }
    }
}
