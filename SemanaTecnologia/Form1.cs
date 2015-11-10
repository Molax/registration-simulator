using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemanaTecnologia
{
    public partial class Form1 : Form
    {
        #region Váriaveis privadas de negócio
        private BLL.Palestrante _PalestranteBLL;

        private BLL.Evento _EventoBLL;

        private BLL.Participante _ParticipanteBLL;

        private BLL.Salvar _SalvarBLL;

        private BLL.BuscaDados _BuscaDadosBLL;

        #endregion

        public Form1()
        {
            #region Construtores
            InitializeComponent();

            if (_PalestranteBLL == null)
            {

                _PalestranteBLL = new BLL.Palestrante();

            }

            if (_ParticipanteBLL == null)
            {

                _ParticipanteBLL = new BLL.Participante();

            }

            if (_EventoBLL == null)
            {

                _EventoBLL = new BLL.Evento();

            }

            if (_SalvarBLL == null)
            {
                _SalvarBLL = new BLL.Salvar();
            }

            if (_BuscaDadosBLL == null)
            {
                _BuscaDadosBLL = new BLL.BuscaDados();
            }


            tabControl2.SelectedIndexChanged += new EventHandler(tabControl2_SelectedIndexChanged);

            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);

            PopulaCamposPadores();

            PopulaComboBoxPalestrantes();

            lblerroEvento.Hide();

            lblerroPalestrante.Hide();

            lblerroParticipante.Hide();

        }

            #endregion

        #region Cadastro/Verificação de Palestrante
        private void btnCadastrarPalestrante_Click(object sender, EventArgs e)
        {
            if (VerificaCamposPalestrante())
            {
                lblerroPalestrante.Hide();
                _PalestranteBLL.CreateNewPalestrante(tbNomePalestrante.Text, tbTitulacaoPalestrante.Text, tbCidadePalestrante.Text, tbTelPalestrante.Text, tbEmailPalestrante.Text, tbMiniCVPalestrante.Text);
                MessageBox.Show("Palestrante Cadastrado com sucesso !", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                LimparFichaPalestrante();
            }

        }

        private bool VerificaCamposPalestrante()
        {
            lblerroPalestrante.ForeColor = Color.Red;
            lblerroPalestrante.Show();

            if (String.IsNullOrEmpty(tbNomePalestrante.Text) || String.IsNullOrEmpty(tbTitulacaoPalestrante.Text) || String.IsNullOrEmpty(tbCidadePalestrante.Text) ||
                String.IsNullOrEmpty(tbTelPalestrante.Text) || String.IsNullOrEmpty(tbEmailPalestrante.Text) || String.IsNullOrEmpty(tbMiniCVPalestrante.Text))
            {
                lblerroPalestrante.Text = "Todos os campos devem ser preenchidos";
                return false;
            }
            else
            {
                return true;
            }

        }

        private void LimparFichaPalestrante()
        {
            tbNomePalestrante.Clear();
            tbTitulacaoPalestrante.Clear();
            tbCidadePalestrante.Clear();
            tbTelPalestrante.Clear();
            tbEmailPalestrante.Clear();
            tbMiniCVPalestrante.Clear();
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparFichaPalestrante();
        }
        #endregion

        #region Cadastro Evento
        private void btnCadastrarEvento_Click(object sender, EventArgs e)
        {

            if (VerificaCamposEvento())
            {
                lblerroEvento.Hide();
                _EventoBLL.CreateNewEvento(tbNomeEvento.Text, tbLocalEvento.Text, Convert.ToDateTime(dtDataEvento.Text).Date, dtHoraEvento.Text, cbTipoEvento.Text, dtInicioEvento.Text,
                dtFimEvento.Text, Convert.ToInt32(cbPalestranteEvento.SelectedValue), tbDescricaoEvento.Text, Convert.ToInt32(tbVagasEvento.Text));

                MessageBox.Show("Evento Cadastrado com sucesso !", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);

                LimparCamposEvento();
            }

        }

        private void LimparCamposEvento()
        {

            tbNomeEvento.Clear();

            tbLocalEvento.Clear();

            tbVagasEvento.Clear();

            tbDescricaoEvento.Clear();

        }

        private bool VerificaCamposEvento()
        {
            lblerroEvento.ForeColor = Color.Red;

            if (String.IsNullOrEmpty(tbNomeEvento.Text) || String.IsNullOrEmpty(tbLocalEvento.Text) || String.IsNullOrEmpty(tbVagasEvento.Text)
                || String.IsNullOrEmpty(tbDescricaoEvento.Text) || String.IsNullOrEmpty(tbVagasEvento.Text))
            {
                lblerroEvento.Text = "Favor preencher todos os campos";
                lblerroEvento.Show();
                return false;
            }
            else if (verificaNumeros(tbVagasEvento.Text) == false)
            {
                lblerroEvento.Text = "Campo VAGAS só pode conter números";
                lblerroEvento.Show();
                return false;
            }
            else 
            { 
                return true;
            }

        }


        private void btnLimparCamposEvento_Click(object sender, EventArgs e)
        {
            LimparCamposEvento();
        }

        #endregion

        #region Cadastro Participante
        private void btnCadastrarParticipante_Click(object sender, EventArgs e)
        {
            if (VerificaCamposParticipante())
            {
                lblerroParticipante.Hide();
                _ParticipanteBLL.CreateNewParticipante(mtbCpfParticipante.Text, tbNomeParticipante.Text, tbCursoParticipante.Text, Convert.ToInt32(cbPeriodoParticipante.Text), tbTelParticipante.Text, tbEmailParticipante.Text, tbLoginParticipante.Text, tbSenhaParticipante.Text, cbPerfilParticipante.Text);
                MessageBox.Show("Participante Cadastrado com sucesso !", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);

                LimpaFichaParticipante();
            }
        }

        private bool VerificaCamposParticipante()
        {
            lblerroParticipante.ForeColor = Color.Red;
            lblerroParticipante.Show();

            if (String.IsNullOrEmpty(mtbCpfParticipante.Text) || String.IsNullOrEmpty(tbNomeParticipante.Text) || String.IsNullOrEmpty(tbCursoParticipante.Text) || String.IsNullOrEmpty(tbTelParticipante.Text) ||
            String.IsNullOrEmpty(tbEmailParticipante.Text) || String.IsNullOrEmpty(tbLoginParticipante.Text) || String.IsNullOrEmpty(tbSenhaParticipante.Text))
            {
                lblerroParticipante.Text = "Todos os campos devem ser preenchidos";
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnLimparCamposParticipante_Click(object sender, EventArgs e)
        {
            LimpaFichaParticipante();
        }

        private void LimpaFichaParticipante()
        {
            mtbCpfParticipante.Clear();
            tbNomeParticipante.Clear();
            tbCursoParticipante.Clear();
            tbTelParticipante.Clear();
            tbEmailParticipante.Clear();
            tbLoginParticipante.Clear();
            tbEmailParticipante.Clear();
            tbSenhaParticipante.Clear();
        }
        #endregion

        #region Cadastro de Inscrição
        private void btnCadastrarInscricao_Click(object sender, EventArgs e)
        {
            _SalvarBLL.CreateNewEvent(Convert.ToString(cboParticipantesInscricao.SelectedValue), Convert.ToInt32(cbEventoInscricao.SelectedValue), DateTime.Now);
            MessageBox.Show("Inscrição Cadastrada com sucesso !", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        #endregion

        #region Popula Combobox
        private void PopulaComboBoxPalestrantes()
        {
            List<VIEWMODEL.Palestrantes> Palestrantes = _PalestranteBLL.GetAllPalestrantes();

            cbPalestranteEvento.DataSource = Palestrantes;
            cbPalestranteEvento.DisplayMember = "Nome";
            cbPalestranteEvento.ValueMember = "idPalestrante";

            List<VIEWMODEL.Participantes> Participantes = _ParticipanteBLL.GetAllParticipantes();

            cboParticipantesInscricao.DataSource = Participantes;
            cboParticipantesInscricao.DisplayMember = "NomeParticipante";
            cboParticipantesInscricao.ValueMember = "idParticipante";

            cboInscricaoConsulta.DataSource = Participantes;
            cboInscricaoConsulta.DisplayMember = "NomeParticipante";
            cboInscricaoConsulta.ValueMember = "idParticipante";

            List<VIEWMODEL.Eventos> Eventos = _EventoBLL.GetAllEventos();
            cbEventoInscricao.DataSource = Eventos;
            cbEventoInscricao.DisplayMember = "NomeEvento";
            cbEventoInscricao.ValueMember = "idEvento";

            cboEventosBusca.DataSource = Eventos;
            cboEventosBusca.DisplayMember = "NomeEvento";
            cboEventosBusca.ValueMember = "idEvento";
        }

        private void PopulaCamposPadores()
        {
            cbTipoEvento.Items.Add("MiniCurso");
            cbTipoEvento.Items.Add("Palestra");
            cbPeriodoParticipante.Text = "1";
            cbTipoEvento.SelectedItem = "MiniCurso";
            cbPerfilParticipante.Items.Add("Administrador");
            cbPerfilParticipante.Items.Add("Aluno");
            cbPerfilParticipante.SelectedItem = "Administrador";
            for (int i = 1; i < 11; i++)
            {
                cbPeriodoParticipante.Items.Add(i);
            }
        }
        #endregion

        #region Ação de Mudar de Abas
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    PopulaComboBoxPalestrantes();
                    break;
                case 1:
                    PopulaComboBoxPalestrantes();
                    break;
                case 3:
                    PopulaComboBoxPalestrantes();
                    break;
                case 4:
                    PopulaComboBoxPalestrantes();
                    break;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    PopulaComboBoxPalestrantes();
                    break;
                case 1:
                    PopulaComboBoxPalestrantes();
                    break;
            }
        }
        #endregion

        #region Verifica campo que só pode conter números
        private bool verificaNumeros(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        #endregion

        #region Busca de Informações
        private void btnTesteBusca_Click(object sender, EventArgs e)
        {
            VIEWMODEL.DadosBuscaPorEvento DadosGridParticipantes = _BuscaDadosBLL.GetAllEventosParticipantes(Convert.ToInt32(cboEventosBusca.SelectedValue));

            List<DTO.Evento> Evento = new List<DTO.Evento>();

            Evento.Add(DadosGridParticipantes.Evento);

            dataGridViewEventos.DataSource = Evento;

            setHeaderGDEventoEvento();

            dataGridViewParticipantesEvento.DataSource = DadosGridParticipantes.Participantes;

            setHeaderGDParticipantesEvento();
        }

        #endregion

        private void btnConsultaInscricao_Click(object sender, EventArgs e)
        {
            VIEWMODEL.DadosBuscaPorAluno DadosGrid = _BuscaDadosBLL.GetAllInformacoesInscricao(Convert.ToString(cboInscricaoConsulta.SelectedValue));

            List<DTO.Participante> Participante = new List<DTO.Participante>();

            Participante.Add(DadosGrid.Participante);

            dataGridViewUsuario.DataSource = Participante;

            setHeaderGDParticipantesInscricao();

            dataGridViewInscric.DataSource = DadosGrid.Eventos;

            setHeaderGDEventosInscricao();

        }

        private void setHeaderGDParticipantesInscricao()
        {
            dataGridViewUsuario.Columns[0].HeaderText = "Id";

            dataGridViewUsuario.Columns[1].HeaderText = "Nome";

            dataGridViewUsuario.Columns[2].HeaderText = "Curso";

            dataGridViewUsuario.Columns[3].HeaderText = "Periodo";

            dataGridViewUsuario.Columns[4].HeaderText = "Telefone";

            dataGridViewUsuario.Columns[5].HeaderText = "E-Mail";

            dataGridViewUsuario.Columns[6].HeaderText = "Login";

            dataGridViewUsuario.Columns[7].HeaderText = "Senha";

            dataGridViewUsuario.Columns[8].HeaderText = "Profile";
        }

        private void setHeaderGDEventosInscricao()
        {
            dataGridViewInscric.Columns[0].HeaderText = "Id";

            dataGridViewInscric.Columns[1].HeaderText = "Nome";

            dataGridViewInscric.Columns[2].HeaderText = "Localização";

            dataGridViewInscric.Columns[3].HeaderText = "Data";

            dataGridViewInscric.Columns[4].HeaderText = "Hora";

            dataGridViewInscric.Columns[5].HeaderText = "Tipo";

            dataGridViewInscric.Columns[6].HeaderText = "Descrição";

            dataGridViewInscric.Columns[7].HeaderText = "Id Palestrante";

            dataGridViewInscric.Columns[8].HeaderText = "Vagas";

            dataGridViewInscric.Columns[9].HeaderText = "Hora Inicio";

            dataGridViewInscric.Columns[10].HeaderText = "Hora Fim";

        }

        private void setHeaderGDEventoEvento()
        {
            dataGridViewEventos.Columns[0].HeaderText = "Id";

            dataGridViewEventos.Columns[1].HeaderText = "Nome";

            dataGridViewEventos.Columns[2].HeaderText = "Localização";

            dataGridViewEventos.Columns[3].HeaderText = "Data";

            dataGridViewEventos.Columns[4].HeaderText = "Hora";

            dataGridViewEventos.Columns[5].HeaderText = "Tipo";

            dataGridViewEventos.Columns[6].HeaderText = "Descrição";

            dataGridViewEventos.Columns[7].HeaderText = "Id Palestrante";

            dataGridViewEventos.Columns[8].HeaderText = "Vagas";

            dataGridViewEventos.Columns[9].HeaderText = "Hora Inicio";

            dataGridViewEventos.Columns[10].HeaderText = "Hora Fim";
        }

        private void setHeaderGDParticipantesEvento()
        {
            dataGridViewParticipantesEvento.Columns[0].HeaderText = "Id";

            dataGridViewParticipantesEvento.Columns[1].HeaderText = "Nome";

            dataGridViewParticipantesEvento.Columns[2].HeaderText = "Curso";

            dataGridViewParticipantesEvento.Columns[3].HeaderText = "Periodo";

            dataGridViewParticipantesEvento.Columns[4].HeaderText = "Telefone";

            dataGridViewParticipantesEvento.Columns[5].HeaderText = "E-Mail";

            dataGridViewParticipantesEvento.Columns[6].HeaderText = "Login";

            dataGridViewParticipantesEvento.Columns[7].HeaderText = "Senha";

            dataGridViewParticipantesEvento.Columns[8].HeaderText = "Profile";
        }

    }
}
