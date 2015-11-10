using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Salvar
    {

        private DAL.Inscricao _InscricaoDAL;

        private DAL.Insc_Evento _InscEventoDal;

        public Salvar()
        {

            if (_InscricaoDAL == null)
            {
                _InscricaoDAL = new DAL.Inscricao();
            }
            if (_InscEventoDal == null)
            {
                _InscEventoDal = new DAL.Insc_Evento();
            }

        }

        public void SalvarInscrivao()
        {

            //var eventoDTO = eventoDAL.CreateNewEvento();


        }


        public void CreateNewEvent(string cpf, int codigoEvento, DateTime dataInscricao)
        {
            var CodigoEvento = codigoEvento;

            DTO.Inscricao Inscricao = _InscricaoDAL.CreateNewInscricao(new DTO.Inscricao(){
            
                CPF = cpf,
                DATE = dataInscricao
            
            });

            DTO.Insc_Evento Inscricao_Evento = _InscEventoDal.CreateNewInscEvento( new DTO.Insc_Evento(){
            
                FK_EVENTO = CodigoEvento,
                FK_INSCRICAO = Inscricao.PK_INSCRICAO
            
            });
        }
    }
}
