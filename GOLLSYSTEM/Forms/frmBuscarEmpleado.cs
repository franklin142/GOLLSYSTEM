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
    public partial class frmBuscarEmpleado : Form
    {
        public Contrato CurrentObject;
        public frmBuscarEmpleado()
        {
            InitializeComponent();
        }

        private void frmBuscarEmpleado_Load(object sender, EventArgs e)
        {
            FillDgv(ContratoDAL.searchContratosA(txtBuscar.Text, 50));

        }
        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(ContratoDAL.searchContratosA(txtBuscar.Text, 50));
        }
        private void FillDgv(List<Contrato> lista)
        {
            dgvCursos.Rows.Clear();
            foreach (Contrato obj in lista)
            {
                dgvCursos.Rows.Add(obj.Id,obj.Cargo.Nombre,
                    obj.Empleado.Persona.Nombre,
                    obj.Empleado.Persona.Dui,
                    obj.Empleado.Persona.Nit,
                    obj.Empleado.Telefono
                    );
            }
            lblNoResults.Visible = dgvCursos.RowCount == 0;

        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.CurrentRow != null)
            {
                CurrentObject = ContratoDAL.getContratoById((Int64)dgvCursos.CurrentRow.Cells[0].Value);
                this.Close();
            }
        }
    }
}
