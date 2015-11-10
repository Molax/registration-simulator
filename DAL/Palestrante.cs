using System;
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
    public class Palestrante
    {
        public DTO.Palestrante CreateNewPalestrante(DTO.Palestrante palestrante)
        {
            using (var db = new SemanaTecnologiaEntities())
            {
                var PalestranteRow = db.Palestrante.Create();

                PalestranteRow.NAME = palestrante.NAME;

                PalestranteRow.EMAIL = palestrante.EMAIL;

                PalestranteRow.CV = palestrante.CV;

                PalestranteRow.CITY = palestrante.CITY;

                PalestranteRow.TEL = palestrante.TEL;

                PalestranteRow.TITRATION = palestrante.TITRATION;

                db.Palestrante.Add(PalestranteRow);

                db.SaveChanges();

                palestrante.PK_PALESTRANTE = PalestranteRow.PK_PALESTRANTE;

                return palestrante;

            }
        }

        public List<DTO.Palestrante> GetAllPalestrantes()
        {
            using (var db = new SemanaTecnologiaEntities())
            {

                return db.Palestrante
                 .Select(c => new DTO.Palestrante()
                 {
                     CITY = c.CITY,
                     CV = c.CV,
                     EMAIL = c.EMAIL,
                     NAME = c.NAME,
                     TEL = c.TEL,
                     PK_PALESTRANTE = c.PK_PALESTRANTE,
                     TITRATION = c.TITRATION
                 })
                  .ToList();

            }
        }

        public DTO.Palestrante GetPalestranteById(int idPalestrante)
        {
            using (var db = new SemanaTecnologiaEntities())
            {
                return db.Palestrante
                    .Where(c => c.PK_PALESTRANTE == idPalestrante)
                    .Select(c => new DTO.Palestrante() {

                        CITY = c.CITY,
                        CV = c.CV,
                        EMAIL = c.EMAIL,
                        NAME = c.NAME,
                        PK_PALESTRANTE = c.PK_PALESTRANTE,
                        TITRATION = c.TITRATION,
                        TEL = c.TEL
                
                }).FirstOrDefault();
            }
        }
    }
}
