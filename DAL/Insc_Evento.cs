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
    public class Insc_Evento
    {
        public DTO.Insc_Evento CreateNewInscEvento(DTO.Insc_Evento insc_Evento)
        {
            using (var db = new SemanaTecnologiaEntities())
            {
                var Insc_EventoRow = db.Insc_Evento.Create();

                Insc_EventoRow.FK_EVENTO = insc_Evento.FK_EVENTO;

                Insc_EventoRow.FK_INSCRICAO = insc_Evento.FK_INSCRICAO;

                db.Insc_Evento.Add(Insc_EventoRow);

                db.SaveChanges();

                insc_Evento.FK_INSC_EVENTO = Insc_EventoRow.PK_INSC_EVENTO;

                return insc_Evento;
            }
        }

        public List<DTO.Insc_Evento> GetAllInscricoesByIdEvento(int idEvento)
        {
            using (var db = new SemanaTecnologiaEntities())
            {
                return db.Insc_Evento
                    .Where(c => c.FK_EVENTO == idEvento)
                    .Select(c => new DTO.Insc_Evento {

                FK_INSCRICAO = c.FK_INSCRICAO
                
                }).ToList();
            
            }
        }

        public DTO.Insc_Evento GetCodEventoById(int idInscricao)
        {
            using (var db = new SemanaTecnologiaEntities())
            {

                return db.Insc_Evento
                    .Where(c => c.FK_INSCRICAO == idInscricao)
                    .Select(c => new DTO.Insc_Evento {

                        FK_EVENTO = c.FK_EVENTO,
                        FK_INSCRICAO = c.FK_INSCRICAO,
                        FK_INSC_EVENTO = c.PK_INSC_EVENTO

                    }).FirstOrDefault();

            }
        }
    }
}
