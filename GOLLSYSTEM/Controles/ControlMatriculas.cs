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
    public partial class ControlMatriculas : Form
    {
        public ControlMatriculas()
        {
            InitializeComponent();
        }

        private void ControlMatriculas_Load(object sender, EventArgs e)
        {
            cbxYear.Enabled = false;
            cbxYear.DataSource = YearDAL.getYears(500);
            cbxYear.ValueMember = "Id";
            cbxYear.DisplayMember = "Desde";
            cbxYear.Enabled = true;

            cbxCursos.Enabled = false;
            cbxCursos.DataSource = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id,cbxYear.SelectedItem as Year);
            cbxCursos.ValueMember = "Id";
            cbxCursos.DisplayMember = "Nombre";
            cbxCursos.Enabled = true;
            FillDgv(new List<Matricula>());


        }

        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxYear.Enabled)
            {
                cbxCursos.Enabled = false;
                cbxCursos.DataSource = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, cbxYear.SelectedItem as Year);
                cbxCursos.ValueMember = "Id";
                cbxCursos.DisplayMember = "Nombre";
                cbxCursos.Enabled = true;
                FillDgv(new List<Matricula>());

            }
        }

        private void cbxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCursos.Enabled)
            {
                FillDgv(new List<Matricula>());
            }
        }
        private void FillDgv(List<Matricula> lista)
        {
            dgvMatriculas.Rows.Clear();
            foreach (Matricula obj in lista)
            {

            }
        }
    }
}
