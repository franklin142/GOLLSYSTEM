using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.Forms;
using GOLLSYSTEM.EntityLayer;
using GOLLSYSTEM.DataAccess;

namespace GOLLSYSTEM.Controles
{
    public partial class ControlCursos : Form
    {
        public ControlCursos()
        {
            InitializeComponent();
        }

        private void ControlCursos_Load(object sender, EventArgs e)
        {
            cbxYear.DataSource = YearDAL.getYears(500);
            cbxYear.ValueMember = "Id";
            cbxYear.DisplayMember = "Desde";
            FillDgv(CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, new Year((Int64)cbxYear.SelectedValue, "", "")));
            cbxYear.SelectedIndexChanged += new EventHandler(cbxYear_SelectedIndexChanged);
        }
        private void FillDgv(List<Curso> lista)
        {
            dgvCursos.Rows.Clear();
            foreach (Curso obj in lista)
            {
                string horario = "-|";
                foreach (Dia objDia in obj.Horario)
                {
                    horario += objDia.Nombre + ": " + objDia.HEntrada + " " + objDia.HSalida + "|- ";
                }
                dgvCursos.Rows.Add(obj.Id,
                    obj.Nombre,
                    horario == "-|" ? "" : horario,
                    obj.Publico,
                    MatriculaDAL.countMatriculasByCurso(obj.Id),
                    obj.Estado=="A"?"Activo":"Inactivo");

            }
        }

        private void btnNuevoCurso_Click(object sender, EventArgs e)
        {
            FrmCurso frmCurso = new FrmCurso();
            frmCurso.opc = "newObject";
            frmCurso.ShowDialog();
            txtBuscar.Text = "";
            FillDgv(CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, new Year((Int64)cbxYear.SelectedValue, "", "")));
        }

        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {

            FillDgv(CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, new Year(Convert.ToInt32(cbxYear.SelectedValue), "", "")));

        }

        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(CursoDAL.searchCursos(Inicio.CurrentSucursal.Id, Validation.Validation.Val_Injection(txtBuscar.Text), new Year(Convert.ToInt32(cbxYear.SelectedValue), "", "")));

        }

        private void btnEditarCurso_Click(object sender, EventArgs e)
        {
            if (dgvCursos.CurrentRow!=null)
            {
                FrmCurso frmcurso = new FrmCurso();
                frmcurso.opc = "updObject";
                frmcurso.CurrentObject = CursoDAL.getCursoById((Int64)dgvCursos.CurrentRow.Cells[0].Value);
                frmcurso.EditingObject = CursoDAL.getCursoById((Int64)dgvCursos.CurrentRow.Cells[0].Value);
                frmcurso.ShowDialog();
                FillDgv(CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, (cbxYear.SelectedItem as Year)));

            }
        }

        private void btnAnularCurso_Click(object sender, EventArgs e)
        {
            if (dgvCursos.CurrentRow != null)
            {
                bool result = true;
                if (CursoDAL.getCursoById((Int64)dgvCursos.CurrentRow.Cells[0].Value).Estado != "A")
                {
                    result = false;
                    MessageBox.Show("El curso ya ha sido inhabilitado anteriormente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result)
                {
                    if (MessageBox.Show("¿Esta Seguro de inhabilitar el curso seleccionado? podra reactivarlo editando el registro desde el formulario correspondiente.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        result = false;
                    }
                }

                if (result)
                {
                    if (CursoDAL.inhabilitarCurso(CursoDAL.getCursoById((Int64)dgvCursos.CurrentRow.Cells[0].Value), Inicio.CurrentUser))
                    {
                        MessageBox.Show("El curso seleccionado ha sido inhabilitado exitosamente.", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBuscar.Text = "";
                        dgvCursos.Rows.Clear();
                        FillDgv(CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id,(cbxYear.SelectedItem as Year)));
                    }
                }
            }

        }
    }
}
