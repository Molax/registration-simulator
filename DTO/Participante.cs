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
    public class Participante
    {
        public string PK_PARTICIPANTE { get; set; }

        public string NAME { get; set; }

        public string COURSE { get; set; }

        public int PERIOD { get; set; }

        public string TEL { get; set; }

        public string EMAIL { get; set; }

        public string LOGIN { get; set; }

        public string PASSWORD { get; set; }

        public string PROFILE { get; set; }
    }
}
