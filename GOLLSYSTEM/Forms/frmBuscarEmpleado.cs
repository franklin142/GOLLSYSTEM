﻿using System;
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
using System.Reflection;

namespace GOLLSYSTEM.Forms
{
    public partial class frmBuscarEmpleado : Form
    {
        public Contrato CurrentObject;
        public string lastParam = "";
        public frmBuscarEmpleado()
        {
            InitializeComponent();
        }

        private void frmBuscarEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                FillDgv(ContratoDAL.searchContratosA(txtBuscar.Text, 50));
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(ContratoDAL.searchContratosA(Validation.Validation.Val_Injection(txtBuscar.Text), 50));
        }
        private void FillDgv(List<Contrato> lista)
        {
            dgvBuscar.Rows.Clear();
            foreach (Contrato obj in lista)
            {
                dgvBuscar.Rows.Add(obj.Id, obj.Cargo.Nombre,
                    obj.Empleado.Persona.Nombre,
                    obj.Empleado.Persona.Dui,
                    obj.Empleado.Persona.Nit,
                    obj.Empleado.Telefono
                    );
            }
            lblNoResults.Visible = dgvBuscar.RowCount == 0;
            lastParam = txtBuscar.Text;
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBuscar.CurrentRow != null)
                {
                    CurrentObject = ContratoDAL.getContratoById((Int64)dgvBuscar.CurrentRow.Cells[0].Value);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar seleccionar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar seleccionar la información de este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Down:
                    dgvBuscar.Focus();
                    break;

                default:

                    if (char.IsLetterOrDigit((char)keyData))
                    {
                        if (!txtBuscar.Focused)
                        {
                            txtBuscar.Text = txtBuscar.Text += (char)keyData;
                            txtBuscar.Focus();
                            txtBuscar.SelectionStart = txtBuscar.Text.Length;

                        }
                    }
                    if (keyData.ToString().ToUpper()=="BACK")
                    {
                        if (!txtBuscar.Focused)
                        {
                            txtBuscar.Text = txtBuscar.Text.Substring(0, txtBuscar.Text.Length > 0 ? txtBuscar.Text.Length - 1 : 0);
                            txtBuscar.Focus();
                            txtBuscar.SelectionStart = txtBuscar.Text.Length;
                        }
                        
                    }
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                if (txtBuscar.Text!=lastParam)
                {
                    FillDgv(ContratoDAL.searchContratosA(Validation.Validation.Val_Injection(txtBuscar.Text), 50));
                }
                else
                {
                    btnSeleccionar.PerformClick();
                }
            }
        }

        private void dgvBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                btnSeleccionar.PerformClick();
            }
        }
    }
}
