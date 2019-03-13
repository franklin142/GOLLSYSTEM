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
    public partial class frmBuscarEncargado : Form
    {
        public Encargado CurrentObject;
        public frmBuscarEncargado()
        {
            InitializeComponent();
        }

        private void frmBuscarEncargado_Load(object sender, EventArgs e)
        {
            FillDgv(EncargadoDAL.searchEncargados(txtBuscar.Text, 30));
        }
        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(EncargadoDAL.searchEncargados(Validation.Validation.Val_Injection(txtBuscar.Text), 30));
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.CurrentRow != null) { CurrentObject = EncargadoDAL.getEncargadoById((Int64)dgvCursos.CurrentRow.Cells[0].Value); this.Close(); }

        }
        private void FillDgv(List<Encargado> lista)
        {
            dgvCursos.Rows.Clear();
            foreach (Encargado obj in lista)dgvCursos.Rows.Add(obj.Id, obj.Persona.Nombre,obj.Telefono,obj.Trabajo,obj.Persona.Direccion);
            lblNoResults.Visible = dgvCursos.RowCount == 0;
        }

    }
}
