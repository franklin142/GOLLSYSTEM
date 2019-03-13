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
    public partial class frmBuscarEstudiante : Form
    {
        public Matricula currentObject;
        public frmBuscarEstudiante()
        {
            InitializeComponent();
        }

        private void frmBuscarEstudiante_Load(object sender, EventArgs e)
        {
            FillDgv(MatriculaDAL.searchMatriculas(txtBuscar.Text, Inicio.CurrentSucursal.Id));

        }

        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(MatriculaDAL.searchMatriculas(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id));
        }
        private void FillDgv(List<Matricula>lista)
        {
            dgvCursos.Rows.Clear();
            foreach (Matricula obj in lista)
            {
                dgvCursos.Rows.Add(
                    obj.Id,
                    obj.Estudiante.Persona.Nombre,
                    obj.Estudiante.Telefono,
                    obj.Estudiante.TelEmergencia,
                    obj.Estudiante.ParentEmergencia);
            }
            lblNoResults.Visible = dgvCursos.RowCount == 0;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.CurrentRow!=null)
            {
                currentObject = MatriculaDAL.getMatriculaById((Int64)dgvCursos.CurrentRow.Cells[0].Value);
                this.Close();
            }
        }
    }
}
