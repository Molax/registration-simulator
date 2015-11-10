using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DATA;
using System.Data;

namespace DAL
{
    public class Evento
    {
        public DTO.Evento CreateNewEvento(DTO.Evento evento)
        {
            using (var db = new SemanaTecnologiaEntities())
            {

                var EventoRow = db.Evento.Create();

                EventoRow.DATE = evento.DATE;

                EventoRow.DESCRIPTION = evento.DESCRIPTION;

                EventoRow.END_TIME = evento.END_TIME;

                EventoRow.FK_PALESTRANTE = evento.FK_PALESTRANTE;

                EventoRow.HOUR = evento.HOUR;

                EventoRow.LOCATION = evento.LOCATION;

                EventoRow.NAME = evento.NAME;

                EventoRow.NSLOTS = evento.NSLOTS;

                EventoRow.START_TIME = evento.START_TIME;

                EventoRow.TYPE = evento.TYPE;

                db.Evento.Add(EventoRow);

                db.SaveChanges();

                evento.PK_EVENT = EventoRow.PK_EVENT;

                return evento;
            
            }
        }

        public List<DTO.Evento> GetAllEventos()
        {
            using (var db = new SemanaTecnologiaEntities())
            {
                return db.Evento
                    .Select(c => new DTO.Evento() {
                    
                        DATE = c.DATE,
                        DESCRIPTION = c.DESCRIPTION,
                        END_TIME = c.END_TIME,
                        FK_PALESTRANTE = c.FK_PALESTRANTE,
                        HOUR = c.HOUR,
                        LOCATION = c.LOCATION,
                        NAME = c.NAME,
                        NSLOTS = c.NSLOTS,
                        PK_EVENT = c.PK_EVENT,
                        START_TIME = c.START_TIME,
                        TYPE = c.START_TIME
                    
                    })
                    .ToList();
            }
        }

        public DTO.Evento GetEventoById(int idEvento)
        {
            using (var db = new SemanaTecnologiaEntities())
            {

                return db.Evento
                    .Where(c => c.PK_EVENT == idEvento)
                    .Select(c => new DTO.Evento() {

                       DATE = c.DATE,
                       DESCRIPTION = c.DESCRIPTION,
                       END_TIME = c.END_TIME,
                       FK_PALESTRANTE = c.FK_PALESTRANTE,
                       HOUR = c.HOUR,
                       LOCATION = c.LOCATION,
                       NAME = c.NAME,
                       NSLOTS = c.NSLOTS,
                       PK_EVENT = c.PK_EVENT,
                       START_TIME = c.START_TIME,
                       TYPE = c.TYPE
                
                }).FirstOrDefault();

            }
        }
    }
}
