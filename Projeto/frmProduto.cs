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
    public partial class frmProduto : Form
    {
        string stringConexao = "Data Source=localhost;Initial Catalog=t18_estoque;User ID=sa;Password=123456";

        public frmProduto()
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
            txtQtde.Text = "";
            txtCusto.Text = "";
            txtVenda.Text = "";
            txtObs.Text = "";
            cboStatus.SelectedIndex = -1;
            txtCodigo.Focus();
        }

        private void frmProduto_Load_1(object sender, EventArgs e)
        {
            TestarConexao();
        }

        private void btoExcluir_Click_1(object sender, EventArgs e)
        {
            string sql = "DELETE FROM produto WHERE ID_Produto = " + txtCodigo.Text;

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
            string sql = "UPDATE produto SET " +
                "nome_Produto = '" + txtNome.Text + "', " +
                "qtde_Produto = " + txtQtde.Text + ", " +
                "Vcusto_Produto = " + txtCusto.Text + ", " +
                "Vvenda_Produto = " + txtVenda.Text + ", " +
                "obs_Produto = '" + txtObs.Text + "', " +
                "status_Produto = '" + cboStatus.Text + "' " +
                "WHERE ID_Produto = " + txtCodigo.Text;

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
            string sql = "SELECT * FROM produto WHERE ID_Produto = " + txtCodigo.Text;

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
                    txtQtde.Text = leitura[3].ToString();
                    txtCusto.Text = leitura[4].ToString();
                    txtVenda.Text = leitura[5].ToString();
                    txtObs.Text = leitura[6].ToString();
                    cboStatus.Text = leitura[7].ToString();
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

        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO produto " +
                "(nome_Produto, qtde_Produto, Vcusto_Produto, Vvenda_Produto, obs_Produto, status_Produto)" +
                "values" +
                "('" + txtNome.Text + "', " + txtQtde.Text + ", " + txtCusto.Text + ", " + txtVenda.Text + ", '" + txtObs.Text + "', '" + cboStatus.Text + "')" +
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
