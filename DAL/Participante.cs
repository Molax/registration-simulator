using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DATA;

namespace DAL
{
    public class Participante
    {
        public DTO.Participante CreateNewParticipante(DTO.Participante participante)
        {
            using (var db = new SemanaTecnologiaEntities())
            {

                var ParticipanteROW = db.Participante.Create();

                ParticipanteROW.PK_PARTICIPANTE = participante.PK_PARTICIPANTE;

                ParticipanteROW.COURSE = participante.COURSE;

                ParticipanteROW.EMAIL = participante.EMAIL;

                ParticipanteROW.LOGIN = participante.LOGIN;

                ParticipanteROW.NAME = participante.NAME;

                ParticipanteROW.PASSWORD = participante.PASSWORD;

                ParticipanteROW.PERIOD = participante.PERIOD;

                ParticipanteROW.PROFILE = participante.PROFILE;

                ParticipanteROW.TEL = participante.TEL;

                db.Participante.Add(ParticipanteROW);

                db.SaveChanges();

                return participante;

            }
        }

        public List<DTO.Participante> GetAllPArticipantes()
        {
            using (var db = new SemanaTecnologiaEntities())
            {
                return db.Participante
              .Select(c => new DTO.Participante() {
              
                  COURSE = c.COURSE,
                  EMAIL = c.EMAIL,
                  LOGIN = c.LOGIN,
                  NAME = c.NAME,
                  PASSWORD = c.PASSWORD,
                  PERIOD = c.PERIOD,
                  PK_PARTICIPANTE = c.PK_PARTICIPANTE,
                  PROFILE = c.PROFILE,
                  TEL = c.TEL
              
              })
              .ToList();
            }
        }

        public DTO.Participante GetParticipante(string idParticipante)
        {
            using (var db = new SemanaTecnologiaEntities())
            {
                return db.Participante
                    .Where(c => c.PK_PARTICIPANTE == idParticipante)
                    .Select(c => new DTO.Participante {
                
                    COURSE = c.COURSE,
                    EMAIL = c.EMAIL,
                    NAME = c.NAME,
                    LOGIN = c.LOGIN,
                    PASSWORD = c.PASSWORD,
                    PERIOD = c.PERIOD,
                    PK_PARTICIPANTE = c.PK_PARTICIPANTE,
                    PROFILE = c.PROFILE,
                    TEL=c.TEL

                }).FirstOrDefault();


            }

        
        }
    }
}
