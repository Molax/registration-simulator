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
    public class Palestrante
    {
        public int PK_PALESTRANTE { get; set; }

        public string NAME { get; set; }

        public string TITRATION { get; set; }

        public string CV { get; set; }

        public string CITY { get; set; }

        public string TEL { get; set; }

        public string EMAIL { get; set; }
    }
}
