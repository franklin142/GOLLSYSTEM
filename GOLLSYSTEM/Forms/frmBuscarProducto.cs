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
    public partial class frmBuscarProducto : Form
    {
        public string opc = "Mensualidad";
        public Int64 IdPersona = 0;
        public Detfactura currentDetFactura;
        public bool ready = false;
        public frmBuscarProducto()
        {
            InitializeComponent();
        }
        private void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            switch (opc)
            {
                case "Mensualidad":
                    
                    cbxYear.DataSource = YearDAL.getYears(10000);
                    cbxYear.DisplayMember = "Desde";
                    cbxYear.ValueMember = "Id";
                    cbxYear.SelectedIndex = 0;

                    cbxCurso.DataSource = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, cbxYear.SelectedItem as Year);
                    cbxCurso.DisplayMember = "Nombre";
                    cbxCurso.ValueMember = "Id";
                    cbxCurso.SelectedIndex = 0;

                    List<Matricula> matriculas = MatriculaDAL.searchMatriculasParametro("", (Int64)cbxYear.SelectedValue, (Int64)cbxCurso.SelectedValue);
                    foreach (Matricula obj in matriculas) obj.NombreEstudiante = obj.Estudiante.Persona.Nombre + " " + obj.Estudiante.ApPaterno + " " + obj.Estudiante.ApMaterno;
                    cbxEstudiante.DataSource = matriculas;

                    cbxEstudiante.DisplayMember = "NombreEstudiante";
                    cbxEstudiante.ValueMember = "Id";
                    cbxEstudiante.SelectedIndex = 0;
                    checkBecado.Checked = MatriculaDAL.getMatriculaById(cbxEstudiante.SelectedValue != null ? (Int64)cbxEstudiante.SelectedValue : 0) != null ? MatriculaDAL.getMatriculaById(cbxEstudiante.SelectedValue != null ? (Int64)cbxEstudiante.SelectedValue : 0).Becado == 1 : false;
                    List<Cuota> cuotas = CuotaDAL.getCuotasByIdMatricula(cbxEstudiante.Items.Count != 0 ? (Int64)cbxEstudiante.SelectedValue : 0, 1000);
                    FillDgv_Mensualidades(cuotas);
                    btnRegistrarProducto.Visible = false;
                    btnRegistrarProducto.Enabled = false;
                    break;
                case "Cancelacion":
                    pnlParamMensualidad.Visible = false;
                    pnlParamMensualidad.Enabled = false;
                    checkBecado.Visible = false;
                    FillDgv_Reservaciones(DetFacturaDAL.getDetsfacturaByIdPersona(IdPersona));
                    break;
                case "Contado":
                    pnlParamMensualidad.Visible = false;
                    pnlParamMensualidad.Enabled = false;
                    checkBecado.Visible = false;
                    FillDgv_Productos(ProductoDAL.getProductos(1000));
                    if (dgvProductos.CurrentRow != null)
                    {
                        Producto producto = ProductoDAL.getProductoById((Int64)dgvProductos.CurrentRow.Cells[0].Value);
                        lblPrecio.Text = "$" + producto.Precio;
                        txtAporte.Text = (producto.Precio).ToString();
                    }
                    break;
                default: break;
            }
            ready = true;
        }
        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            FrmProducto producto = new FrmProducto();
            producto.ShowDialog();
            FillDgv_Productos(ProductoDAL.getProductos(1000));
        }
        private void FillDgv_Mensualidades(List<Cuota> lista)
        {
            try
            {
                dgvProductos.Rows.Clear();
                Producto prod = ProductoDAL.getProductoMensualidad();
                foreach (Cuota cuota in lista)
                {
                    dgvProductos.Rows.Add(cuota.Id, prod.Nombre + " " + Convert.ToDateTime(cuota.FhRegistro).ToString("MMMM") + " " + Convert.ToDateTime(cuota.FhRegistro).ToString("yyyy"));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void FillDgv_Productos(List<Producto> lista)
        {
            try
            {
                dgvProductos.Rows.Clear();
                foreach (Producto prod in lista)
                {
                    dgvProductos.Rows.Add(prod.Id, prod.Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void FillDgv_Reservaciones(List<Detfactura> lista)
        {
            try
            {
                dgvProductos.Rows.Clear();
                foreach (Detfactura detfactura in lista)
                {
                    dgvProductos.Rows.Add(detfactura.Id, "($" + DetFacturaDAL.getTotalDebeReserva(detfactura.Id, IdPersona) + ") " + detfactura.Producto.Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dgvProductos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                switch (opc)
                {
                    case "Mensualidad":
                        changeDets(ProductoDAL.getProductoMensualidad());
                        break;
                    case "Cancelacion":
                        changeDets(ProductoDAL.getProductoById(DetFacturaDAL.getDetfacturaById((Int64)dgvProductos.CurrentRow.Cells[0].Value).IdProducto));

                        break;

                    case "Contado":
                        changeDets(ProductoDAL.getProductoById((Int64)dgvProductos.CurrentRow.Cells[0].Value));

                        break;
                    default: break;
                }
            }
        }
        private void changeDets(Producto producto)
        {
            switch (opc)
            {
                case "Mensualidad":

                    lblPrecio.Text = "$" + producto.Precio;
                    Cuota cuota = CuotaDAL.getCuotaById((Int64)dgvProductos.CurrentRow.Cells[0].Value);
                    txtAporte.Text = (cuota.Precio - cuota.Total).ToString();
                    break;
                case "Cancelacion":
                    if (dgvProductos.CurrentRow != null)
                    {
                        decimal totaldebe = DetFacturaDAL.getTotalDebeReserva((Int64)dgvProductos.CurrentRow.Cells[0].Value, IdPersona);
                        lblPrecio.Text = "$" + producto.Precio.ToString() + " - Pendiente $" + Decimal.Round(totaldebe, 2);
                        txtAporte.Text =Decimal.Round( totaldebe,2).ToString();
                        txtDescuento.Text = "0.00";
                    }
                    break;
                case "Contado":
                    lblPrecio.Text = "$" + producto.Precio;
                    txtAporte.Text = (producto.Precio).ToString();

                    break;
                default: break;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && Val_NewObject())
            {
                switch (opc)
                {
                    case "Mensualidad":
                        if (dgvProductos.CurrentRow != null)
                        {
                            currentDetFactura = new Detfactura(
                                0,
                                "Mensualidad",
                                Convert.ToDecimal(txtAporte.Text),
                                Convert.ToDecimal(txtDescuento.Text),
                                "M",
                                null,
                                0,
                                ProductoDAL.getProductoMensualidad().Id,
                                ProductoDAL.getProductoMensualidad(),
                                new Matricdetfac(
                                    0,
                                    0,
                                    (Int64)dgvProductos.CurrentRow.Cells[0].Value)
                                );
                            this.Close();
                        }
                        break;
                    case "Cancelacion":
                        if (dgvProductos.CurrentRow != null)
                        {
                            currentDetFactura = new Detfactura(
                                (Int64)dgvProductos.CurrentRow.Cells[0].Value,
                                ProductoDAL.getProductoById(DetFacturaDAL.getDetfacturaById((Int64)dgvProductos.CurrentRow.Cells[0].Value).IdProducto).Nombre,
                                Convert.ToDecimal(txtAporte.Text),
                                Convert.ToDecimal(txtDescuento.Text),
                                "C",
                                DetFacturaDAL.getDetfacturaById((Int64)dgvProductos.CurrentRow.Cells[0].Value).RefNFactura,
                                0,
                                ProductoDAL.getProductoById(DetFacturaDAL.getDetfacturaById((Int64)dgvProductos.CurrentRow.Cells[0].Value).IdProducto).Id,
                                ProductoDAL.getProductoById(DetFacturaDAL.getDetfacturaById((Int64)dgvProductos.CurrentRow.Cells[0].Value).IdProducto),
                                null
                                );
                            this.Close();
                        }
                        break;
                    case "Contado":
                        if (dgvProductos.CurrentRow != null)
                        {
                            currentDetFactura = new Detfactura(
                                0,
                                "Al contado",
                                Convert.ToDecimal(txtAporte.Text),
                                Convert.ToDecimal(txtDescuento.Text),
                                Convert.ToDecimal(txtAporte.Text) < ProductoDAL.getProductoById((Int64)dgvProductos.CurrentRow.Cells[0].Value).Precio ? "R" : "F",
                                null,
                                0,
                                ProductoDAL.getProductoById((Int64)dgvProductos.CurrentRow.Cells[0].Value).Id,
                                ProductoDAL.getProductoById((Int64)dgvProductos.CurrentRow.Cells[0].Value),
                                null
                                );
                            this.Close();
                        }
                        break;
                    default: break;
                }
            }
        }
        public bool Val_NewObject()
        {
            bool result = true;
            if (!Validation.Validation.Val_DecimalFormat(txtAporte.Text))
            {
                errAporte.SetError(txtAporte, "El aporte no tiene un formato adecuado,\npor favor ingrese un numero entero o decimal.");
                valAporte.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errAporte.Clear();
                valAporte.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_DecimalFormat(txtDescuento.Text))
            {
                errDescuento.SetError(txtDescuento, "El descuento que desea aplicar no tiene un formato adecuado,\npor favor ingrese un numero entero o decimal.");
                valDescuento.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errDescuento.Clear();
                valDescuento.BackColor = Color.FromArgb(0, 100, 182);
                if (Validation.Validation.Val_DecimalFormat(txtAporte.Text))
                {


                    if (Convert.ToDecimal(txtDescuento.Text) > Convert.ToDecimal(txtAporte.Text))
                    {
                        errDescuento.SetError(txtDescuento, "El descuento que desea aplicar es mayor\nal aporte de este producto o servicio,\npor favor ingrese una cifra inferior al aporte.");
                        valDescuento.BackColor = Color.Red;
                        result = false;
                    }
                    else
                    {
                        errDescuento.Clear();
                        valDescuento.BackColor = Color.FromArgb(0, 100, 182);
                    }
                }
            }

            return result;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbxEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready && cbxEstudiante.SelectedValue != null)
            {
                List<Cuota> cuotas = CuotaDAL.getCuotasByIdMatricula(cbxEstudiante.SelectedValue != null ? (Int64)cbxEstudiante.SelectedValue : 0, 1000);
                FillDgv_Mensualidades(cuotas);
                Matricula matric = MatriculaDAL.getMatriculaById((Int64)cbxEstudiante.SelectedValue);
                checkBecado.Checked = MatriculaDAL.getMatriculaById(cbxEstudiante.SelectedValue != null ? (Int64)cbxEstudiante.SelectedValue : 0) != null ? MatriculaDAL.getMatriculaById(cbxEstudiante.SelectedValue != null ? (Int64)cbxEstudiante.SelectedValue : 0).Becado == 1 : false;
            }
        }
        private void txtAporte_Leave(object sender, EventArgs e)
        {
            txtAporte.Text = txtAporte.Text == "" || txtAporte.Text == "." || txtAporte.Text == "-0" ? "0.00" : txtAporte.Text;

            if (Validation.Validation.Val_DecimalFormat(txtAporte.Text))
            {
                if (dgvProductos.CurrentRow != null)
                {
                    switch (opc)
                    {
                        case "Mensualidad":
                            Cuota cuota = CuotaDAL.getCuotaById((Int64)dgvProductos.CurrentRow.Cells[0].Value);

                            if (Convert.ToDecimal(txtAporte.Text) > (cuota.Precio - cuota.Total))
                            {
                                txtAporte.Text = (cuota.Precio - cuota.Total).ToString();
                            }
                            if (Convert.ToDecimal(txtAporte.Text) < 0)
                            {
                                txtAporte.Text = "0.00";
                            }
                            break;
                        case "Cancelacion":
                            decimal totaldebe = DetFacturaDAL.getTotalDebeReserva((Int64)dgvProductos.CurrentRow.Cells[0].Value, IdPersona);
                            if (Convert.ToDecimal(txtAporte.Text) < 0)
                            {
                                txtAporte.Text = "0.00";
                            }

                            if (Convert.ToDecimal(txtAporte.Text) > totaldebe)
                            {
                                txtAporte.Text = Decimal.Round(totaldebe, 2).ToString();
                            }
                            break;
                        case "Contado":
                            Producto producto = ProductoDAL.getProductoById((Int64)dgvProductos.CurrentRow.Cells[0].Value);
                            txtAporte.Text = Convert.ToDecimal(txtAporte.Text) > producto.Precio ? (producto.Precio).ToString() : txtAporte.Text; ;
                            if (Convert.ToDecimal(txtAporte.Text) < 0)
                            {
                                txtAporte.Text = "0.00";
                            }
                            break;
                        default: break;
                    }
                }
                valAporte.BackColor = Color.FromArgb(0, 100, 182);
                errAporte.Clear();

            }
            else
            {
                errAporte.SetError(txtAporte, "El aporte no tiene un formato adecuado,\npor favor ingrese un numero entero o decimal.");
                valAporte.BackColor = Color.Red;
            }
        }
        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            txtDescuento.Text = (txtDescuento.Text == "" || txtDescuento.Text == "." || txtDescuento.Text == "-0") ? "0.00" : txtDescuento.Text;
            if (Validation.Validation.Val_DecimalFormat(txtDescuento.Text))
            {
                if (dgvProductos.CurrentRow != null)
                {
                    switch (opc)
                    {
                        case "Mensualidad":
                            Cuota cuota = CuotaDAL.getCuotaById((Int64)dgvProductos.CurrentRow.Cells[0].Value);
                            if (Convert.ToDecimal(txtDescuento.Text) > Convert.ToDecimal(txtAporte.Text))
                            {
                                txtDescuento.Text = txtAporte.Text;
                            }
                            if (Convert.ToDecimal(txtDescuento.Text) < 0)
                            {
                                txtDescuento.Text = "0.00";
                            }
                            break;
                        case "Cancelacion":
                            break;
                        case "Contado":
                            Producto producto = ProductoDAL.getProductoById((Int64)dgvProductos.CurrentRow.Cells[0].Value);
                            txtDescuento.Text = Convert.ToDecimal(txtDescuento.Text) > producto.Precio ? (producto.Precio).ToString() : txtDescuento.Text; ;
                            if (Convert.ToDecimal(txtDescuento.Text) < 0)
                            {
                                txtDescuento.Text = "0.00";
                            }
                            if ((Convert.ToDecimal(txtDescuento.Text) > Convert.ToDecimal(txtAporte.Text)))
                            {
                                txtDescuento.Text = txtAporte.Text;
                            }
                            break;
                        default: break;
                    }
                }
                valDescuento.BackColor = Color.FromArgb(0, 100, 182);
                errDescuento.Clear();
            }
            else
            {
                errDescuento.SetError(txtDescuento, "El descuento que desea aplicar no tiene un formato adecuado,\npor favor ingrese un numero entero o decimal.");
                valDescuento.BackColor = Color.Red;
            }
        }
        private void cbxCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready && cbxCurso.SelectedValue != null)
            {
                List<Matricula> matriculas = MatriculaDAL.searchMatriculasParametro("", (Int64)cbxYear.SelectedValue, (Int64)cbxCurso.SelectedValue);
                foreach (Matricula obj in matriculas) obj.NombreEstudiante = obj.Estudiante.Persona.Nombre + " " + obj.Estudiante.ApPaterno + " " + obj.Estudiante.ApMaterno;
                cbxEstudiante.DataSource = matriculas;

                cbxEstudiante.DisplayMember = "NombreEstudiante";
                cbxEstudiante.ValueMember = "Id";
                cbxEstudiante.SelectedIndex = 0;
                checkBecado.Checked = matriculas != null ? matriculas[0].Becado == 1 : checkBecado.Checked;

            }
        }
        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready && cbxYear.SelectedValue != null)
            {
                cbxCurso.DataSource = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, cbxYear.SelectedItem as Year);
                cbxCurso.DisplayMember = "Nombre";
                cbxCurso.ValueMember = "Id";
                cbxCurso.SelectedIndex = 0;

                List<Matricula> matriculas = MatriculaDAL.searchMatriculasParametro("", (Int64)cbxYear.SelectedValue, (Int64)cbxCurso.SelectedValue);
                foreach (Matricula obj in matriculas) obj.NombreEstudiante = obj.Estudiante.Persona.Nombre + " " + obj.Estudiante.ApPaterno + " " + obj.Estudiante.ApMaterno;
                cbxEstudiante.DataSource = matriculas;

                cbxEstudiante.DisplayMember = "NombreEstudiante";
                cbxEstudiante.ValueMember = "Id";
                cbxEstudiante.SelectedIndex = 0;

                List<Cuota> cuotas = CuotaDAL.getCuotasByIdMatricula(cbxEstudiante.Items.Count != 0 ? (Int64)cbxEstudiante.SelectedValue : 0, 1000);
                FillDgv_Mensualidades(cuotas);
                checkBecado.Checked = matriculas != null ? matriculas[0].Becado == 1 : checkBecado.Checked;

            }
        }
        private void txtAporte_Enter(object sender, EventArgs e)
        {
            Control txt = sender as Control;

            if (txt.Text == "0.00")
            {
                txt.Text = "";
            }

        }
    }
}
