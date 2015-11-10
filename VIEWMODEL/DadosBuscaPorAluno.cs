using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEWMODEL
{
    public class DadosBuscaPorAluno
    {
        public DTO.Participante Participante { get; set; }

        public List<DTO.Evento> Eventos { get; set; }
    }
}
