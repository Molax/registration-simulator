using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class Participante
    {
        private DAL.Participante _ParticipanteDAL;

        public Participante()
        {

            if (_ParticipanteDAL == null)
            {
                _ParticipanteDAL = new DAL.Participante();
            }
        
        }

        public void CreateNewParticipante(string cpf, string nome, string curso, int periodo, string tel, string email, string login, string senha, string perfil)
        {
            DTO.Participante Participante = _ParticipanteDAL.CreateNewParticipante(new DTO.Participante(){
            
                PK_PARTICIPANTE = cpf,
                COURSE = curso,
                EMAIL = email,
                LOGIN = login,
                NAME = nome,
                PASSWORD = senha,
                PERIOD = periodo,
                PROFILE = perfil,
                TEL = tel
            
            });
        }

        public List<VIEWMODEL.Participantes> GetAllParticipantes()
        {
            List<DTO.Participante> Participantes = _ParticipanteDAL.GetAllPArticipantes();

            List<VIEWMODEL.Participantes> ParticipantesVM = new List<VIEWMODEL.Participantes>();

            foreach (var participante in Participantes)
            {
                ParticipantesVM.Add(new VIEWMODEL.Participantes() { idParticipante = participante.PK_PARTICIPANTE, NomeParticipante = participante.NAME });
            }

            return ParticipantesVM;

        }
    }
}
