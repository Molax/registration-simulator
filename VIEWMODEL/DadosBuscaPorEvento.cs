using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEWMODEL
{
    public class DadosBuscaPorEvento
    {
        public DTO.Evento Evento { get; set; }

        public List<DTO.Participante> Participantes { get; set; }

        public DTO.Palestrante Palestrante { get; set; }
    }
}
