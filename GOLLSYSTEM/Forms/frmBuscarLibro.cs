using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.DataAccess;
using GOLLSYSTEM.EntityLayer;

namespace GOLLSYSTEM.Forms
{
    public partial class frmBuscarLibro : Form
    {
        public frmBuscarLibro()
        {
            InitializeComponent();
        }
        public Libro CurrentObject;
        private void frmBuscarLibro_Load(object sender, EventArgs e)
        {
            FillDgv(LibroDAL.searchLibros(txtBuscar.Text, 50));
        }

        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(LibroDAL.searchLibros(txtBuscar.Text,50));
        }
        private void FillDgv(List<Libro>lista)
        {
            dgvLibro.Rows.Clear();
            foreach (Libro obj in lista)
            {
                dgvLibro.Rows.Add(obj.Id,obj.Nombre,obj.Edicion,obj.Nivel,obj.NActividades);
            }
            lblNoResults.Visible = dgvLibro.RowCount == 0;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvLibro.CurrentRow!=null)
            {
                CurrentObject = LibroDAL.getLibroById((Int64)dgvLibro.CurrentRow.Cells[0].Value);
                this.Close();
            }
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            FrmLibro frmLibro = new FrmLibro();
            frmLibro.ShowDialog();
            txtBuscar.Text = "";
            FillDgv(LibroDAL.searchLibros(txtBuscar.Text, 50));

        }
    }
}
