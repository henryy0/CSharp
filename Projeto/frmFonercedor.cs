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
    public partial class frmFonercedor : Form
    {
        string stringConexao = "Data Source=localhost;Initial Catalog=t18_estoque;User ID=sa;Password=123456";

        public frmFonercedor()
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
            txtCPNJ.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtContato.Text = "";
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

        private void frmFonercedor_Load_1(object sender, EventArgs e)
        {
            TestarConexao();
        }

        private void btoExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Fornecedor WHERE ID_Fornecedor = " + txtCodigo.Text;

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

        private void btoAlterar_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Fornecedor SET " +
                "nome_Fornecedor = '" + txtNome.Text + "', " +
                "nasc_Fornecedor = '" + txtNascimento.Text + "', " +
                "cnpj_Fornecedor = '" + txtCPNJ.Text + "', " +
                "logradouro_Fornecedor = '" + txtLogradouro.Text + "', " +
                "numero_Fornecedor = '" + txtNumero.Text + "', " +
                "cep_Fornecedor = '" + txtCEP.Text + "', " +
                "bairro_Fornecedor = '" + txtBairro.Text + "', " +
                "cidade_Fornecedor = '" + txtCidade.Text + "', " +
                "uf_Fornecedor = '" + cboUF.Text + "', " +
                "telefone1_Fornecedor = '" + txtTelefone1.Text + "', " +
                "telefone2_Fornecedor = '" + txtTelefone2.Text + "', " +
                "telefone3_Fornecedor = '" + txtTelefone3.Text + "', " +
                "telefone4_Fornecedor = '" + txtTelefone4.Text + "', " +
                "obs_Fornecedor = '" + txtObs.Text + "', " +
                "status_Fornecedor = '" + cboStatus.Text + "' " +
                "WHERE ID_Fornecedor = " + txtCodigo.Text;

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
            string sql = "SELECT * FROM Fornecedor WHERE ID_Fornecedor = " + txtCodigo.Text;

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
                    txtNascimento.Text = leitura[2].ToString();
                    txtData.Text = leitura[3].ToString();
                    txtCPNJ.Text = leitura[4].ToString();
                    txtLogradouro.Text = leitura[5].ToString();
                    txtNumero.Text = leitura[6].ToString();
                    txtCEP.Text = leitura[7].ToString();
                    txtBairro.Text = leitura[8].ToString();
                    txtCidade.Text = leitura[9].ToString();
                    cboUF.Text = leitura[10].ToString();
                    txtTelefone1.Text = leitura[11].ToString();
                    txtTelefone2.Text = leitura[12].ToString();
                    txtTelefone3.Text = leitura[13].ToString();
                    txtTelefone4.Text = leitura[14].ToString();
                    txtContato.Text = leitura[15].ToString();
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

        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Fornecedor " +
                "(nome_Fornecedor, nasc_Fornecedor, cnpj_Fornecedor, logradouro_Fornecedor, numero_Fornecedor, cep_Fornecedor, bairro_Fornecedor, cidade_Fornecedor, uf_Fornecedor, telefone1_Fornecedor, telefone2_Fornecedor, telefone3_Fornecedor, telefone4_Fornecedor, contato_Fornecedor, obs_Fornecedor, status_Fornecedor)" +
                "values" +
                "('" + txtNome.Text + "','" + txtNascimento.Text + "','" + txtCPNJ.Text + "','" + txtLogradouro.Text + "','" + txtNumero.Text + "','" + txtContato.Text + "','" + txtCEP.Text + "','" + txtBairro.Text + "','" + txtCidade.Text + "','" + cboUF.Text + "','" + txtTelefone1.Text + "','" + txtTelefone2.Text + "','" + txtTelefone3.Text + "','" + txtTelefone4.Text + "','" + txtObs.Text + "','" + cboStatus.Text + "')" +
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