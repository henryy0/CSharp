using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projeto
{
    public partial class frmFuncionario : Form
    {
        string stringConexao = "Data Source=localhost;Initial Catalog=t18_estoque;User ID=sa;Password=123456";

        public frmFuncionario()
        {
            InitializeComponent();
        }

        private void TestarConexao()
        {
            SqlConnection conexao = new SqlConnection(stringConexao);

            try
            {
                conexao.Open();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                Application.Exit();
            }
        }

        private void btoSair_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btoLimpar_Click_1(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtData.Text = "";
            txtNome.Text = "";
            txtNascimento.Text = "";
            txtCPF.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cboUF.SelectedIndex = -1;
            txtTelefone1.Text = "";
            txtTelefone2.Text = "";
            txtTelefone3.Text = "";
            txtTelefone4.Text = "";
            txtObs.Text = "";
            cboStatus.SelectedIndex = -1;
            txtCodigo.Focus();
        }

        private void frmFuncionairo_Load(object sender, EventArgs e)
        {
            TestarConexao();
        }

        private void btoExcluir_Click_1(object sender, EventArgs e)
        {
            string sql = "DELETE FROM funcionario WHERE ID_Funcionario = " + txtCodigo.Text;

            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.CommandType = CommandType.Text;

            conexao.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Dados excluídos com sucesso");
                }
                else
                {
                    MessageBox.Show("Erro: não foi possível excluir os dados");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btoAlterar_Click_1(object sender, EventArgs e)
        {
            string sql = "UPDATE funcionario SET " +
                "nome_Funcionario = '" + txtNome.Text + "', " +
                "nasc_Funcionario = '" + txtNascimento.Text + "', " +
                "cpf_Funcionario = '" + txtCPF.Text + "', " +
                "logradouro_Funcionario = '" + txtLogradouro.Text + "', " +
                "numero_Funcionario = '" + txtNumero.Text + "', " +
                "comp_funcionario = '" + txtComplemento.Text + "', " +
                "cep_Funcionario = '" + txtCEP.Text + "', " +
                "bairro_Funcionario = '" + txtBairro.Text + "', " +
                "cidade_Funcionario = '" + txtCidade.Text + "', " +
                "uf_Funcionario = '" + cboUF.Text + "', " +
                "telefone1_Funcionario = '" + txtTelefone1.Text + "', " +
                "telefone2_Funcionario = '" + txtTelefone2.Text + "', " +
                "telefone3_Funcionario = '" + txtTelefone3.Text + "', " +
                "telefone4_Funcionario = '" + txtTelefone4.Text + "', " +
                "obs_Funcionario = '" + txtObs.Text + "', " +
                "status_Funcionario = '" + cboStatus.Text + "' " +
                "WHERE ID_Funcionario = " + txtCodigo.Text;

            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.CommandType = CommandType.Text;

            conexao.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Dados alterados com sucesso");
                }
                else
                {
                    MessageBox.Show("Erro: não foi possível alterar os dados");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void botPesquisar_Click_1(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM funcionario WHERE ID_Funcionario = " + txtCodigo.Text;

            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            conexao.Open();

            try
            {
                leitura = cmd.ExecuteReader();
                if (leitura.Read())
                {
                    txtCodigo.Text = leitura[0].ToString();
                    txtNome.Text = leitura[1].ToString();
                    txtData.Text = leitura[2].ToString();
                    txtNascimento.Text = leitura[3].ToString();
                    txtCPF.Text = leitura[4].ToString();
                    txtLogradouro.Text = leitura[5].ToString();
                    txtNumero.Text = leitura[6].ToString();
                    txtComplemento.Text = leitura[7].ToString();
                    txtCEP.Text = leitura[8].ToString();
                    txtBairro.Text = leitura[9].ToString();
                    txtCidade.Text = leitura[10].ToString();
                    cboUF.Text = leitura[11].ToString();
                    txtTelefone1.Text = leitura[12].ToString();
                    txtTelefone2.Text = leitura[13].ToString();
                    txtTelefone3.Text = leitura[14].ToString();
                    txtTelefone4.Text = leitura[15].ToString();
                    txtObs.Text = leitura[16].ToString();
                    cboStatus.Text = leitura[17].ToString();
                }
                else
                {
                    MessageBox.Show("Erro: código não encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btoCadastrar_Click_1(object sender, EventArgs e)
        {
            string sql = "INSERT INTO funcionario " +
                "(nome_Funcionario, nasc_Funcionario, cpf_Funcionario, logradouro_Funcionario, " +
                "numero_Funcionario, comp_funcionario, cep_Funcionario, bairro_Funcionario, cidade_Funcionario, " +
                "uf_Funcionario, telefone1_Funcionario, telefone2_Funcionario, telefone3_Funcionario, telefone4_Funcionario, " +
                "obs_Funcionario, status_Funcionario)" +
                "values" +
                "('" + txtNome.Text + "','" + txtNascimento.Text + "','" + txtCPF.Text + "','" + txtLogradouro.Text + "','" + txtNumero.Text + "','" + txtComplemento.Text + "','" + txtCEP.Text + "','" + txtBairro.Text + "','" + txtCidade.Text + "','" + cboUF.Text + "','" + txtTelefone1.Text + "','" + txtTelefone2.Text + "','" + txtTelefone3.Text + "','" + txtTelefone4.Text + "','" + txtObs.Text + "','" + cboStatus.Text + "')" +
                "select scope_identity()";

            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            conexao.Open();

            try
            {
                leitura = cmd.ExecuteReader();

                if (leitura.Read())
                {
                    btoLimpar.PerformClick();

                    txtCodigo.Text = leitura[0].ToString();
                    MessageBox.Show("Cadastro realizado com sucesso");

                    botPesquisar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
