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
using System.Reflection;

namespace GOLLSYSTEM.Configuraciones
{
    public partial class RecuperarCursos : Form
    {
        public RecuperarCursos()
        {
            InitializeComponent();
        }
        List<Curso> cursos = new List<Curso>();
        private void RecuperarCursos_Load(object sender, EventArgs e)
        {
            cursos = CursoDAL.getCursosEliminados(Inicio.CurrentSucursal.Id,null);
            FillDgv();
        }
        private void FillDgv()
        {
            dgvCursos.Rows.Clear();
            foreach (Curso curso in cursos)
            {
                dgvCursos.Rows.Add(curso.Id,curso.Nombre,Convert.ToDateTime(curso.Year.Desde).ToString("yyyy"));
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.Rows.Count>0)
            {
                if (dgvCursos.CurrentRow!=null)
                {
                    try
                    {
                        if (MessageBox.Show("¿Esta seguro que desea recuperar el curso " + dgvCursos.CurrentRow.Cells[1].Value.ToString() + "?\nTodos los estudiantes y cuotas apareceran en los registros de ingresos y si hay pendientes apareceran habilitadas para cobrar.", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (CursoDAL.habilitarCurso(cursos.Where(a => a.Id == (long)dgvCursos.CurrentRow.Cells[0].Value).FirstOrDefault(), Inicio.CurrentUser))
                            {
                                MessageBox.Show("El curso ha sido habilitado exitosamente!", "Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                cursos = CursoDAL.getCursosEliminados(Inicio.CurrentSucursal.Id, null);
                                FillDgv();
                            }
                            else
                            {
                                MessageBox.Show("Error en el servidor al intentar habilitar el curso seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        string fileName = "Exeptions_" + Name + ".txt";
                        Validation.FormManager frmManager = new Validation.FormManager();
                        frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar recuperar un curso inhabilitado");
                        MessageBox.Show("Ocurrio un error inesperado al intentar registrar la desersión, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
