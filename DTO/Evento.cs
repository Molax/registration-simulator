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
    public class Evento
    {
        public int PK_EVENT { get; set; }

        public string NAME { get; set; }

        public string LOCATION { get; set; }

        public DateTime DATE { get; set; }

        public string HOUR { get; set; }

        public string TYPE { get; set; }

        public string DESCRIPTION { get; set; }

        public int FK_PALESTRANTE { get; set; }

        public int NSLOTS { get; set; }

        public string START_TIME { get; set; }

        public string END_TIME { get; set; }
    }
}
