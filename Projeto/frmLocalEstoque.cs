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
    public partial class frmLocalEstoque : Form
    {
        string stringConexao = "Data Source=localhost;Initial Catalog=t18_estoque;User ID=sa;Password=123456";

        public frmLocalEstoque()
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
            txtObs.Text = "";
            cboStatus.SelectedIndex = -1;
            txtCodigo.Focus();
        }

        private void frmLocalEstoque_Load(object sender, EventArgs e)
        {
            TestarConexao();
        }

        private void btoExcluir_Click_1(object sender, EventArgs e)
        {
            string sql = "DELETE FROM LocalEstoque WHERE id_LocalEstoque = " + txtCodigo.Text;

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
            string sql = "UPDATE LocalEstoque SET " +
                "nome_LocalEstoque = '" + txtNome.Text + "', " +
                "obs_LocalEstoque = '" + txtObs.Text + "', " +
                "status_LocalEstoque = '" + cboStatus.Text + "' " +
                "WHERE id_LocalEstoque = " + txtCodigo.Text;

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
            string sql = "SELECT * FROM LocalEstoque WHERE id_LocalEstoque = " + txtCodigo.Text;

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
                    txtObs.Text = leitura[3].ToString();
                    cboStatus.Text = leitura[4].ToString();
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
            string sql = "INSERT INTO LocalEstoque " +
                "(nome_LocalEstoque, obs_LocalEstoque, status_LocalEstoque)" +
                "values" +
                "('" + txtNome.Text + "', '" + txtObs.Text + "', '" + cboStatus.Text + "')" +
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
