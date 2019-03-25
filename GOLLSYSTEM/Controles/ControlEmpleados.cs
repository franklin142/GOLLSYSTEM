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
using System.Reflection;

namespace GOLLSYSTEM.Controles
{
    public partial class ControlEmpleados : Form
    {
        public List<Contrato> ListaContratos;
        public ControlEmpleados()
        {
            InitializeComponent();
        }

        private void ControlEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                ListaContratos = ContratoDAL.getContratos(500);
                List<Contrato> procesados = new List<Contrato>();
                cbxEstadoContratos.Items.Add("Todos");
                cbxEstadoContratos.SelectedIndex = 0;
                foreach (Contrato obj in ListaContratos)
                {
                    if (procesados.Where(a => a.IdEmpleado == obj.IdEmpleado).FirstOrDefault() == null)
                    {
                        procesados.Add(obj);
                        dgvEmpleados.Rows.Add(obj.Id
                            , obj.Empleado.Persona.Nombre,
                            obj.Empleado.Telefono,
                            ListaContratos.Where(a => a.IdEmpleado == obj.IdEmpleado && a.Estado == "A").ToList().Count);
                        dgvContratos.Rows.Clear();
                        foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado == obj.IdEmpleado).ToList())
                        {
                            dgvContratos.Rows.Add(objInContratos.Id,
                            Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                            objInContratos.Cargo.Nombre,
                            (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                        }
                    }
                }
                if (dgvEmpleados.CurrentRow != null)
                {
                    dgvContratos.Rows.Clear();
                    foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado ==
                                           ListaContratos.Where(ae => ae.Id == (Int64)dgvEmpleados.CurrentRow.Cells[0].Value).FirstOrDefault().IdEmpleado).ToList())
                    {
                        dgvContratos.Rows.Add(objInContratos.Id,
                        Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                        objInContratos.Cargo.Nombre,
                        (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                    }
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de este control, por favor comuniquese con el desarrollador al correo franklingranados2@yahoo.com", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            Forms.FrmEmpleado frmEmpleado = new FrmEmpleado();
            frmEmpleado.ShowDialog();
            txtBuscar.Text = "";
            dgvEmpleados.Rows.Clear();
            ListaContratos = ContratoDAL.getContratos(500);
            List<Contrato> procesados = new List<Contrato>();
            foreach (Contrato obj in ListaContratos)
            {
                if (procesados.Where(a => a.IdEmpleado == obj.IdEmpleado).FirstOrDefault() == null)
                {
                    procesados.Add(obj);
                    dgvEmpleados.Rows.Add(obj.Id
                        , obj.Empleado.Persona.Nombre,
                        obj.Empleado.Telefono,
                        ListaContratos.Where(a => a.IdEmpleado == obj.IdEmpleado && a.Estado == "A").ToList().Count);
                }
            }
            if (dgvEmpleados.CurrentRow != null)
            {
                dgvContratos.Rows.Clear();
                foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado ==
                ListaContratos.Where(ae => ae.Id == (Int64)dgvEmpleados.CurrentRow.Cells[0].Value).FirstOrDefault().IdEmpleado).ToList())
                {
                    dgvContratos.Rows.Add(objInContratos.Id,
                    Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                    objInContratos.Cargo.Nombre,
                    (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                }
            }

        }

        private void dgvEmpleados_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                dgvContratos.Rows.Clear();
                foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado ==
                                       ListaContratos.Where(ae => ae.Id == (Int64)dgvEmpleados.CurrentRow.Cells[0].Value).FirstOrDefault().IdEmpleado).ToList())
                {
                    dgvContratos.Rows.Add(objInContratos.Id,
                    Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                    objInContratos.Cargo.Nombre,
                    (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                }
            }
        }

        private void icUpdate_Click(object sender, EventArgs e)
        {
            ListaContratos = ContratoDAL.searchContratos(Validation.Validation.Val_Injection(txtBuscar.Text), 500);
            List<Contrato> procesados = new List<Contrato>();
            dgvContratos.Rows.Clear();
            dgvEmpleados.Rows.Clear();
            foreach (Contrato obj in ListaContratos) { 
                if (procesados.Where(a => a.IdEmpleado == obj.IdEmpleado).FirstOrDefault() == null)
                {
                    procesados.Add(obj);
                    dgvEmpleados.Rows.Add(obj.Id
                        , obj.Empleado.Persona.Nombre,
                        obj.Empleado.Telefono,
                        ListaContratos.Where(a => a.IdEmpleado == obj.IdEmpleado && a.Estado == "A").ToList().Count);
                    dgvContratos.Rows.Clear();
                    foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado == obj.IdEmpleado).ToList())
                    {
                        dgvContratos.Rows.Add(objInContratos.Id,
                        Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                        objInContratos.Cargo.Nombre,
                        (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                    }
                }
            }
            if (dgvEmpleados.CurrentRow != null)
            {
                dgvContratos.Rows.Clear();
                foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado == (Int64)dgvEmpleados.CurrentRow.Cells[0].Value).ToList())
                {
                    dgvContratos.Rows.Add(objInContratos.Id,
                    Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                    objInContratos.Cargo.Nombre,
                    (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                }
            }
        }

        private void dgvContratos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvContratos.CurrentRow != null)
            {
                Contrato contrato = ContratoDAL.getContratoById((Int64)dgvContratos.CurrentRow.Cells[0].Value);
                if (contrato != null && contrato.FhFin != null)
                {
                    MessageBox.Show("Este contrato ya ha sido finalizado, por este motivo no puede modificarse", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (contrato != null)
                {
                    FrmEmpleado frmEmpleado = new FrmEmpleado();
                    frmEmpleado.CurrentObject = ContratoDAL.getContratoById((Int64)dgvContratos.CurrentRow.Cells[0].Value);
                    frmEmpleado.EditingObject = ContratoDAL.getContratoById((Int64)dgvContratos.CurrentRow.Cells[0].Value);

                    frmEmpleado.opc = "updContrato";
                    frmEmpleado.ShowDialog();
                    dgvEmpleados.Rows.Clear();
                    dgvContratos.Rows.Clear();

                    txtBuscar.Text = "";
                    ListaContratos = ContratoDAL.getContratos(500);
                    List<Contrato> procesados = new List<Contrato>();
                    foreach (Contrato obj in ListaContratos)
                    {
                        if (procesados.Where(a => a.IdEmpleado == obj.IdEmpleado).FirstOrDefault() == null)
                        {
                            procesados.Add(obj);
                            dgvEmpleados.Rows.Add(obj.Id
                                , obj.Empleado.Persona.Nombre,
                                obj.Empleado.Telefono,
                                ListaContratos.Where(a => a.IdEmpleado == obj.IdEmpleado && a.Estado == "A").ToList().Count);
                            dgvContratos.Rows.Clear();

                        }
                    }
                    if (dgvEmpleados.CurrentRow != null)
                    {
                        dgvContratos.Rows.Clear();
                        foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado ==
                                               ListaContratos.Where(ae => ae.Id == (Int64)dgvEmpleados.CurrentRow.Cells[0].Value).FirstOrDefault().IdEmpleado).ToList())
                        {
                            dgvContratos.Rows.Add(objInContratos.Id,
                            Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                            objInContratos.Cargo.Nombre,
                            (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                        }
                    }
                }
            }
        }

        private void dgvEmpleados_DoubleClick(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                Contrato contrato = ContratoDAL.getContratoById((Int64)dgvEmpleados.CurrentRow.Cells[0].Value);
                if (contrato != null)
                {
                    FrmEmpleado frmEmpleado = new FrmEmpleado();
                    frmEmpleado.CurrentObject = ContratoDAL.getContratoById((Int64)dgvEmpleados.CurrentRow.Cells[0].Value);
                    frmEmpleado.EditingObject = ContratoDAL.getContratoById((Int64)dgvEmpleados.CurrentRow.Cells[0].Value);
                    frmEmpleado.opc = "updEmpleado";
                    frmEmpleado.ShowDialog();

                    txtBuscar.Text = "";
                    dgvEmpleados.Rows.Clear();
                    ListaContratos = ContratoDAL.getContratos(500);
                    List<Contrato> procesados = new List<Contrato>();
                    foreach (Contrato obj in ListaContratos)
                    {
                        if (procesados.Where(a => a.IdEmpleado == obj.IdEmpleado).FirstOrDefault() == null)
                        {
                            procesados.Add(obj);
                            dgvEmpleados.Rows.Add(obj.Id
                                , obj.Empleado.Persona.Nombre,
                                obj.Empleado.Telefono,
                                ListaContratos.Where(a => a.IdEmpleado == obj.IdEmpleado && a.Estado == "A").ToList().Count);
                        }
                    }
                    if (dgvEmpleados.CurrentRow != null)
                    {
                        dgvContratos.Rows.Clear();
                        foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado ==
                        ListaContratos.Where(ae => ae.Id == (Int64)dgvEmpleados.CurrentRow.Cells[0].Value).FirstOrDefault().IdEmpleado).ToList())
                        {
                            dgvContratos.Rows.Add(objInContratos.Id,
                            Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                            objInContratos.Cargo.Nombre,
                            (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                        }
                    }
                }
            }
        }

        private void btnNuevoContrato_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                Contrato contrato = ContratoDAL.getContratoById((Int64)dgvEmpleados.CurrentRow.Cells[0].Value);
                if (contrato != null)
                {
                    FrmEmpleado frmEmpleado = new FrmEmpleado();
                    frmEmpleado.CurrentObject = ContratoDAL.getContratoById((Int64)dgvEmpleados.CurrentRow.Cells[0].Value);
                    frmEmpleado.EditingObject = ContratoDAL.getContratoById((Int64)dgvEmpleados.CurrentRow.Cells[0].Value);

                    frmEmpleado.opc = "newContrato";
                    frmEmpleado.ShowDialog();

                    txtBuscar.Text = "";
                    dgvEmpleados.Rows.Clear();
                    ListaContratos = ContratoDAL.getContratos(500);
                    List<Contrato> procesados = new List<Contrato>();
                    foreach (Contrato obj in ListaContratos)
                    {
                        if (procesados.Where(a => a.IdEmpleado == obj.IdEmpleado).FirstOrDefault() == null)
                        {
                            procesados.Add(obj);
                            dgvEmpleados.Rows.Add(obj.Id
                                , obj.Empleado.Persona.Nombre,
                                obj.Empleado.Telefono,
                                ListaContratos.Where(a => a.IdEmpleado == obj.IdEmpleado && a.Estado == "A").ToList().Count);
                        }
                    }
                    if (dgvEmpleados.CurrentRow != null)
                    {
                        dgvContratos.Rows.Clear();
                        foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado ==
                        ListaContratos.Where(ae => ae.Id == (Int64)dgvEmpleados.CurrentRow.Cells[0].Value).FirstOrDefault().IdEmpleado).ToList())
                        {
                            dgvContratos.Rows.Add(objInContratos.Id,
                            Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                            objInContratos.Cargo.Nombre,
                            (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                        }
                    }
                }
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvContratos.CurrentRow != null)
            {
                bool result = true;
                if (ContratoDAL.getContratoById((Int64)dgvContratos.CurrentRow.Cells[0].Value).FhFin != null)
                {
                    result = false;
                    MessageBox.Show("El contrato ya ha sido cancelado anteriormente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result)
                {
                    if (MessageBox.Show("¿Esta Seguro de finalizar el contrato seleccionado?Esta acción no puede deshacerse.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        result = false;
                    }
                }

                if (result)
                {
                    if (ContratoDAL.terminarContrato(ContratoDAL.getContratoById((Int64)dgvContratos.CurrentRow.Cells[0].Value), Inicio.CurrentUser))
                    {
                        MessageBox.Show("El contrato seleccionado ha sido finalizado exitosamente.", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBuscar.Text = "";
                        dgvEmpleados.Rows.Clear();
                        ListaContratos = ContratoDAL.getContratos(500);
                        List<Contrato> procesados = new List<Contrato>();
                        foreach (Contrato obj in ListaContratos)
                        {
                            if (procesados.Where(a => a.IdEmpleado == obj.IdEmpleado).FirstOrDefault() == null)
                            {
                                procesados.Add(obj);
                                dgvEmpleados.Rows.Add(obj.Id
                                    , obj.Empleado.Persona.Nombre,
                                    obj.Empleado.Telefono,
                                    ListaContratos.Where(a => a.IdEmpleado == obj.IdEmpleado && a.Estado == "A").ToList().Count);
                            }
                        }
                        if (dgvEmpleados.CurrentRow != null)
                        {
                            dgvContratos.Rows.Clear();
                            foreach (Contrato objInContratos in ListaContratos.Where(a => a.IdEmpleado ==
                            ListaContratos.Where(ae => ae.Id == (Int64)dgvEmpleados.CurrentRow.Cells[0].Value).FirstOrDefault().IdEmpleado).ToList())
                            {
                                dgvContratos.Rows.Add(objInContratos.Id,
                                Convert.ToDateTime(objInContratos.FhInicio).ToString("dd-MM-yyyy"),
                                objInContratos.Cargo.Nombre,
                                (objInContratos.FhFin == null ? "Activo" : "Finalizado"));
                            }
                        }
                    }
                }
            }


        }
    }
}
