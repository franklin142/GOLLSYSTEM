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
    public partial class frmBuscarPersona : Form
    {
        public Persona currentObject;
        public frmBuscarPersona()
        {
            InitializeComponent();
        }

        private void frmBuscarPersona_Load(object sender, EventArgs e)
        {
            FillDgv(PersonaDAL.searchPersonaNoParametro(txtBuscar.Text, 60));

        }

        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(PersonaDAL.searchPersonaNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), 60));
        }
        private void FillDgv(List<Persona>lista)
        {
            dgvCursos.Rows.Clear();
            foreach (Persona persona in lista) dgvCursos.Rows.Add(persona.Id,persona.Nombre);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.CurrentRow!=null)
            {
                currentObject = PersonaDAL.getPersonaById((Int64)dgvCursos.CurrentRow.Cells[0].Value);
                this.Close();
            }
        }

        private void btnNuevaPersona_Click(object sender, EventArgs e)
        {
            frmPersona persona = new frmPersona();
            persona.EditingObject = new Persona();
            persona.ShowDialog();
            FillDgv(PersonaDAL.searchPersonaNoParametro(txtBuscar.Text, 60));

        }
    }
}
