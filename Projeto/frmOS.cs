using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class frmOS : Form
    {
        public frmOS()
        {
            InitializeComponent();
        }
        string stringConexao = MDIPrincipal.stringConexao;

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
                MessageBox.Show("Erro: " + ex.ToString());
            }
        }

        private void frmOS_Load(object sender, EventArgs e)
        {
            TestarConexao();
            CarregarComboProduto();
        }

        private void CarregarComboProduto()
        {
            string sql = "select ID_Produto, nome_Produto from produto";

            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;

            DataTable tabela = new DataTable();

            conexao.Open();

            try
            {
                leitura = cmd.ExecuteReader();

                tabela.Load(leitura);

                cboIDProduto.DisplayMember = "ID_Produto";
                cboIDProduto.DataSource = tabela;

                cboNomeProduto.DisplayMember = "nome_Produto";
                cboNomeProduto.DataSource = tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.ToString());
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            {
                string sql = "INSERT INTO OS " +
                             "(id_produto_os, qtde_os, obs_os, status_os) " +
                             "VALUES " +
                             "(" + cboIDProduto.SelectedValue + ", " + txtQuantidade.Text + ", '" + txtObs.Text + "', '" + cboStatus.Text + "')" +
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

        private void btoAlterar_Click(object sender, EventArgs e)
        {
            {
                string sql = "UPDATE OS SET " +
                             "id_produto_os = " + cboIDProduto.SelectedValue + ", " +
                             "qtde_os = " + txtQuantidade.Text + ", " +
                             "obs_os = '" + txtObs.Text + "', " +
                             "status_os = '" + cboStatus.Text + "' " +
                             "WHERE id_os = " + txtCodigo.Text;

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

        private void btoExcluir_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCodigo.Text, out int idOS))
            {
                string sql = "DELETE FROM OS WHERE id_os = " + idOS;

                SqlConnection conexao = new SqlConnection(stringConexao);
                SqlCommand cmd = new SqlCommand(sql, conexao);

                conexao.Open();

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("OS excluída com sucesso.");
                        btoLimpar.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Erro: Não foi possível excluir a OS.");
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
            else
            {
                MessageBox.Show("Erro: ID da OS não foi especificado ou é inválido.");
            }
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            cboIDProduto.SelectedIndex = -1;
            txtQuantidade.Text = "";
            txtObs.Text = "";
            cboStatus.SelectedIndex = -1;
            txtCodigo.Focus();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void botPesquisar_Click(object sender, EventArgs e)
        {
            {
                if (int.TryParse(txtCodigo.Text, out int idOS))
                {
                    string sql = "SELECT * FROM OS WHERE id_os = " + idOS;

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
                            cboIDProduto.SelectedValue = leitura[1];
                            txtQuantidade.Text = leitura[2].ToString();
                            txtObs.Text = leitura[3].ToString();
                            cboStatus.Text = leitura[4].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Erro: OS não encontrada");
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
                else
                {
                    MessageBox.Show("Erro: ID da OS não foi especificado ou é inválido.");
                }
            }
        }
    }
}
