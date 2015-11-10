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
    public class Inscricao
    {
        public DTO.Inscricao CreateNewInscricao(DTO.Inscricao inscricao)
        {
            using (var db = new SemanaTecnologiaEntities())
            {
            
                var InscricaoROW = db.Inscricao.Create();

                InscricaoROW.CPF = inscricao.CPF;

                InscricaoROW.DATE = inscricao.DATE;

                db.Inscricao.Add(InscricaoROW);

                db.SaveChanges();

                inscricao.PK_INSCRICAO = InscricaoROW.PK_INSCRICAO;

                return inscricao;
            
            }
        }

        public DTO.Inscricao GetIdParticipantes(int idInscricao)
        {

            using (var db = new SemanaTecnologiaEntities())
            {
                return db.Inscricao
                    .Where(c => c.PK_INSCRICAO == idInscricao)
                    .Select(c => new DTO.Inscricao {
                
                    CPF = c.CPF,
                    DATE = c.DATE,
                    PK_INSCRICAO = c.PK_INSCRICAO
                
                }).FirstOrDefault();
            }
        
        }

        public List<DTO.Inscricao> GetIncricoesByParticipantes(string idAluno)
        {
            using (var db = new SemanaTecnologiaEntities())
            {

                return db.Inscricao
                    .Where(c => c.CPF == idAluno)
                    .Select(c => new DTO.Inscricao {

                        CPF = c.CPF,
                        DATE = c.DATE,
                        PK_INSCRICAO = c.PK_INSCRICAO

                }).ToList();

            }
        }
    }
}
