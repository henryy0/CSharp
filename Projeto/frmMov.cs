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
    public partial class frmMov : Form
    {
        public frmMov()
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

        private void frmMov_Load(object sender, EventArgs e)
        {
            TestarConexao();
            CarregarComboProduto();
            CarregarComboFuncionario();
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

        private void CarregarComboFuncionario()
        {
            string sql = "select ID_Funcionario, nome_Funcionario from funcionario";

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

                cboIDFuncionario.DisplayMember = "ID_Funcionario";
                cboIDFuncionario.DataSource = tabela;

                cboNomeFuncionario.DisplayMember = "nome_Funcionario";
                cboNomeFuncionario.DataSource = tabela;
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
            string sql = "INSERT INTO movimentacao " +
                            "(id_Produto_mov, id_funcionario_mov, qtde_mov, tipo_mov, obs_mov, status_mov) " +
                            "VALUES " +
                            "(" + cboIDProduto.SelectedValue + ", " + cboIDFuncionario.SelectedValue + ", " +
                            txtQuantidade.Text + ", '" + txtTipo.Text + "', '" + txtObs.Text + "', '" + cboStatus.Text + "')" +
                            "select scope_identity()";

            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conexao);

            conexao.Open();

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Movimentação cadastrada com sucesso.");
                    btoLimpar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Erro: Não foi possível cadastrar a movimentação.");
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
            string sql = "UPDATE movimentacao SET " +
                            "id_Produto_mov = " + cboIDProduto.SelectedValue + ", " +
                            "id_funcionario_mov = " + cboIDFuncionario.SelectedValue + ", " +
                            "qtde_mov = " + txtQuantidade.Text + ", " +
                            "tipo_mov = '" + txtTipo.Text + "', " +
                            "obs_mov = '" + txtObs.Text + "', " +
                            "status_mov = '" + cboStatus.Text + "' " +
                            "WHERE id_mov = " + txtCodigo.Text;

            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conexao);

            conexao.Open();

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Movimentação alterada com sucesso.");
                    btoLimpar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Erro: Não foi possível alterar a movimentação.");
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

        private void btoExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM movimentacao WHERE id_mov = " + txtCodigo.Text;

            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conexao);

            conexao.Open();

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Movimentação excluída com sucesso.");
                    btoLimpar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Erro: Não foi possível excluir a movimentação.");
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

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            {
                txtCodigo.Text = "";
                cboIDProduto.SelectedIndex = -1;
                cboIDFuncionario.SelectedIndex = -1;
                txtQuantidade.Text = "";
                txtTipo.Text = "";
                txtObs.Text = "";
                cboStatus.SelectedIndex = -1;
                txtCodigo.Focus();
            }
        }
        private void btoSair_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

        private void botPesquisar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCodigo.Text, out int idMovimentacao))
            {
                string sql = "SELECT * FROM movimentacao WHERE id_mov = " + idMovimentacao;

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
                        cboIDFuncionario.SelectedValue = leitura[2];
                        txtQuantidade.Text = leitura[3].ToString();
                        txtTipo.Text = leitura[4].ToString();
                        txtObs.Text = leitura[5].ToString();
                        cboStatus.Text = leitura[6].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Erro: Movimentação não encontrada");
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
                MessageBox.Show("Erro: ID da movimentação não foi especificado ou é inválido.");
            }
        }
    }
}