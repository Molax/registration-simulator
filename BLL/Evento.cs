using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class Evento
    {
        private DAL.Evento _Evento;

        public Evento()
        {

            if (_Evento == null)
            {
                _Evento = new DAL.Evento();
            }
        
        }

        public void CreateNewEvento(string nome,string local, DateTime data,string hora, string tipo, string horainicio,string horafim, int palestrante , string descricao,int vagas)
        {

            DTO.Evento Evento = _Evento.CreateNewEvento(new DTO.Evento() {
            
                DATE = data,
                DESCRIPTION = descricao,
                END_TIME = horafim,
                HOUR = hora,
                LOCATION = local,
                NAME = nome,
                NSLOTS = vagas,
                FK_PALESTRANTE = palestrante,
                START_TIME = horainicio,
                TYPE = tipo
            
            });
        }

        public List<VIEWMODEL.Eventos> GetAllEventos()
        {
            List<DTO.Evento> Eventos = _Evento.GetAllEventos();
            List<VIEWMODEL.Eventos> EventosVM = new List<VIEWMODEL.Eventos>();

            foreach (var evento in Eventos)
            {
                EventosVM.Add(new VIEWMODEL.Eventos() { NomeEvento = evento.NAME, idEvento = evento.PK_EVENT });
            }

            return EventosVM;
        }
    }
}
