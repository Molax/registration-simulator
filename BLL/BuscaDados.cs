using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BuscaDados
    {
        private DAL.Insc_Evento _InscEventoDAL;

        private DAL.Participante _ParticipanteDAL;

        private DAL.Evento _EventoDAL;

        private DAL.Palestrante _PalestranteDAL;

        private DAL.Inscricao _InscricaoDAL;

        public BuscaDados()
        {
            if (_InscEventoDAL == null)
            {
                _InscEventoDAL = new DAL.Insc_Evento();
            }
            if(_ParticipanteDAL == null)
            {
                _ParticipanteDAL = new DAL.Participante();
            }
            if (_EventoDAL == null)
            {
                _EventoDAL = new DAL.Evento();
            }
            if (_PalestranteDAL == null)
            {
                _PalestranteDAL = new DAL.Palestrante();
            }
            if (_InscricaoDAL == null)
            {
                _InscricaoDAL = new DAL.Inscricao();
            }
        }

        public VIEWMODEL.DadosBuscaPorEvento GetAllEventosParticipantes(int idEvento)
        {
            VIEWMODEL.DadosBuscaPorEvento DadosEvento = new VIEWMODEL.DadosBuscaPorEvento();

            List<DTO.Participante> Participantes = new List<DTO.Participante>();

            List<DTO.Inscricao> idParticipantes = new List<DTO.Inscricao>();

            DadosEvento.Evento = _EventoDAL.GetEventoById(idEvento);

            DadosEvento.Palestrante = _PalestranteDAL.GetPalestranteById(DadosEvento.Evento.FK_PALESTRANTE);

            List<DTO.Insc_Evento> IdInscricoes = _InscEventoDAL.GetAllInscricoesByIdEvento(idEvento);

            foreach (var item in IdInscricoes)
            {
               idParticipantes.Add(_InscricaoDAL.GetIdParticipantes(item.FK_INSCRICAO));
            }

            foreach (var item in idParticipantes)
            {
                Participantes.Add(_ParticipanteDAL.GetParticipante(item.CPF));
            }

            DadosEvento.Participantes = Participantes;

            return DadosEvento;
        
        }

        public VIEWMODEL.DadosBuscaPorAluno GetAllInformacoesInscricao(string idAluno)
        {

            VIEWMODEL.DadosBuscaPorAluno EventosParticipante = new VIEWMODEL.DadosBuscaPorAluno();

            EventosParticipante.Participante = _ParticipanteDAL.GetParticipante(idAluno);

            List<DTO.Insc_Evento> InscricoesEvento = new List<DTO.Insc_Evento>();

            List<DTO.Inscricao> InscricoesParticipante = new List<DTO.Inscricao>();

            List<DTO.Evento> Eventos = new List<DTO.Evento>();

            InscricoesParticipante = _InscricaoDAL.GetIncricoesByParticipantes(idAluno);

            foreach (var item in InscricoesParticipante)
            {
                InscricoesEvento.Add(_InscEventoDAL.GetCodEventoById(item.PK_INSCRICAO));
            }

            foreach (var item in InscricoesEvento)
            {
                Eventos.Add(_EventoDAL.GetEventoById(item.FK_EVENTO));
            }

            EventosParticipante.Eventos = Eventos;

            return EventosParticipante;
        }
    }
}
