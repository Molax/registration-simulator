using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class Palestrante
    {

        private DAL.Palestrante _PalestranteDAL;

        public Palestrante()
        {

            if (_PalestranteDAL == null)
            {
                _PalestranteDAL = new DAL.Palestrante();
            }

        }

        public void CreateNewPalestrante(string nome, string titulacao, string cidade, string telefone, string email, string Cv)
        {
            DTO.Palestrante Palestrante = _PalestranteDAL.CreateNewPalestrante(new DTO.Palestrante()
            {
                NAME = nome,
                CITY = cidade,
                EMAIL = email,
                CV = Cv,
                TEL = telefone,
                TITRATION = titulacao
            });
        }


        public List<VIEWMODEL.Palestrantes> GetAllPalestrantes()
        {
            List<DTO.Palestrante> Palestrantes = _PalestranteDAL.GetAllPalestrantes();
            List<VIEWMODEL.Palestrantes> PalestrantesVM = new List<VIEWMODEL.Palestrantes>();

            foreach (var palestrante in Palestrantes)
            {
                PalestrantesVM.Add(new VIEWMODEL.Palestrantes() { idPalestrante = palestrante.PK_PALESTRANTE, Nome = palestrante.NAME });
            }

            return PalestrantesVM;
        }
    }
}
