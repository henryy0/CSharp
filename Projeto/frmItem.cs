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
    public partial class frmItem : Form
    {
        public frmItem()
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

        private void frmItem_Load(object sender, EventArgs e)
        {
            TestarConexao();
            CarregarComboProduto();
            CarregarComboLocal();
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

        private void CarregarComboLocal()
        {
            string sql = "select id_LocalEstoque, nome_LocalEstoque from LocalEstoque";

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

                cboIDLocal.DisplayMember = "id_LocalEstoque";
                cboIDLocal.DataSource = tabela;

                cboNomeLocal.DisplayMember = "nome_LocalEstoque";
                cboNomeLocal.DataSource = tabela;
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
                string sql = "INSERT INTO ItemEstoque " +
                             "(id_produto_ItemEstoque, id_localEstoque_ItemEstoque, obs_os, status_os) " +
                             "VALUES " +
                             "(" + cboIDProduto.SelectedValue + ", '" + txtObs.Text + "', '" + cboStatus.Text + "')" +
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
                string sql = "UPDATE ItemEstoque SET " +
                             "id_produto_ItemEstoque = " + cboIDProduto.SelectedValue + ", " +
                             "id_localEstoque_ItemEstoque = " + cboIDLocal.SelectedValue + ", " +
                             "obs_os = '" + txtObs.Text + "', " +
                             "status_os = '" + cboStatus.Text + "' " +
                             "WHERE id_ItemEstoque = " + txtCodigo;

                SqlConnection conexao = new SqlConnection(stringConexao);
                SqlCommand cmd = new SqlCommand(sql, conexao);

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
        }

        private void btoExcluir_Click(object sender, EventArgs e)
        {
            {
                string sql = "DELETE FROM ItemEstoque WHERE id_ItemEstoque = " + txtCodigo.Text;

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
        }

            private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            cboIDProduto.SelectedIndex = -1;
            cboIDLocal.SelectedIndex = -1;
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
                if (int.TryParse(txtCodigo.Text, out int idItemEstoque))
                {
                    string sql = "SELECT * FROM ItemEstoque WHERE id_ItemEstoque = " + idItemEstoque;

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
                            cboIDLocal.SelectedValue = leitura[2];
                            txtObs.Text = leitura[3].ToString();
                            cboStatus.Text = leitura[4].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Erro: Item de Estoque não encontrado");
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
                    MessageBox.Show("Erro: ID do Item de Estoque não foi especificado ou é inválido.");
                }
            }
        }
    }
}