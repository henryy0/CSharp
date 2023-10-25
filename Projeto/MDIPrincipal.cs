using Projeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class MDIPrincipal : Form
    {
        public static string stringConexao = "Data Source=localhost;" +
            "Initial Catalog=t18_estoque;" +
            "User ID=sa;" +
            "Password=123456";

        private int childFormNumber = 0;

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        public static string idUsuario;
        public static string loginUsuario;
        public static string nomeUsuario;
        public static string senhaUsuario;

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void BtoFuncionario_Click(object sender, EventArgs e)
        {
            frmFuncionario formularioFuncionario = new frmFuncionario();
            formularioFuncionario.MdiParent = this;
            formularioFuncionario.Show();
        }

        private void btoFonercedor_Click(object sender, EventArgs e)
        {
            frmFonercedor formularioFonercedor = new frmFonercedor();
            formularioFonercedor.MdiParent = this;
            formularioFonercedor.Show();
        }

        private void btoUsuario_Click(object sender, EventArgs e)
        {
            frmUsuario formularioUsuario = new frmUsuario();
            formularioUsuario.MdiParent = this;
            formularioUsuario.Show();
        }

        private void btoLocalEstoque_Click(object sender, EventArgs e)
        {
            frmLocalEstoque formularioEstoque = new frmLocalEstoque();
            formularioEstoque.MdiParent = this;
            formularioEstoque.Show();
        }

        private void btoProduto_Click(object sender, EventArgs e)
        {
            frmProduto formularioProduto = new frmProduto();
            formularioProduto.MdiParent = this;
            formularioProduto.Show();
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.ShowDialog();
        }

        private void BtoItem_Click(object sender, EventArgs e)
        {
            frmItem formularioItem = new frmItem();
            formularioItem.MdiParent = this;
            formularioItem.Show();
        }

        private void OS_Click(object sender, EventArgs e)
        {
            frmOS formularioOS = new frmOS();
            formularioOS.MdiParent = this;
            formularioOS.Show();
        }

        private void btoMov_Click(object sender, EventArgs e)
        {
            frmMov formularioMov = new frmMov();
            formularioMov.MdiParent = this;
            formularioMov.Show();
        }
    }
}
